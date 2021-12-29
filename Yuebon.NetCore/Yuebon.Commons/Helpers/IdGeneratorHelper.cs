using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yitter.IdGenerator;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// Id生成器,包含Guid、时间+随机数、雪花算法生成Id。
    /// </summary>
    public class IdGeneratorHelper
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
        public static long IdSnowflake()
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
    }
}
