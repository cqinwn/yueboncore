using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// 文件处理帮助类
    /// </summary>
    public class FileHelper
    {

        /// <summary>
        /// 制作压缩包（多个文件压缩到一个压缩包，支持加密、注释）
        /// </summary>
        /// <param name="topDirectoryName">压缩文件目录</param>
        /// <param name="zipedFileName">压缩包文件名</param>
        /// <param name="compresssionLevel">压缩级别 1-9 </param>
        /// <param name="password">密码</param>
        /// <param name="comment">注释</param>
        /// <param name="filetype">文件类型</param>
        public static void ZipFiles(string topDirectoryName, string zipedFileName, int compresssionLevel, string password, string comment, string filetype)
        {
            using (ZipOutputStream zos = new ZipOutputStream(File.Open(zipedFileName, FileMode.OpenOrCreate)))
            {
                if (compresssionLevel != 0)
                {
                    zos.SetLevel(compresssionLevel);//设置压缩级别
                }
                if (!string.IsNullOrEmpty(password))
                {
                    zos.Password = password;//设置zip包加密密码
                }
                if (!string.IsNullOrEmpty(comment))
                {
                    zos.SetComment(comment);//设置zip包的注释
                }
                //循环设置目录下所有的*.jpg文件（支持子目录搜索）
                foreach (string file in Directory.GetFiles(topDirectoryName, filetype, SearchOption.AllDirectories))
                {
                    if (File.Exists(file))
                    {
                        FileInfo item = new FileInfo(file);
                        FileStream fs = File.OpenRead(item.FullName);
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        ZipEntry entry = new ZipEntry(item.Name);
                        zos.PutNextEntry(entry);
                        zos.Write(buffer, 0, buffer.Length);
                        fs.Close();
                    }
                }
                zos.Close();
            }
        }

    }
}
