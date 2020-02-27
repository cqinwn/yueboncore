
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Options;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Security.Services;

namespace Yuebon.Security.Application
{
    /// <summary>
    /// 文件上传
    /// </summary>
    public class UploadFileApp
    {
        private ILogger<UploadFileApp> _logger;
        private string _filePath;
        private string _dbFilePath;   //数据库中的文件路径
        private string _dbThumbnail;   //数据库中的缩略图路径
        private string _belongApp;//所属应用
        private string _belongAppId;//所属应用ID
        IUploadFileService service = IoCContainer.Resolve<IUploadFileService>();
        private Type type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
        /// <summary>
        /// 
        /// </summary>
        public UploadFileApp()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="setOptions"></param>
        /// <param name="logger"></param>
        public UploadFileApp(IOptions<AppSetting> setOptions, ILogger<UploadFileApp> logger)
        {
            _logger = logger;
            _filePath = setOptions.Value.UploadPath;
            if (string.IsNullOrEmpty(_filePath))
            {
                _filePath = AppContext.BaseDirectory;
            }
        }
        /// <summary>
        /// 根据应用Id和应用标识批量更新数据
        /// </summary>
        /// <param name="belongAppId">应用Id</param>
        /// <param name="oldBeLongAppId">更新前旧的应用Id</param>
        /// <param name="beLongApp">应用标识</param>
        /// <returns></returns>
        public bool UpdateByBeLongAppId(string belongAppId, string oldBeLongAppId, string beLongApp = null)
        {
            return service.UpdateByBeLongAppId(belongAppId, oldBeLongAppId, beLongApp);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public long Insert(UploadFile info)
        {
            return service.Insert(info);
        }
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public UploadFile Get(string id)
        {
            return service.Get(id);
        }
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">是否降序</param>
        /// <returns>指定对象的集合</returns>
        public List<UploadFileOuputDto> FindWithPager(string condition, PagerInfo info, string fieldToSort, bool desc)
        {
            return service.FindWithPager(condition,info,fieldToSort, desc,null).MapTo<UploadFileOuputDto>();
        }
        /// <summary>
        /// 批量上传文件
        /// </summary>
        /// <param name="files">文件</param>
        /// <param name="belongApp">所属应用，如文章article</param>
        /// <param name="belongAppId">所属应用ID，如文章id</param>
        /// <returns></returns>
        public List<UploadFileResultOuputDto> Adds(IFormFileCollection files,string belongApp, string belongAppId)
        {
            List<UploadFileResultOuputDto> result = new List<UploadFileResultOuputDto>();
            foreach (var file in files)
            {
                if (file != null)
                {
                    result.Add(Add(file, belongApp, belongAppId));
                }
            }

            return result;
        }
        /// <summary>
        /// 单个上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="belongApp">所属应用，如文章article</param>
        /// <param name="belongAppId">所属应用ID，如文章id</param>
        /// <returns></returns>
        public UploadFileResultOuputDto Add(IFormFile file, string belongApp, string belongAppId)
        {
            _belongApp = belongApp;
            _belongAppId = belongAppId;
            if (file != null && file.Length > 0 && file.Length < 10485760)
            {
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var data = binaryReader.ReadBytes((int)file.Length);
                    UploadFile(fileName, data);

                    UploadFile filedb = new UploadFile
                    {
                        FilePath = _dbFilePath,
                        Thumbnail = _dbThumbnail,
                        FileName = fileName,
                        FileSize = file.Length,
                        FileType = Path.GetExtension(fileName),
                        Extension = Path.GetExtension(fileName),
                        BelongApp=_belongApp,
                        BelongAppId=_belongAppId
                    };
                    service.Insert(filedb);
                    return filedb.MapTo<UploadFileResultOuputDto>();
                }
            }
            else
            {
                Log4NetHelper.Error("文件过大");
                throw new Exception("文件过大");
            }
        }
        /// <summary>
        /// 实现文件上传到服务器保存，并生成缩略图
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="fileBuffers">文件字节流</param>
        private void UploadFile(string fileName, byte[] fileBuffers)
        {
            string folder = DateTime.Now.ToString("yyyyMMdd");

            //判断文件是否为空
            if (string.IsNullOrEmpty(fileName))
            {
                Log4NetHelper.Error("文件名不能为空");
                throw new Exception("文件名不能为空");
            }

            //判断文件是否为空
            if (fileBuffers.Length < 1)
            {
                Log4NetHelper.Error("文件不能为空");
                throw new Exception("文件不能为空");
            }
            var _tempfilepath = "/upload/" + _belongApp + "/" + folder + "/";
            var uploadPath = _filePath + _tempfilepath;
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            var ext = Path.GetExtension(fileName).ToLower();
            string newName = GuidUtils.CreateNo() + ext;

            using (var fs = new FileStream(uploadPath + newName, FileMode.Create))
            {
                fs.Write(fileBuffers, 0, fileBuffers.Length);
                fs.Close();
                //生成缩略图
                if (ext.Contains(".jpg") || ext.Contains(".jpeg") || ext.Contains(".png") || ext.Contains(".bmp") || ext.Contains(".gif"))
                {
                    string thumbnailName = GuidUtils.CreateNo() + ext;
                    ImgHelper.MakeThumbnail(uploadPath + newName, uploadPath + thumbnailName);
                    _dbThumbnail = folder + "/" + thumbnailName;
                }
                _dbFilePath = _tempfilepath + "/" + newName;
            }
        }
    }
}
