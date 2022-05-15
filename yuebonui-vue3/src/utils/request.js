import axios from 'axios'
import store from '@/store'
import { ElNotification, ElMessageBox, ElMessage, ElLoading } from 'element-plus'
import { getToken } from '@/utils/auth'
import { sign, GetRandomString } from '@/utils/yuebon'

// 是否显示重新登录
export let isRelogin = { show: false };
// create an axios instance
const service = axios.create({
  baseURL: import.meta.env.VITE_APP_BASE_API,
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

/**
 * 
 * 响应拦截
 */
service.interceptors.response.use(
  response => {
    const res = response.data
    if (res.ErrCode !== '0') {
      if (res.ErrCode === '40005') { // 超时自动刷新token
        store.dispatch('ResetToken').then((res) => {
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
        if (!isRelogin.show) {
          isRelogin.show = true;
          // to re-login
          ElMessageBox.confirm('登录状态已过期，您可以继续留在该页面，或者重新登录', '系统提示', {
            confirmButtonText: '重新登录',
            cancelButtonText: '取消',
            type: 'warning'
          }).then((res) => {
            isRelogin.show = false;
            store.dispatch('LogOut').then(() => {
              location.href = '/index';
            })
          }).catch(() => {
            isRelogin.show = false;
          });
        }
        return Promise.reject('无效的会话，或者会话已过期，请重新登录。')
        //return res
      } else {
        isRelogin.show = false;
        ElMessage({
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
    let { message } = error
    if (message === 'Network Error') {
      message = '后端接口连接异常'
    } else if (message.includes('timeout')) {
      message = '系统接口请求超时'
    } else if (message.includes('Request failed with status code')) {
      message = '系统接口' + message.substr(message.length - 3) + '异常'
    }

    ElMessage({
      message: error.message,
      type: 'error',
      duration: 5 * 1000
    })
    return Promise.reject(error)
  }
)

export default service
