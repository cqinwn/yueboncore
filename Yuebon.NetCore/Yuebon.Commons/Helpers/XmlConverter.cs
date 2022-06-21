using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// XML文件与对象相互转化操作
    /// </summary>
    public class XmlConverter
    {
        /// <summary>
        /// 将对象转换为xml格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="xmlFilePath">xml文件路径</param>
        /// <returns></returns>
        public static void Serialize<T>(T obj,string xmlFilePath)
        {
            FileStream xmlfs = null;
            try { 
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                xmlfs = new FileStream(xmlFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                serializer.Serialize(xmlfs, obj);
            }
            catch (Exception ex)
            {
                throw new Exception("",ex);
            }
            finally
            {
                if (xmlfs != null)
                    xmlfs.Close();
            }
        }

        /// <summary>
        /// 将xml格式转为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlFilePath">xml文件路径</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlFilePath)
        {
            XDocument doc = XDocument.Load(xmlFilePath);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(doc.ToString());
            T result = (T)(serializer.Deserialize(reader));
            reader.Close();
            reader.Dispose();
            return result;
        }
    }
}
