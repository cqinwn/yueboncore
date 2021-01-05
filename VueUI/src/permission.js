import router from './router'
import store from './store'
import { Message } from 'element-ui'
import NProgress from 'nprogress' // progress bar
import 'nprogress/nprogress.css' // progress bar style
import { getToken } from '@/utils/auth' // get token from cookie
import getPageTitle from '@/utils/get-page-title'
import { getListMeunFuntionBymeunCode } from '@/api/basebasic'
NProgress.configure({ showSpinner: false }) // NProgress Configuration

let flag = 0// 刷新不空白
const whiteList = ['/login', '/register'] // no redirect whitelist
router.beforeEach(async (to, from, next) => {
  NProgress.start()
  document.title = getPageTitle(to.meta.title)
  const hasToken = getToken()
  if (hasToken) {
    if (to.path === '/login') {
      next({ path: '/' })
      NProgress.done()
    } else {
      try {
        const hasGetUserInfo = store.getters.name
        console.log('hasGetUserInfo:' + hasGetUserInfo)
        if (hasGetUserInfo && hasGetUserInfo !== 'null') {
          if (to.name !== '' && (to.name !== undefined && to.name !== 'undefined')) {
            getListMeunFuntionBymeunCode(to.name).then(res => {
              localStorage.setItem('yueboncurrentfuns', JSON.stringify(res.ResData))
            })
          }
        }
        if (flag === 0) {
          await store.dispatch('GenerateRoutes').then(accessRoutes => {
            // 根据roles权限生成可访问的路由表
            router.addRoutes(accessRoutes) // 动态添加可访问路由表
            flag++
            next({ ...to, replace: true }) // hack方法 确保addRoutes已完成
          }).catch(err => {
            store.dispatch('LogOut').then(() => {
              Message.error(err)
              next({ path: '/' })
            })
          })
        } else {
          next()
        }
      } catch (error) {
        await store.dispatch('user/resetToken')
        Message.error({
          message: error || '出现错误，请稍后再试'
        })
        next(`/login?redirect=${to.path}`)
        NProgress.done()
      }
    }
  } else {
    if (whiteList.indexOf(to.path) !== -1) {
      next()
    } else {
      next(`/login?redirect=${to.path}`)
      NProgress.done()
    }
  }
})

router.afterEach(() => {
  NProgress.done()
})
