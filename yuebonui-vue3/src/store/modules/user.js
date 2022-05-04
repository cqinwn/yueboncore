import { login, logout, refreshToken, getListMeunFuntionBymeunCode, sysConnect, getUserInfo } from '@/api/basebasic'
import { getToken, setToken, removeToken } from '@/utils/auth'
import defAva from '@/assets/images/profile.jpg'
import defaultSettings from '@/settings'

const user = {
  state: {
    token: getToken(),
    name: '',
    avatar: '',
    roles: [],
    permissions: [],
    subSystem: [],
    activeSystemName: [],
    menus: [], 
  },

  mutations: {
    SET_TOKEN: (state, token) => {
      state.token = token
    },
    SET_NAME: (state, name) => {
      state.name = name
    },
    SET_AVATAR: (state, avatar) => {
      state.avatar = avatar
    },
    SET_ROLES: (state, roles) => {
      state.roles = roles
    },
    SET_PERMISSIONS: (state, permissions) => {
      state.permissions = permissions
    },
    SET_SUBSYSTEM: (state, subSystem) => {
      state.subSystem = subSystem
    },
    SET_ACTIVESYSTEMNAME: (state, activeSystemName) => {
      state.activeSystemName = activeSystemName
    },
    SET_MENUS: (state, menus) => {
      state.menus = menus
    }
  },

  actions: {
    // 登录
    Login({ commit }, loginInfo) {
      const username = loginInfo.username.trim()
      const password = loginInfo.password
      const vcode = loginInfo.vcode
      const verifyCodeKey = loginInfo.verifyCodeKey
      return new Promise((resolve, reject) => {
        login({ username: username, password: password, vcode: vcode, vkey: verifyCodeKey, appId: loginInfo.appId, systemCode: loginInfo.systemCode }).then(response => {
          const data = response.ResData
          setToken(data.AccessToken)
          commit('SET_TOKEN', data.AccessToken)
          resolve()
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 获取用户信息
    GetInfo({ commit, state }) {
      return new Promise((resolve, reject) => {
        getUserInfo().then(res => {
          if (res.Success) {
            const user = res.ResData
            const avatar = user.HeadIcon === null ? defAva : defaultSettings.fileUrl + user.HeadIcon
            //commit('SET_TEMPNAME', user.Account)
            localStorage.setItem("layout-setting", user.UserTheme);
            commit('SET_AVATAR', avatar)
            commit('SET_ROLES', user.Role)
            commit('SET_SUBSYSTEM', user.SubSystemList)
            commit('SET_ACTIVESYSTEMNAME', user.ActiveSystem)
            commit('SET_MENUS', user.MenusRouter)
            commit('SET_NAME', user.Account)
            commit('SET_PERMISSIONS', user.Modules)
          }
          resolve(res)
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 退出系统
    LogOut({ commit, state }) {
      return new Promise((resolve, reject) => {
        logout(state.token).then(() => {
          commit('SET_TOKEN', '')
          commit('SET_ROLES', [])
          commit('SET_PERMISSIONS', [])
          removeToken()
          resolve()
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 前端 登出
    FedLogOut({ commit }) {
      return new Promise(resolve => {
        commit('SET_TOKEN', '')
        removeToken()
        resolve()
      })
    },
    // 刷新 token
    ResetToken({ commit }) {
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
    },
    // 系统切换
    sysConnetLogin({ commit }, userInfo) {
      return new Promise((resolve, reject) => {
        sysConnect(userInfo).then(response => {
          const data = response.ResData
          commit('SET_TOKEN', data.AccessToken)
          setToken(data.AccessToken)
          resolve(response)
        }).catch(error => {
          reject(error)
        })
      })
    }
  }
}

export default user
