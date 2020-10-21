module.exports = {
  title: '管理系统',
  /**
   *是否固定头部
   */
  fixedHeader: false,
  /**
   * 是否显示侧边Logo
   */
  sidebarLogo: true,
  /**
   * 应用Id
   */
  appId: 'system',
  /**
   * 应用密钥
   */
  appSecret: '87135AB0160F706D8B47F06BDABA6FC6',
  /**
   * 子系统
   */
  subSystem: {},
  /**
   * 当前访问系统代码
   */
  activeSystemCode: 'openauth',
  /**
   * 当前访问系统名称
   */
  activeSystemName: '',
  /**
   * 动态可访问路由
   */
  addRouters: {},

  // apiHostUrl: 'http://netcoreapi.ts.yuebon.com/api/', // 基础接口
  // apiSecurityUrl: 'http://netcoreapi.ts.yuebon.com/api/Security/', // 权限管理系统接口
  // fileUrl: 'http://netcoreapi.ts.yuebon.com/', // 文件访问路径
  // fileUploadUrl: 'http://netcoreapi.ts.yuebon.com/api/Files/Upload'// 文件上传路径

  apiHostUrl: 'https://localhost:44377/api/', // 基础接口
  apiSecurityUrl: 'https://localhost:44377/api/Security/', // 权限管理系统接口
  fileUrl: 'https://localhost:44377/', // 文件访问路径
  fileUploadUrl: 'https://localhost:44377/api/Files/Upload'// 文件上传路径
}
