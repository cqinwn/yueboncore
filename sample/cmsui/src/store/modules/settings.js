import variables from '@/styles/element-variables.scss'
import defaultSettings from '@/settings'

const { sideTheme, showSettings, tagsView, fixedHeader, sidebarLogo, appId, appSecret, subSystem, activeSystemCode, activeSystemName, addRouters } = defaultSettings

const state = {
  theme: variables.theme,
  sideTheme: sideTheme,
  showSettings: showSettings,
  tagsView: tagsView,
  fixedHeader: fixedHeader,
  sidebarLogo: sidebarLogo,
  appId: appId,
  appSecret: appSecret,
  subSystem: subSystem,
  activeSystemCode: activeSystemCode,
  activeSystemName: activeSystemName,
  addRouters: addRouters
}

const mutations = {
  CHANGE_SETTING: (state, { key, value }) => {
    // eslint-disable-next-line no-prototype-builtins
    if (state.hasOwnProperty(key)) {
      state[key] = value
    }
  }
}

const actions = {
  changeSetting({ commit }, data) {
    commit('CHANGE_SETTING', data)
  },
  /**
   * 加载用户配置主题
   * @param {} param
   * @param {*} data
   */
  loadUserSettingTheme({ commit }, data) {
    if (data !== 'default') {
      var userTheme = JSON.parse(data)
      state.theme = userTheme.Theme
      state.sideTheme = userTheme.SideTheme
      state.fixedHeader = userTheme.FixedHeader
      state.tagsView = userTheme.TagsView
      state.sidebarLogo = userTheme.SidebarLogo
    }
  }

}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}

