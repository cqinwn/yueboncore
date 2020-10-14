using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Yuebon.Commons.Extend;

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
            /// <summary>
            /// 读文件
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public static string ReadFile(string path)
        {
            path = path.ToFilePath();
            if (!File.Exists(path))
                return "";
            using (StreamReader stream = new StreamReader(path))
            {
                return stream.ReadToEnd(); // 读取文件
            }
        }



        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="content">文件内容</param>
        /// <param name="appendToLast">是否追加到最后</param>
        public static void WriteFile(string path, string fileName, string content, bool appendToLast = false)
        {
            if (!path.EndsWith("\\"))
            {
                path = path + "\\";
            }
            path = path.ToFilePath();
            if (!Directory.Exists(path))//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream stream = File.Open(path + fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] by = Encoding.Default.GetBytes(content);
                if (appendToLast)
                {
                    stream.Position = stream.Length;
                }
                else
                {
                    stream.SetLength(0);
                }
                stream.Write(by, 0, by.Length);
            }
        }

    }
}
