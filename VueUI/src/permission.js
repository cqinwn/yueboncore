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

const whiteList = ['/login', '/register'] // no redirect whitelist
var menuList = []
let flag = 0// 刷新不空白
router.beforeEach(async (to, from, next) => {
  // start progress bar
  NProgress.start()
  // set page title
  document.title = getPageTitle(to.meta.title)
  // determine whether the user has logged in
  const hasToken = getToken()
  if (hasToken) {
    if (to.path === '/login') {
      next({ path: '/' })
      NProgress.done()
    } else {
      try {
        const hasGetUserInfo = store.getters.name
        if (hasGetUserInfo && hasGetUserInfo !== 'null') {
          if (to.meta.funcode !== '' && (to.meta.funcode !== undefined && to.meta.funcode !== 'undefined')) {
            getListMeunFuntionBymeunCode(to.meta.funcode).then(res => {
              localStorage.setItem('yueboncurrentfuns', JSON.stringify(res.ResData))
            })
          }
        }
        if (flag === 0) {
          initMenuRoutes()
          flag++
          next({
            ...to,
            replace: true
          }) // hack方法 确保addRoutes已完成 ,set the replace
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

function convertTree (routers) {
  routers.forEach(r => {
    menuList.forEach((m, i) => {
      if (m.ParentId && m.ParentId === r.meta.id) {
        if (!r.children) r.children = []
        const menu = {
          path: m.UrlAddress,
          name: m.EnCode,
          component: _import(`${m.UrlAddress}`),
          meta: { id: m.Id, title: m.FullName, icon: m.Icon, funcode: m.EnCode, noCache: false }
        }
        r.children.push(menu)
      }
    })
    if (r.children) convertTree(r.children)
  })
}

function initMenuRoutes () {
  menuList = store.getters.menus
  const menuRouters = [] // 定义一个空数组，这个是用来装真正路由数据的
  if (menuList != null) {
    // 先取出根节点，没有父id的就是根节点
    menuList.forEach((m, i) => {
      if (m.ParentId === '') {
        const module = {
          path: m.UrlAddress,
          name: m.EnCode,
          component: Layout,
          redirect: m.UrlAddress + '/index',
          meta: { id: m.Id, title: m.FullName, icon: m.Icon, funcode: m.EnCode, noCache: false }
        }
        menuRouters.push(module)
      }
    })
    convertTree(menuRouters) // 用递归填充
  }
  const unfound = { path: '*', redirect: '/404', hidden: true }
  menuRouters.push(unfound)
  router.addRoutes(menuRouters) // 2.动态添加路由
  store.getters.addRoutes = menuRouters // 3.将路由数据传递给全局变量，做侧边栏菜单渲染工作
}
