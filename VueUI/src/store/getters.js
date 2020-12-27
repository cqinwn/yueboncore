const getters = {
  sidebar: state => state.app.sidebar,
  device: state => state.app.device,
  visitedViews: state => state.tagsView.visitedViews,
  cachedViews: state => state.tagsView.cachedViews,
  token: state => state.user.token,
  avatar: state => state.user.avatar,
  name: state => state.user.name,
  subSystem: state => state.user.subSystem,
  activeSystemName: state => state.user.activeSystemName,
  menus: state => state.user.menus,
  addRouters: state => state.settings.addRouters
}
export default getters
