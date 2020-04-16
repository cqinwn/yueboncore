using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IoC;
using Yuebon.Security.IServices;

namespace Yuebon.Security.Application
{
    public class WorkOrderApp
    {
        IWorkOrderService service = IoCContainer.Resolve<IWorkOrderService>();
        public bool SetStatusByIds(string ids)
        {
            bool res = false;
            if (!string.IsNullOrEmpty(ids))
            {
                //List<string> idArray = ids.ToDelimitedList<string>(",");
                //foreach (string strId in idArray)
                //{
                //    res= service.UpdateTableField("Status", "1", "Id='" + strId + "'");
                //}
            }
            return res;
        }
    }
}
