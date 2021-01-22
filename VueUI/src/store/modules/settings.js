import defaultSettings from '@/settings'

const { showSettings, tagsView, fixedHeader, sidebarLogo, appId, appSecret, subSystem, activeSystemCode, activeSystemName, addRouters } = defaultSettings

const state = {
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
    if (state.HasOwnProperty(key)) {
      state[key] = value
    }
  }
}

const actions = {
  changeSetting({ commit }, data) {
    commit('CHANGE_SETTING', data)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}

