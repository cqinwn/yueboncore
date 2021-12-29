using System;
using System.Collections.Generic;
using System.Text;
using Yitter.IdGenerator;

namespace Yuebon.Commons.Helpers
{
    /// <summary>  
    /// Guid工具类  
    /// </summary>  
    public class GuidUtils
    {
        #region 自动生成编号
        /// <summary>
        /// 表示全局唯一标识符 (GUID)。
        /// </summary>
        /// <returns></returns>
        public static string GuId()
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 自动生成编号/唯一订单号生成，时间戳+随机数，时间戳精确到毫秒，形如2020052113254137177350
        /// 高并发会出现重复Id
        /// </summary>
        /// <returns></returns>
        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(10000, 99999).ToString(); //生成随机编号 
            string code = DateTime.Now.ToString("yyyyMMddHHmmssffff") + strRandom;//形如2020052113254137177350
            return code;
        }
        /// <summary>
        /// 雪花飘逸算法生成ID
        /// </summary>
        public static long IdGenerator()
        {
            var options = new IdGeneratorOptions()
            {
                WorkerId = 1,
                WorkerIdBitLength = 10,
                SeqBitLength = 6,
                DataCenterIdBitLength = 1,
                TopOverCostCount = 2000,

                //TimestampType = 1,

                // MinSeqNumber = 1,
                // MaxSeqNumber = 200,

                // BaseTime = DateTime.Now.AddYears(-10),
            };

            IIdGenerator IdGen = new DefaultIdGenerator(options);
            return IdGen.NewLong();

        }
        #endregion
        /// <summary>  
        /// 获取一个大写的字符串  
        /// </summary>  
        /// <param name="str"></param>  
        /// <returns></returns>  
        private static string upper(string str)
        {
            return str.ToUpper();
        }

        /// <summary>  
        /// 获取32位不包含“-”号的GUID字符串  
        /// </summary>  
        /// <returns></returns>  
        public static string NewGuidFormatN(bool isUpper = false)
        {
            var guid = Guid.NewGuid().ToString("N");
            return isUpper == true ? upper(guid) : guid;
        }

        /// <summary>  
        /// 获取32位包含“-”号的GUID字符串  
        /// </summary>  
        /// <param name="isUpper"></param>  
        /// <returns></returns>  
        public static string NewGuidFormatD(bool isUpper = false)
        {
            var guid = Guid.NewGuid().ToString("D");
            return isUpper == true ? upper(guid) : guid;
        }

        /// <summary>  
        /// 获取32位包含“-”号的GUID被“(”、“)”包括的字符串  
        /// </summary>  
        /// <param name="isUpper"></param>  
        /// <returns></returns>  
        public static string NewGuidFormatP(bool isUpper = false)
        {
            var guid = Guid.NewGuid().ToString("P");
            return isUpper == true ? upper(guid) : guid;
        }

        /// <summary>  
        /// 获取32位包含“-”号的GUID被“{”、“}”包括的字符串  
        /// </summary>  
        /// <param name="isUpper"></param>  
        /// <returns></returns>  
        public static string NewGuidFormatB(bool isUpper = false)
        {
            var guid = Guid.NewGuid().ToString("B");
            return isUpper == true ? upper(guid) : guid;
        }

        /// <summary>  
        /// 获取4个被“{”、“}”包括的十六进制数，其中第四个值位8个被“{”、“}”包括的十六进制数字符串  
        /// </summary>  
        /// <param name="isUpper"></param>  
        /// <returns></returns>  
        public static string NewGuidFormatX(bool isUpper = false)
        {
            var guid = Guid.NewGuid().ToString("X");
            return isUpper == true ? upper(guid) : guid;
        }

    }
}
