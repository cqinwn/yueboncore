﻿using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Log;

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
        /// 压缩多层目录
        /// </summary>
        /// <param name="topDirectoryName">压缩文件目录</param>
        /// <param name="zipedFileName">压缩包文件名</param>
        /// <param name="compresssionLevel">压缩级别 1-9 </param>
        /// <param name="password">密码</param>
        /// <param name="comment">注释</param>
        /// <param name="filetype">文件类型</param>
        public static void ZipFileDirectory(string topDirectoryName, string zipedFileName, int compresssionLevel, string password, string comment, string filetype)
        {
            using (System.IO.FileStream ZipFile = File.Open(zipedFileName, FileMode.OpenOrCreate))
            {
                using (ZipOutputStream zos = new ZipOutputStream(ZipFile))
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
                    ZipSetp(topDirectoryName, zos, "", filetype);
                }
            }
        }

        /// <summary>
        /// 递归遍历目录
        /// </summary>
        /// <param name="strDirectory">The directory.</param>
        /// <param name="s">The ZipOutputStream Object.</param>
        /// <param name="parentPath">The parent path.</param>
        /// <param name="filetype"></param>
        private static void ZipSetp(string strDirectory, ZipOutputStream s, string parentPath, string filetype)
        {
            if (strDirectory[strDirectory.Length - 1] != Path.DirectorySeparatorChar)
            {
                strDirectory += Path.DirectorySeparatorChar;
            }

            Crc32 crc = new Crc32();

            string[] filenames = Directory.GetFileSystemEntries(strDirectory, filetype);
            foreach (string file in filenames)// 遍历所有的文件和目录
            {
                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {
                    string pPath = parentPath;
                    pPath += file.Substring(file.LastIndexOf("\\") + 1);
                    pPath += "\\";
                    ZipSetp(file, s, pPath, filetype);
                }
                else // 否则直接压缩文件
                {
                    //打开压缩文件
                    using (FileStream fs = File.OpenRead(file))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        string fileName = parentPath + file.Substring(file.LastIndexOf("\\") + 1);
                        ZipEntry entry = new ZipEntry(fileName);
                        entry.DateTime = DateTime.Now;
                        entry.Size = fs.Length;
                        fs.Close();
                        crc.Reset();
                        crc.Update(buffer);
                        entry.Crc = crc.Value;
                        s.PutNextEntry(entry);
                        s.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
        #region 读取文件
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
        /// 文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Exists(string path)
        {
            if (!File.Exists(path))
                return false;
            else
                return true;
        }
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string ReadFile(string Path, Encoding encode)
        {
            string s = "";
            if (!File.Exists(Path))
                s = "不存在相应的目录";
            else
            {
                StreamReader f2 = new StreamReader(Path, encode);
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }

            return s;
        }
        #endregion
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

        #region 直接删除指定目录下的所有文件及文件夹(保留目录)
        /// <summary>
        /// 删除指定目录下的所有文件及文件夹(保留目录)
        /// </summary>
        /// <param name="file">文件目录</param>
        public static void DeleteDirectory(string file)
        {
            try
            {
                //判断文件夹是否还存在
                if (Directory.Exists(file))
                {
                    DirectoryInfo fileInfo = new DirectoryInfo(file);
                    //去除文件夹的只读属性
                    fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;
                    foreach (string f in Directory.GetFileSystemEntries(file))
                    {
                        if (File.Exists(f))
                        {
                            //去除文件的只读属性
                            File.SetAttributes(file, FileAttributes.Normal);
                            //如果有子文件删除文件
                            File.Delete(f);
                        }
                        else
                        {
                            //循环递归删除子文件夹
                            DeleteDirectory(f);
                        }
                    }
                    //删除空文件夹
                    Directory.Delete(file);
                }

            }
            catch (Exception ex) // 异常处理
            {
                Log4NetHelper.Error("删除文件异常", ex);
            }
        }

        #endregion



        #region 获取文件的编码类型

        /// <summary>
        /// 获取文件编码
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string filePath)
        {
            return GetEncoding(filePath, Encoding.Default);
        }

        /// <summary>
        /// 获取文件编码
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="defaultEncoding">找不到则返回这个默认编码</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string filePath, Encoding defaultEncoding)
        {
            Encoding targetEncoding = defaultEncoding;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4))
            {
                if (fs != null && fs.Length >= 2)
                {
                    long pos = fs.Position;
                    fs.Position = 0;
                    int[] buffer = new int[4];
                    //long x = fs.Seek(0, SeekOrigin.Begin);
                    //fs.Read(buffer,0,4);
                    buffer[0] = fs.ReadByte();
                    buffer[1] = fs.ReadByte();
                    buffer[2] = fs.ReadByte();
                    buffer[3] = fs.ReadByte();

                    fs.Position = pos;

                    if (buffer[0] == 0xFE && buffer[1] == 0xFF)//UnicodeBe
                    {
                        targetEncoding = Encoding.BigEndianUnicode;
                    }
                    if (buffer[0] == 0xFF && buffer[1] == 0xFE)//Unicode
                    {
                        targetEncoding = Encoding.Unicode;
                    }
                    if (buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF)//UTF8
                    {
                        targetEncoding = Encoding.UTF8;
                    }
                }
            }

            return targetEncoding;
        }

        #endregion

    }
}
