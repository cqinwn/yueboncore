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
 * 开启 Tags-View
 */
  tagsView: true,
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

  apiHostUrl: 'http://localhost:54678/api/', // 基础接口
  apiSecurityUrl: 'http://localhost:54678/api/Security/', // 权限管理系统接口
  fileUrl: 'http://localhost:54678/', // 文件访问路径
  fileUploadUrl: 'http://localhost:54678/api/Files/Upload'// 文件上传路径

  // apiHostUrl: 'http://193.168.25.137:8082/api/', // 基础接口
  // apiSecurityUrl: 'http://193.168.25.137:8082/api/Security/', // 权限管理系统接口
  // fileUrl: 'http://193.168.25.137:8082/', // 文件访问路径
  // fileUploadUrl: 'http://193.168.25.137:8082/api/Files/Upload'// 文件上传路径
}
