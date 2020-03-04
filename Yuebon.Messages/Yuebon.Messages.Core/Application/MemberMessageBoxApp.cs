using System.Collections.Generic;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Pages;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Application
{
    public class MemberMessageBoxApp
    {
        IMemberMessageBoxService messageTemplatesService = IoCContainer.Resolve<IMemberMessageBoxService>();

        /// <summary>
        /// 按页返回数据
        /// </summary>
        /// <returns></returns>
        public List<MemberMessageBox> GetMemberMsgListByPage(string condition, PagerInfo info, string fieldToSort, bool desc)
        {
            List<MemberMessageBox> list = messageTemplatesService.FindWithPager(condition, info, fieldToSort, desc);
            return list;
        }

        /// <summary>
        /// 更新已读状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateIsReadStatus(string id, int isread,string userid)
        {
            return messageTemplatesService.UpdateIsReadStatus(id, isread,userid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isread">2:全部，0：未读，1：已读</param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetTotalCounts(int isread, string userid)
        {
            return messageTemplatesService.GetTotalCounts(isread, userid);
        }

    }
}
