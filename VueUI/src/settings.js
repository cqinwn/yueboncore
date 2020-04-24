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
  apiHostUrl: 'http://192.168.1.132:808/api/', // 基础接口
  apiWSecurityUrl: 'http://192.168.1.132:808/api/Security/', // 权限管理系统接口
  apiWMSUrl: 'http://192.168.1.132:808/api/wms/', // 仓储系统接口
  apiWCSUrl: 'http://192.168.1.132:808/api/wcs/', // 分拣系统接口
  fileUrl: 'http://192.168.1.132:808/', // 文件访问路径
  fileUploadUrl: 'http://192.168.1.132:808/api/Files/Upload'// 文件上传路径
}
