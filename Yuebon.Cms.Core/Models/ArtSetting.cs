using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.CMS.Models
{
    public class ArtSetting
    {
        /// <summary>
        /// 设置或获取 应用名设置
        /// </summary>
        public string AppName { set; get; }
        /// <summary>
        /// 设置或获取 开启推送
        /// </summary>
        public bool IsOpenPush { set; get; }
        /// <summary>
        /// 设置或获取 开启审核
        /// </summary>
        public bool IsOpenAudit { set; get; }
        /// <summary>
        /// 设置或获取 开启推荐
        /// </summary>
        public bool IsOpenRecommend { set; get; }
        /// <summary>
        /// 设置或获取 开启赞赏
        /// </summary>
        public bool IsOpenReward { set; get; }
        /// <summary>
        /// 设置或获取 打赏金额
        /// </summary>
        public string RewardAmount { set; get; }
        /// <summary>
        /// 设置或获取 列表页分享标题
        /// </summary>
        public string ListShareTitle { set; get; }
        /// <summary>
        /// 设置或获取 列表页分享详情
        /// </summary>
        public string ListShareDesc { set; get; }
        /// <summary>
        /// 设置或获取 列表页分享图
        /// </summary>
        public string ListShareImage { set; get; }
        /// <summary>
        /// 设置或获取 详情页面版权申明
        /// </summary>
        public string DetailCopyRight { set; get; }
        /// <summary>
        /// 设置或获取 列表显示标题
        /// </summary>
        public string ListTitle { set; get; }
        /// <summary>
        /// 设置或获取 列表公告内容
        /// </summary>
        public string ListNotice { set; get; }
        /// <summary>
        /// 设置或获取 列表公告内容链接
        /// </summary>
        public string ListNoticeUrl { set; get; }
        /// <summary>
        /// 设置或获取 详情页面海报背景图
        /// </summary>
        public string DetailShareBgImg { set; get; }
    }
}
