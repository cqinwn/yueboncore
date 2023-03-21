export default {
  /**
   * 网页标题
   */
  title: import.meta.env.VITE_APP_TITLE,
  /**
   * 侧边栏主题 深色主题theme-dark，浅色主题theme-light
   */
  sideTheme: 'theme-dark',
  /**
   * 是否系统布局配置
   */
  showSettings: false,

  /**
   * 是否显示顶部导航
   */
  topNav: false,

  /**
   * 是否显示 tagsView
   */
  tagsView: true,

  /**
   * 是否固定头部
   */
  fixedHeader: false,

  /**
   * 是否显示logo
   */
  sidebarLogo: true,

  /**
   * 是否显示动态标题
   */
  dynamicTitle: false,

  /**
   * @type {string | array} 'production' | ['production', 'development']
   * @description Need show err logs component.
   * The default is only used in the production env
   * If you want to also use it in dev, you can pass ['production', 'development']
   */
  errorLog: 'production',

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

  // baseUrl: 'http://localhost:5002/api/Files/Upload',
  // apiHostUrl: 'http://localhost:5002/api/', // 基础接口
  // apiSecurityUrl: 'http://localhost:5002/api/Security/', // 权限管理系统接口
  // apiCMSUrl: 'http://localhost:5002/api/CMS/', // 文章
  // fileUrl: 'http://localhost:5002/', // 文件访问路径
  // fileUploadUrl: 'http://localhost:5002/api/Files/Upload'// 文件上传路径

  baseUrl: 'http://ply.ts.56kyb.com/api/Files/Upload',
  apiHostUrl: 'http://ply.ts.56kyb.com/api/', // 基础接口
  apiSecurityUrl: 'http://ply.ts.56kyb.com/api/Security/', // 权限管理系统接口
  apiCMSUrl: 'http://ply.ts.56kyb.com/api/CMS/', // 文章
  fileUrl: 'http://ply.ts.56kyb.com/', // 文件访问路径
  fileUploadUrl: 'http://ply.ts.56kyb.com/api/Files/Upload'// 文件上传路径
}
