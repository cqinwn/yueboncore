module.exports = {
  title: '管理系统',
  /**
   * @type {boolean} true | false
   * @description Whether fix the header
   */
  fixedHeader: false,

  /**
   * @type {boolean} true | false
   * @description 是否在侧边显示logo
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
  apiHostUrl: 'http://netcoreapi.ts.yuebon.com/api/', // 基础接口
  apiWSecurityUrl: 'http://netcoreapi.ts.yuebon.com/api/Security/', // 权限管理系统接口
  apiWMSUrl: 'http://netcoreapi.ts.yuebon.com/api/wms/', // 仓储系统接口
  apiWCSUrl: 'http://netcoreapi.ts.yuebon.com/api/wcs/', // 分拣系统接口
  fileUrl: 'http://netcoreapi.ts.yuebon.com/', // 文件访问路径
  fileUploadUrl: 'http://netcoreapi.ts.yuebon.com/api/Files/Upload'// 文件上传路径
}
