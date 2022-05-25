const getters = {
  sidebar: state => state.app.sidebar,
  size: state => state.app.size,
  language: state => state.app.language,
  device: state => state.app.device,
  visitedViews: state => state.tagsView.visitedViews,
  cachedViews: state => state.tagsView.cachedViews,
  token: state => state.user.token,
  avatar: state => state.user.avatar,
  name: state => state.user.name,
  introduction: state => state.user.introduction,
  roles: state => state.user.roles,
  permissions: state => state.user.permissions,
  permission_routes: state => state.permission.routes,
  topbarRouters: state => state.permission.topbarRouters,
  defaultRoutes: state => state.permission.defaultRoutes,
  sidebarRouters: state => state.permission.sidebarRouters,
  appId: state => state.settings.appId,
  appSecret: state => state.settings.appSecret,
  menus: state => state.user.menus,
  subSystem: state => state.user.subSystem,
  activeSystemName: state => state.user.activeSystemName
}
export default getters