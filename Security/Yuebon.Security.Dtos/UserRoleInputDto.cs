namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 系统用户角色表输入对象模型
    /// </summary>
    [AutoMap(typeof(UserRole))]
    [Serializable]
    public partial class UserRoleInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取用户Id
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 角色Id集合
        /// </summary>
        public List<long> RoleIdList { get; set; }

    }
}
