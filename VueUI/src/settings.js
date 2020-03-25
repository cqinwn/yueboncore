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
  activeSystemCode: 'YuebonWcs',
  /**
   * 当前访问系统名称
   */
  activeSystemName: '',
  /**
   * 动态可访问路由
   */
  addRouters: {},
  apiHostUrl: 'http://192.168.1.106:809/api/', // 'http://192.168.1.106:809/api/', //
  apiWMSUrl: 'http://192.168.1.106:809/api/wms/'
}
