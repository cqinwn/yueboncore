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
var getRouter// 用来获取后台拿到的路由
var menuList = []
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
      console.log('hasGetUserInfo== :' + hasGetUserInfo)
      if (hasGetUserInfo && hasGetUserInfo !== 'null') {
        console.log('hasGetUserInfo  in :')
        if (to.meta.funcode === '' || to.meta.funcode === undefined) {
          console.log('funcode out= :' + to.meta.funcode)
        } else {
          getListMeunFuntionBymeunCode(to.meta.funcode).then(res => {
            localStorage.setItem('yueboncurrentfuns', JSON.stringify(res.ResData))
          })
        }
        updateRoutes()
        next()
        // next({ path: to.path })
      } else {
        try {
          // get user info
          store.dispatch('user/getInfo')
          if (!getRouter) {
            menuList = store.getters.menus

            const menuRouters = [] // 定义一个空数组，这个是用来装真正路由数据的
            // 先取出根节点，没有父id的就是根节点
            menuList.forEach((m, i) => {
              if (m.ParentId === '') {
                const module = {
                  path: m.UrlAddress,
                  name: m.EnCode,
                  component: Layout,
                  redirect: m.UrlAddress + '/index',
                  meta: { id: m.Id, title: m.FullName, icon: m.Icon, funcode: m.EnCode }
                }
                menuRouters.push(module)
              }
            })
            convertTree(menuRouters) // 用递归填充
            router.addRoutes(menuRouters) // 2.动态添加路由
            store.getters.addRoutes = menuRouters // 3.将路由数据传递给全局变量，做侧边栏菜单渲染工作
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
          next(`/login?redirect=${to.path}`)
          NProgress.done()
        }
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

function convertTree(routers) {
  routers.forEach(r => {
    menuList.forEach((m, i) => {
      if (m.ParentId && m.ParentId === r.meta.id) {
        if (!r.children) r.children = []
        const menu = {
          path: m.UrlAddress,
          name: m.EnCode,
          component: _import(`${m.UrlAddress}`),
          meta: { id: m.Id, title: m.FullName, icon: m.Icon, funcode: m.EnCode }
        }
        r.children.push(menu)
      }
    })
    if (r.children) convertTree(r.children)
  })
}

function updateRoutes() {
  console.log('3 store.getters.menus:'+JSON.stringify(store.getters.menus))
  menuList = store.getters.menus
  const menuRouters = [] // 定义一个空数组，这个是用来装真正路由数据的
  // 先取出根节点，没有父id的就是根节点
  menuList.forEach((m, i) => {

    if (m.ParentId === '') {//注意null值不是''
      const module = {
        path: m.UrlAddress,
        name: m.EnCode,
        component: Layout,
        redirect: m.UrlAddress + '/index',
        meta: { id: m.Id, title: m.FullName, icon: m.Icon, funcode: m.EnCode }
      }
      menuRouters.push(module)

    }
  })
  convertTree(menuRouters) // 用递归填充
  router.addRoutes(menuRouters) // 2.动态添加路由
  store.getters.addRoutes = menuRouters // 3.将路由数据传递给全局变量，做侧边栏菜单渲染工作
  getRouter = true
}
