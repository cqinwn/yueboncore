using System;
using System.Collections.Generic;
using Yuebon.Commons.Services;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using AutoMapper;
using System.Linq;

namespace Yuebon.Security.Services
{
    public class MenuService: BaseService<Menu, string>, IMenuService
    {
        private readonly IMenuRepository _MenuRepository;
        private readonly IUserRepository userRepository;
        private readonly IRoleAuthorizeRepository roleAuthorizeRepository;
        private readonly ILogService _logService;
        public MenuService(IMenuRepository repository,IUserRepository _userRepository, IRoleAuthorizeRepository _roleAuthorizeRepository, ILogService logService) : base(repository)
        {
            _MenuRepository = repository;
            userRepository = _userRepository;
            roleAuthorizeRepository = _roleAuthorizeRepository;
            _logService = logService;
            _MenuRepository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<Menu> GetMenuByUser(string userId)
        {
            List<Menu> result = new List<Menu>();
            List<Menu> allMenuls = new List<Menu>();
            List<Menu> subMenuls = new List<Menu>();
            string where = string.Format("Layers=1");
            IEnumerable<Menu> allMenus = _MenuRepository.GetAllByIsNotDeleteAndEnabledMark();
            allMenuls = allMenus.ToList();
            if (userId == string.Empty) //超级管理员
            {
                return allMenuls;
            }
            var user = userRepository.Get(userId);
            if (user == null)
                return result;
            var userRoles = user.RoleId;
            where = string.Format("ItemType = 1 and ObjectType = 1 and ObjectId='{0}'",userRoles);
            var Menus = roleAuthorizeRepository.GetListWhere(where);
            foreach (RoleAuthorize item in Menus)
            {
                Menu MenuEntity = allMenuls.Find(t => t.Id == item.ItemId);
                if (MenuEntity != null)
                {
                    result.Add(MenuEntity);
                }
            }
            return result.OrderBy(t => t.SortCode).ToList();
        }


    }
}