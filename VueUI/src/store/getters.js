const getters = {
  sidebar: state => state.app.sidebar,
  device: state => state.app.device,
  visitedViews: state => state.tagsView.visitedViews,
  cachedViews: state => state.tagsView.cachedViews,
  token: state => state.user.token,
  avatar: state => state.user.avatar,
  name: state => state.user.name,
  roles: state => state.user.roles,
  subSystem: state => state.user.subSystem,
  activeSystemName: state => state.user.activeSystemName,
  menus: state => state.user.menus,
  permissions: state => state.user.permissions,
  permission_routes: state => state.permission.routes,
  addRouters: state => state.settings.addRouters,
  sidebarRouters: state => state.permission.sidebarRouters,
  appId: state => state.settings.appId,
  appSecret: state => state.settings.appSecret
}
export default getters
