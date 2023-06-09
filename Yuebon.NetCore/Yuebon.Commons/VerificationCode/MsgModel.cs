using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    public class MsgModel
    {
        public string MsgCode { get; set; }
        public string MsgData { get; set; }
        public string MsgError { get; set; }
    }

    public class InnerMsgModel
    {
        public string MsgCode { get; set; }
        public object MsgData { get; set; }
        public string MsgError { get; set; }
    }
}
