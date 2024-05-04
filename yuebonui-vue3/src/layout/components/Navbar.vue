<template>
  <div class="navbar">
    <hamburger id="hamburger-container" :is-active="getters.sidebar.opened" class="hamburger-container" @toggleClick="toggleSideBar" />
    <breadcrumb id="breadcrumb-container" class="breadcrumb-container" v-if="!$store.state.settings.topNav" />
    <top-nav id="topmenu-container" class="topmenu-container" v-if="$store.state.settings.topNav" />

    <div class="right-menu">
      <template v-if="getters.device !== 'mobile'">
        <el-tooltip content="搜索菜单" effect="dark" placement="bottom">
        <header-search id="header-search" class="right-menu-item" />
        </el-tooltip>

        <el-tooltip content="文档地址" effect="dark" placement="bottom">
          <ruo-yi-doc id="ruoyi-doc" class="right-menu-item hover-effect" />
        </el-tooltip>

        <screenfull id="screenfull" class="right-menu-item hover-effect" />

        <el-tooltip content="布局大小" effect="dark" placement="bottom">
          <size-select id="size-select" class="right-menu-item hover-effect" />
        </el-tooltip>
        <el-dropdown class="el-dropdown-link right-menu-item" trigger="click" @command="handlerSysType">
          <div class="subSystem">
            您处在：{{ activeSystemName }}(切换)
            <i class="el-icon-arrow-down el-icon--right" />
          </div>
          <template #dropdown>
          <el-dropdown-menu>
            <a v-for="item in subSystem" :key="item.Id" href="#">
              <el-dropdown-item :command="item.EnCode">{{ item.FullName }}</el-dropdown-item>
            </a>
          </el-dropdown-menu> 
          </template>
        </el-dropdown>
      </template>
      <div class="avatar-container">
        <el-dropdown @command="handleCommand" class="right-menu-item hover-effect" trigger="click">
          <div class="avatar-wrapper">
            {{ userAccount }}<el-icon><caret-bottom /></el-icon>
          </div>
          <template #dropdown>
            <el-dropdown-menu>
              <router-link to="/usercenter/index">
                <el-dropdown-item>个人中心</el-dropdown-item>
              </router-link>
              <el-dropdown-item command="setLayout">
                <span>布局设置</span>
              </el-dropdown-item>
              <el-dropdown-item divided command="logout">
                <span>退出登录</span>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ElMessageBox } from 'element-plus'
import Breadcrumb from '@/components/Breadcrumb'
import TopNav from '@/components/TopNav'
import Hamburger from '@/components/Hamburger'
import Screenfull from '@/components/Screenfull'
import SizeSelect from '@/components/SizeSelect'
import HeaderSearch from '@/components/HeaderSearch'
import RuoYiDoc from '@/components/Yuebon/Doc'
import { yuebonConnecSys } from '@/api/basebasic'

const store = useStore();

const activeSystemName=store.getters.activeSystemName
const subSystem = store.getters.subSystem
const userAccount =store.getters.name
const getters = computed(() =>store.getters);

function toggleSideBar() {
  store.dispatch('app/toggleSideBar')
}

function handleCommand(command) {
  switch (command) {
    case "setLayout":
      setLayout();
      break;
    case "logout":
      logout();
      break;
    default:
      break;
  }
}

function logout() {
  ElMessageBox.confirm('确定注销并退出系统吗？', '提示', {
    confirmButtonText: '确定',
    cancelButtonText: '取消',
    type: 'warning'
  }).then(() => {
    store.dispatch('LogOut').then(() => {
      location.href = '/index';
    })
  }).catch(() => { });
}

const emits = defineEmits(['setLayout'])
function setLayout() {
  emits('setLayout');
}

function handlerSysType(command) {
  var data = {
    systype: command
  }
  yuebonConnecSys(data).then(res => {
    if (res.Success) {
      window.location.href = res.ResData
    }
  })
}
</script>

<style lang='scss' scoped>
.navbar {
  height: 50px;
  overflow: hidden;
  position: relative;
  background: #fff;
  box-shadow: 0 1px 4px rgba(0, 21, 41, 0.08);

  .hamburger-container {
    line-height: 46px;
    height: 100%;
    float: left;
    cursor: pointer;
    transition: background 0.3s;
    -webkit-tap-highlight-color: transparent;

    &:hover {
      background: rgba(0, 0, 0, 0.025);
    }
  }

  .breadcrumb-container {
    float: left;
  }

  .topmenu-container {
    position: absolute;
    left: 50px;
  }

  .errLog-container {
    display: inline-block;
    vertical-align: top;
  }

  .right-menu {
    float: right;
    height: 100%;
    line-height: 50px;
    display: flex;

    &:focus {
      outline: none;
    }

    .el-dropdown-link {
      cursor: pointer;
    }
    .subSystem {
      font-size: 14px;
      vertical-align: middle;
      line-height: 40px;
      margin-top: 6px;
    }
    .right-menu-item {
      display: inline-block;
      padding: 0 8px;
      height: 100%;
      font-size: 18px;
      color: #5a5e66;
      vertical-align: text-bottom;

      &.hover-effect {
        cursor: pointer;
        transition: background 0.3s;

        &:hover {
          background: rgba(0, 0, 0, 0.025);
        }
      }
      
      .iconbuju{
        margin-right: 10px;
      }
      .bujutitle{
        margin-left: 10px;
      }
    }

    .avatar-container {
      margin-right: 20px;
      line-height: 46px;

      .avatar-wrapper {
        margin-top: 5px;
        position: relative;
        line-height: 46px;

        .user-avatar {
          cursor: pointer;
          width: 40px;
          height: 40px;
          border-radius: 10px;
        }

        i {
          cursor: pointer;
          position: absolute;
          right: -20px;
          top: 16px;
          font-size: 12px;
        }
      }
    }
  }
}
</style>
