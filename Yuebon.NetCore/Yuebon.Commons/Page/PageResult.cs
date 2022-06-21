using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Commons.Pages
{
    /// <summary>
    /// 保存分页请求的结果。
    /// </summary>
    /// <typeparam name="T">返回结果集中的POCO类型</typeparam>
    public class PageResult<T>:CommonResult
    {
        public PageResult()
        {
        }
        public PageResult(bool success, string msg, object rows)
        {
            this.Success = success;
            this.ErrMsg = msg;
            this.ResData =rows ;
        }
        public PageResult(int currentPage, int totalItems, int itemsPerPage)
        {
            CurrentPage = currentPage;
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage;
        }

        public PageResult(int currentPage, int totalPages, int totalItems, int itemsPerPage, List<T> items, object context) : this(currentPage, totalPages, totalItems)
        {
            ItemsPerPage = itemsPerPage;
            Items = items;
            Context = context;
        }

        /// <summary>
        /// 当前页码。
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 总页码数。
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// 记录总数。
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// 每页数量。
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// 当前结果集。
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        /// 自定义用户属性。
        /// </summary>
        public object Context { get; set; }
    }
}