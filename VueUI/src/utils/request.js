import axios from 'axios'
import router from '../router'

import { MessageBox, Message } from 'element-ui'
import store from '@/store'
import { getToken } from '@/utils/auth'
import { sign, GetRandomString } from '@/utils/yuebon'

// create an axios instance
const service = axios.create({
  baseURL: process.env.VUE_APP_BASE_API,
  timeout: 10000 // request timeout
})

service.defaults.headers.post['Content-Type'] = 'application/json;charset=UTF-8'
// request拦截器
service.interceptors.request.use(
  config => {
    if (config.headers['Content-Type'] === undefined) { config.headers['Content-Type'] = 'application/json;charset=UTF-8' }
    const token = getToken()
    if (token) {
      config.headers['Authorization'] = 'Bearer ' + token
    }
    // 如果接口需要签名, 则通过请求时,headers中传递sign参数true
    const iSSign = config.headers['sign']
    if (iSSign || iSSign === undefined) {
      const timeStamp = new Date().getTime().toString().substr(0, 10)
      const nonce = GetRandomString()
      config.headers['appId'] = store.getters.appId
      config.headers['nonce'] = nonce
      config.headers['timeStamp'] = timeStamp
      config.headers['signature'] = sign(config, nonce, timeStamp, store.getters.appSecret)
    }
    return config
  },
  error => {
    // do something with request error
    return Promise.reject(error)
  }
)

// response interceptor
service.interceptors.response.use(
  response => {
    const res = response.data
    if (res.ErrCode !== '0') {
      if (res.ErrCode === '40005') { // 超时自动刷新token
        store.dispatch('user/resetToken').then((res) => {
          location.reload()
        })
      } else if (res.ErrCode === '40006') {
        router.push({
          path: '/403',
          query: {
            redirect: router.currentRoute.fullPath
          }
        }).catch(() => { })
      } else if (res.ErrCode === '40000' || res.ErrCode === '40008') {
        // to re-login
        MessageBox.confirm('登录状态已过期，您可以继续留在该页面，或者重新登录', '系统提示', {
          confirmButtonText: '重新登录',
          cancelButtonText: '取消',
          type: 'warning'
        }).then((res) => {
          store.dispatch('user/resetToken').then((res) => {
            location.reload()
          })
        })
        return res
      } else {
        Message({
          message: res.ErrMsg || 'Error',
          type: 'error',
          duration: 5 * 1000
        })
        return Promise.reject(new Error(res.ErrMsg))
      }
    } else {
      return res
    }
  },
  error => {
    console.log('err' + error)
    let { message } = error
    if (message === 'Network Error') {
      message = '后端接口连接异常'
    } else if (message.includes('timeout')) {
      message = '系统接口请求超时'
    } else if (message.includes('Request failed with status code')) {
      message = '系统接口' + message.substr(message.length - 3) + '异常'
    }
    Message({
      message: error.message,
      type: 'error',
      duration: 5 * 1000
    })
    return Promise.reject(error)
  }
)

export default service
