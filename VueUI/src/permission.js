import router from './router'
import store from './store'
import { Message } from 'element-ui'
import NProgress from 'nprogress' // progress bar
import 'nprogress/nprogress.css' // progress bar style
import { getToken } from '@/utils/auth' // get token from cookie
import getPageTitle from '@/utils/get-page-title'
NProgress.configure({ showSpinner: true }) // NProgress Configuration

const whiteList = ['/login', '/register'] // no redirect whitelist
router.beforeEach(async(to, from, next) => {
  NProgress.start()
  document.title = getPageTitle(to.meta.title)
  const hasToken = getToken()
  if (hasToken) {
    if (to.path === '/login') {
      next({ path: '/' })
      NProgress.done()
    } else {
      try {
        if (store.getters.roles.length === 0) {
          await store.dispatch('user/getUserInfo').then(res => {
            if (res.Success) {
              store.dispatch('settings/loadUserSettingTheme', res.ResData.UserTheme).then(res => { })
              store.dispatch('GenerateRoutes', store.getters.menus).then(accessRoutes => {
                // 根据roles权限生成可访问的路由表
                router.addRoutes(accessRoutes) // 动态添加可访问路由表
                next({ ...to, replace: true }) // hack方法 确保addRoutes已完成
              })
            }
          }).catch(err => {
            Message.error({
              message: err || '出现错误，请稍后再试'
            })
            store.dispatch('user/logout').then(res => {
              console.log('logout:' + JSON.stringify(res))
              // Message.error(err)
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
