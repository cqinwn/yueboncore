import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

// 获取原型对象上的push函数
const originalPush = Router.prototype.push
// 修改原型对象中的push方法
Router.prototype.push = function push (location) {
  return originalPush.call(this, location).catch(err => err)
}
/* Layout */
import Layout from '@/layout'
// eslint-disable-next-line no-unused-vars
import ParentView from '@/components/ParentView'

/**
 * 所有人都可以访问的路由
 */
export const constantRoutes = [
  {
    path: '/redirect',
    component: Layout,
    hidden: true,
    children: [
      {
        path: '/redirect/:path(.*)',
        component: (resolve) => require(['@/views/redirect/index'], resolve)
      }
    ]
  },
  {
    path: '/login',
    name: 'login',
    component: (resolve) => require(['@/views/login/index'], resolve),
    hidden: true
  },
  {
    path: '/register',
    name: 'register',
    component: (resolve) => require(['@/views/register/index'], resolve),
    hidden: true
  },
  {
    path: '/',
    redirect: '/dashboard',
    component: Layout,
    children: [{
      path: 'dashboard',
      name: 'Dashboard',
      component: (resolve) => require(['@/views/dashboard/index'], resolve),
      meta: { title: '控制台', icon: 'dashboard', affix: true }
    }]
  },
  {
    path: '/usercenter',
    redirect: '/usercenter/index',
    component: Layout,
    meta: { title: '个人中心', icon: 'my' },
    children: [{
      path: '/usercenter/index',
      name: 'Usercenter',
      component: (resolve) => require(['@/views/usercenter/index'], resolve),
      meta: { title: '个人信息', icon: 'card' }
    },
    {
      path: '/usercenter/modify',
      name: 'Usercentermodify',
      component: (resolve) => require(['@/views/usercenter/modify'], resolve),
      meta: { title: '修改密码', icon: 'new-pwd' }
    }]
  }

  // 404 page must be placed at the end !!!
  // { path: '*', redirect: '/404', hidden: true }
]

const createRouter = () => new Router({
  scrollBehavior: () => ({ y: 0 }),
  routes: constantRoutes
})

const router = createRouter()

// Detail see: https://github.com/vuejs/vue-router/issues/1234#issuecomment-357941465
export function resetRouter () {
  const newRouter = createRouter()
  router.matcher = newRouter.matcher // reset router
}
export default router
