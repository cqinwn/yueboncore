import router from './router'
import store from './store'
import { Message } from 'element-ui'
import NProgress from 'nprogress' // progress bar
import 'nprogress/nprogress.css' // progress bar style
import { getToken } from '@/utils/auth' // get token from cookie
import getPageTitle from '@/utils/get-page-title'
const _import = require('./router/_import_' + process.env.NODE_ENV) // 获取组件的方法
import Layout from '@/layout'
import { getListMeunFuntionBymeunCode } from '@/api/basebasic'
NProgress.configure({ showSpinner: false }) // NProgress Configuration

const whiteList = ['/login'] // no redirect whitelist
var getRouter = null // 用来获取后台拿到的路由

router.beforeEach(async(to, from, next) => {
  // start progress bar
  NProgress.start()

  // set page title
  document.title = getPageTitle(to.meta.title)

  // determine whether the user has logged in
  const hasToken = getToken()

  if (hasToken) {
    console.log('funcode== :' + to.meta.funcode)
    console.log('to.path :' + to.path)
    if (to.path === '/login') {
      // if is logged in, redirect to the home page
      next({ path: '/' })
      NProgress.done()
    } else {
      const hasGetUserInfo = store.getters.name
      if (hasGetUserInfo) {
        if (to.meta.funcode === '' || to.meta.funcode === undefined) {
          console.log('funcode== :' + to.meta.funcode)
        } else {
          getListMeunFuntionBymeunCode(to.meta.funcode).then(res => {
            localStorage.setItem('yueboncurrentfuns', JSON.stringify(res.ResData))
          })
        }
        next()
      } else {
        try {
          // get user info
          // await store.dispatch('user/getInfo')
          if (!getRouter) {
            console.log('no hasGetUserInf ostore.getters.menus:' + JSON.stringify(store.getters.menus))
            if (store.getters.menus.length < 1) {
              store.getters.addRoutes = []
              next()
            }
            const menus = filterAsyncRouter(store.getters.menus) // 1.过滤路由
            console.log('filterAsyncRouter .menus:' + JSON.stringify(menus))
            router.addRoutes(menus) // 2.动态添加路由
            store.getters.addRoutes = menus // 3.将路由数据传递给全局变量，做侧边栏菜单渲染工作
            // 不加这个判断，路由会陷入死循环
            getRouter = true
            next({
              ...to,
              replace: true
            }) // hack方法 确保addRoutes已完成 ,set the replace
          }
        } catch (error) {
          // remove token and go to login page to re-login
          await store.dispatch('user/resetToken')
          Message.error(error || 'Has Error')
          next('/login?redirect=${to.path}')
          NProgress.done()
        }
      }
    }
  } else {
    /* has no token*/

    if (whiteList.indexOf(to.path) !== -1) {
      // in the free login whitelist, go directly
      next()
    } else {
      // other pages that do not have permission to access are redirected to the login page.
      next('/login?redirect=${to.path}')
      NProgress.done()
    }
  }
})

router.afterEach(() => {
  // finish progress bar
  NProgress.done()
})

// 遍历后台传来的路由字符串，转换为组件对象
function filterAsyncRouter(asyncRouterMap) {
  const accessedRouters = asyncRouterMap.filter(route => {
    const value = route.component
    if (value) {
      if (value === 'Layout') { // Layout组件特殊处理
        route.component = Layout
      } else {
        route.component = _import(route.component) // 导入组件
        // function component(resolve) {
        //   _import(['@/views' + value + '.vue'], resolve)
        // }
      }
    }
    if (route.children && route.children.length > 0) {
      route.children = filterAsyncRouter(route.children)
    }
    return true
  })
  return accessedRouters
}
