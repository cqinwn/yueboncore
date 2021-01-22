import { getToken, setToken, removeToken } from '@/utils/auth'
import { resetRouter } from '@/router'
import { login, logout, refreshToken, getListMeunFuntionBymeunCode, sysConnect, getUserInfo } from '@/api/basebasic'
const getDefaultState = () => {
  return {
    token: getToken(),
    name: '',
    avatar: '',
    subSystem: [],
    activeSystemName: [],
    menus: [], // JSON.parse(localStorage.getItem('nowmenus')),
    roles: [],
    permissions: []
  }
}

const state = getDefaultState()

const mutations = {
  RESET_STATE: (state) => {
    Object.assign(state, getDefaultState())
  },
  SET_TOKEN: (state, token) => {
    state.token = token
  },
  SET_NAME: (state, name) => {
    state.name = name
  },
  SET_ROLES: (state, roles) => {
    state.roles = roles
  },
  SET_TEMPNAME: (state, name) => {
    state.name = name
  },
  SET_AVATAR: (state, avatar) => {
    state.avatar = avatar
  },
  SET_SUBSYSTEM: (state, subSystem) => {
    state.subSystem = subSystem
  },
  SET_ACTIVESYSTEMNAME: (state, activeSystemName) => {
    state.activeSystemName = activeSystemName
  },
  SET_MENUS: (state, menus) => {
    state.menus = menus
  },
  SET_PERMISSIONS: (state, permissions) => {
    state.permissions = permissions
  }
}

const actions = {
  userlogin({ commit }, userInfo) {
    const { username, password, vcode, verifyCodeKey } = userInfo
    return new Promise((resolve, reject) => {
      login({ username: username.trim(), password: password, vcode: vcode, vkey: verifyCodeKey, appId: 'system', systemCode: 'openauth' }).then(response => {
        const data = response.ResData
        setToken(data.AccessToken)
        commit('SET_TOKEN', data.AccessToken)
        resolve(response)
      }).catch(error => {
        reject(error)
      })
    })
  },
  getUserInfo({ commit }) {
    return new Promise((resolve, reject) => {
      getUserInfo().then(response => {
        const data = response.ResData
        const avatar = data.HeadIcon === '' ? require('@/assets/images/profile.jpg') : process.env.VUE_APP_BASE_API + data.HeadIcon
        commit('SET_TEMPNAME', data.Account)
        commit('SET_AVATAR', avatar)
        commit('SET_ROLES', data.Role)
        commit('SET_SUBSYSTEM', data.SubSystemList)
        commit('SET_ACTIVESYSTEMNAME', data.ActiveSystem)
        commit('SET_MENUS', data.MenusRouter)
        commit('SET_NAME', data.Account)
        commit('SET_PERMISSIONS', data.Modules)
        resolve(response)
      }).catch(error => {
        reject(error)
      })
    })
  },
  // 系统切换
  sysConnetLogin({ commit }, userInfo) {
    return new Promise((resolve, reject) => {
      sysConnect(userInfo).then(response => {
        const data = response.ResData
        commit('SET_TOKEN', data.AccessToken)
        setToken(data.AccessToken)
        commit('SET_TEMPNAME', data.Account)
        commit('SET_ROLES', data.Role)
        commit('SET_AVATAR', data.HeadIcon)
        commit('SET_SUBSYSTEM', data.SubSystemList)
        commit('SET_ACTIVESYSTEMNAME', data.ActiveSystem)
        commit('SET_MENUS', data.MenusRouter)
        commit('SET_NAME', data.Account)
        commit('SET_PERMISSIONS', JSON.stringify(data.Modules))
        resolve(response)
      }).catch(error => {
        reject(error)
      })
    })
  },
  // user logout
  logout({ commit, state }) {
    return new Promise((resolve, reject) => {
      logout(state.token).then(() => {
        removeToken() // must remove  token  first
        localStorage.removeItem('username')
        localStorage.removeItem('useravatar')
        localStorage.removeItem('usersubSystem')
        localStorage.removeItem('nowmenus')
        resetRouter()
        commit('RESET_STATE')
        resolve()
      }).catch(error => {
        removeToken() // must remove  token  first
        localStorage.removeItem('username')
        localStorage.removeItem('useravatar')
        localStorage.removeItem('usersubSystem')
        localStorage.removeItem('nowmenus')
        resetRouter()
        commit('RESET_STATE')
        reject(error)
      })
    })
  },
  // 刷新 token
  resetToken({ commit }) {
    const data = {
      'token': getToken()
    }
    removeToken() // must remove  token  first
    return new Promise(resolve => {
      refreshToken(data).then(res => {
        const data = res.ResData
        commit('SET_TOKEN', data.AccessToken)
      })
      commit('RESET_STATE')
      resolve()
    })
  },
  userNowMeunsFun(encode) {
    const code = encode
    return new Promise((resolve, reject) => {
      getListMeunFuntionBymeunCode({ enCode: code }).then(response => {
        const data = response.ResData
        localStorage.setItem('yuebon_currentmenus', JSON.stringify(data))
        resolve(response)
      }).catch(error => {
        reject(error)
      })
    })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}

