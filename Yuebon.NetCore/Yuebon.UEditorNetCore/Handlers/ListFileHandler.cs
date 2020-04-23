using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Yuebon.Commons.Pages;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;

namespace Yuebon.UEditorNetCore.Handlers
{
    public class ListFileManager : Handler
    {
        enum ResultState
        {
            Success,
            InvalidParam,
            AuthorizError,
            IOError,
            PathNotFound
        }

        private int Start;
        private int Size;
        private int Total;
        private ResultState State;
        private String PathToList;
        //private String[] FileList;
        private List<UploadFileOutputDto> FileList;
        private String[] SearchExtensions;

        public ListFileManager(HttpContext context, string pathToList, string[] searchExtensions)
            : base(context)
        {
            this.SearchExtensions = searchExtensions.Select(x => x.ToLower()).ToArray();
            this.PathToList = pathToList;
        }

        public override void Process()
        {
            try
            {
                Start = String.IsNullOrEmpty(Request.Query["start"]) ? 0 : Convert.ToInt32(Request.Query["start"]);
                Size = String.IsNullOrEmpty(Request.Query["size"]) ? Config.GetInt("imageManagerListSize") : Convert.ToInt32(Request.Query["size"]);
            }
            catch (FormatException)
            {
                State = ResultState.InvalidParam;
                WriteResult();
                return;
            }
            List<UploadFileOutputDto> buildingList = new List<UploadFileOutputDto>();
            try
            {
                int pageIndex = 1;
                pageIndex = Start/ Size + 1;
                PagerInfo page = new PagerInfo();
                page.PageSize = Size;
                page.CurrenetPageIndex = pageIndex;
                buildingList= new UploadFileApp().FindWithPager("", page, "CreatorTime",true);
                var localPath = Path.Combine(Config.WebRootPath, PathToList);
                //buildingList.AddRange(Directory.GetFiles(localPath, "*", SearchOption.AllDirectories)
                //    .Where(x => SearchExtensions.Contains(Path.GetExtension(x).ToLower()))
                //    .Select(x => PathToList + x.Substring(localPath.Length).Replace("\\", "/")));
                Total = page.RecordCount;
                FileList = buildingList;
            }
            catch (UnauthorizedAccessException)
            {
                State = ResultState.AuthorizError;
            }
            catch (DirectoryNotFoundException)
            {
                State = ResultState.PathNotFound;
            }
            catch (IOException)
            {
                State = ResultState.IOError;
            }
            finally
            {
                WriteResult();
            }
        }

        private void WriteResult()
        {
            WriteJson(new
            {
                state = GetStateString(),
                list = FileList,
                start = Start,
                size = Size,
                total = Total
            });
        }

        private string GetStateString()
        {
            switch (State)
            {
                case ResultState.Success:
                    return "SUCCESS";
                case ResultState.InvalidParam:
                    return "参数不正确";
                case ResultState.PathNotFound:
                    return "路径不存在";
                case ResultState.AuthorizError:
                    return "文件系统权限不足";
                case ResultState.IOError:
                    return "文件系统读取错误";
            }
            return "未知错误";
        }
    }
}