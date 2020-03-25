using System;
using System.Data.Common;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Repositories;
using Yuebon.Commons.Services;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using System.Data;
using Yuebon.Security.Dtos;
using System.Collections.Generic;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UserFocusService : BaseService<UserFocus, UserFocusOutputDto, string>, IUserFocusService
    {
        private readonly IUserFocusRepository _userRepository;
        private readonly IUserLogOnRepository _userSigninRepository;
        private readonly ILogService _logService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="userLogOnRepository"></param>
        /// <param name="logService"></param>
        public UserFocusService(IUserFocusRepository repository, IUserLogOnRepository userLogOnRepository, ILogService logService) : base(repository)
        {
            _userRepository = repository;
            _userSigninRepository = userLogOnRepository;
            _logService = logService;
            _userRepository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public long InsertFocus(string focusid, string creatoruserid)
        {
            return _userRepository.InsertFocus(focusid, creatoruserid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public int DeleteFocus(string focusid, string creatoruserid)
        {
            return _userRepository.DeleteFocus(focusid, creatoruserid);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public bool GetIfFocusStatus(string focusid, string creatoruserid)
        {
            return _userRepository.GetIfFocusStatus(focusid, creatoruserid);
        }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="creatoruserid"></param>
            /// <returns></returns>
            public int GetTotalFocus(string creatoruserid)
        {
            return _userRepository.GetTotalFocus(creatoruserid);
        }

        /// <summary>
        /// 分页得到列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<UserFocusExtendOutPutDto> GetUserFocusListByPage(string filter, string currentpage,
            string pagesize, string userid)
        {
            return _userRepository.GetUserFocusListByPage(filter, currentpage, pagesize, userid);
        }

    }
}