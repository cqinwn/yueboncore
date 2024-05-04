namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 系统用户角色表输出对象模型
    /// </summary>
    [Serializable]
    public partial class UserRoleOutputDto
    {
        /// <summary>
        /// 设置或获取用户Id
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 设置或获取角色Id
        /// </summary>
        public long? RoleId { get; set; }


    }
}
