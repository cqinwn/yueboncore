import defaultSettings from '@/settings'
import { useDynamicTitle } from '@/utils/dynamicTitle'

const { sideTheme, showSettings, topNav, tagsView, fixedHeader, sidebarLogo, dynamicTitle, appId, appSecret, subSystem, activeSystemCode, activeSystemName } = defaultSettings

const storageSetting = ''
let layoutsetting = localStorage.getItem('layout-setting')
if (!layoutsetting) {
  storageSetting=JSON.parse(layoutsetting)
}
const state = {
  title: '',
  theme: storageSetting.Theme || '#409EFF',
  sideTheme: storageSetting.SideTheme || sideTheme,
  showSettings: showSettings,
  topNav: storageSetting.TopNav === undefined ? topNav : storageSetting.TopNav,
  tagsView: storageSetting.TagsView === undefined ? tagsView : storageSetting.TagsView,
  fixedHeader: storageSetting.FixedHeader === undefined ? fixedHeader : storageSetting.FixedHeader,
  sidebarLogo: storageSetting.SidebarLogo === undefined ? sidebarLogo : storageSetting.SidebarLogo,
  dynamicTitle: storageSetting.DynamicTitle === undefined ? dynamicTitle : storageSetting.DynamicTitle,
  appId: appId,
  appSecret: appSecret,
  subSystem: subSystem,
  activeSystemCode: activeSystemCode,
  activeSystemName: activeSystemName,
}
const mutations = {
  CHANGE_SETTING: (state, { key, value }) => {
    if (state.hasOwnProperty(key)) {
      state[key] = value
    }
  }
}

const actions = {
  // 修改布局设置
  changeSetting({ commit }, data) {
    commit('CHANGE_SETTING', data)
  },
  // 设置网页标题
  setTitle({ commit }, title) {
    state.title = title
    useDynamicTitle();
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}

