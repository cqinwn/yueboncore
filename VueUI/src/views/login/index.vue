<template>
  <div class="login-container">
    <el-form
      ref="loginForm"
      :model="loginForm"
      :rules="loginRules"
      class="login-form"
      auto-complete="on"
      label-position="left"
    >
      <div class="title-container">
        <h3 class="title">{{ softName }}</h3>
      </div>

      <div class="logo-container">
        <img :src="companyLogo">
      </div>
      <el-form-item prop="username">
        <span class="svg-container">
          <svg-icon icon-class="user" />
        </span>
        <el-input
          ref="username"
          v-model="loginForm.username"
          placeholder="登录账号"
          name="username"
          type="text"
          tabindex="1"
          auto-complete="on"
        />
      </el-form-item>

      <el-form-item prop="password">
        <span class="svg-container">
          <svg-icon icon-class="password" />
        </span>
        <el-input
          :key="passwordType"
          ref="password"
          v-model="loginForm.password"
          :type="passwordType"
          placeholder="密码"
          name="password"
          tabindex="2"
          auto-complete="on"
          @keyup.enter.native="handleLogin"
        />
        <span class="show-pwd" @click="showPwd">
          <svg-icon :icon-class="passwordType === 'password' ? 'eye' : 'eye-open'" />
        </span>
      </el-form-item>

      <el-button
        :loading="loading"
        type="primary"
        style="width:100%;margin-bottom:30px;"
        @click.native.prevent="handleLogin"
      >登录</el-button>

      <div class="tips" />
    </el-form>
    <div id="footer" class="footer" role="contentinfo">
      <div class="footerNodelf text-secondary">
        <span>本软件使用权属于：{{ companyName }}</span>
      </div>
      <div class="footerNode text-secondary">
        <span v-html="copyRight">{{ copyRight }}</span>
      </div>
    </div>
  </div>
</template>

<script>
import { setToken } from '@/utils/auth'
import { getToken, getSysSetting } from '@/api/basebasic'

export default {
  name: 'Login',
  data() {
    const validateUsername = (rule, value, callback) => {
      if (value.length < 1) {
        callback(new Error('请输入登录账号！'))
      } else {
        callback()
      }
    }
    const validatePassword = (rule, value, callback) => {
      if (value.length < 6) {
        callback(new Error('请输入您的账号密码,且不小于6位！'))
      } else {
        callback()
      }
    }
    return {
      loginForm: {
        username: '',
        password: ''
      },
      loginRules: {
        username: [
          { required: true, trigger: 'blur', validator: validateUsername }
        ],
        password: [
          { required: true, trigger: 'blur', validator: validatePassword }
        ]
      },
      loading: false,
      passwordType: 'password',
      redirect: undefined,
      softName: '管理系统',
      companyLogo: '/assets/images/login-logo.png',
      companyName: '',
      copyRight: ''
    }
  },
  watch: {
    $route: {
      handler: function(route) {
        this.redirect = route.query && route.query.redirect
      },
      immediate: true
    }
  },
  created() {
    this.loadToken()
  },
  methods: {
    loadToken() {
      getToken().then(response => {
        setToken(response.ResData.AccessToken)
        getSysSetting().then(res => {
          this.softName = res.ResData.SoftName
          this.companyLogo = res.ResData.SysLogo
          this.companyName = res.ResData.CompanyName
          this.copyRight = res.ResData.CopyRight
        })
      })
    },
    showPwd() {
      if (this.passwordType === 'password') {
        this.passwordType = ''
      } else {
        this.passwordType = 'password'
      }
      this.$nextTick(() => {
        this.$refs.password.focus()
      })
    },
    handleLogin() {
      this.$refs.loginForm.validate(valid => {
        if (valid) {
          this.loading = true
          this.$store
            .dispatch('user/userlogin', this.loginForm)
            .then(res => {
              console.log(JSON.stringify(res))
              console.log('登录成功')
              this.$router.push({ path: this.redirect || '/' })
              this.loading = false
            })
            .catch(res => {
              console.log(JSON.stringify(res))
              console.log('登录失败')
              this.loading = false
            })
        } else {
          console.log('error submit!!')
          return false
        }
      })
    }
  }
}
</script>

<style lang="scss">
$bg: #283443;
$light_gray: rgb(100, 95, 95);
$cursor: #000000;

@supports (-webkit-mask: none) and (not (cater-color: $cursor)) {
  .login-container .el-input input {
    color: $cursor;
  }
}

/* reset element-ui css */
.login-container {
  .el-input {
    display: inline-block;
    height: 47px;
    width: 85%;

    input {
      background: transparent;
      border: 0px;
      -webkit-appearance: none;
      border-radius: 0px;
      padding: 12px 5px 12px 15px;
      color: #000000;
      height: 47px;
      caret-color: $cursor;

      &:-webkit-autofill {
        box-shadow: 0 0 0px 1000px #ffffff inset !important;
        -webkit-text-fill-color: $cursor !important;
      }
    }
  }

  .el-form-item {
    border: 1px solid rgba(7, 7, 7, 0.1);
    background: rgba(255, 255, 255, 0.8);
    border-radius: 5px;
    color: #454545;
  }
}
</style>

<style lang="scss" scoped>
$dark_gray: #5e6163;
$light_gray: #eee;

.login-container {
  min-height: 100%;
  width: 100%;
  background-image: url("~@/assets/images/convergedbg_v2.jpg");
  overflow: hidden;

  .login-form {
    position: relative;
    width: 369px;
    max-width: 100%;
    margin: 15% 10% 10% 65%;
    overflow: hidden;
    background: #fff;
    border-radius: 10px;
    padding:0 20px;
  }

  .tips {
    font-size: 14px;
    color: #fff;
    margin-bottom: 10px;

    span {
      &:first-of-type {
        margin-right: 16px;
      }
    }
  }

  .svg-container {
    padding: 6px 5px 6px 15px;
    color: $dark_gray;
    vertical-align: middle;
    width: 30px;
    display: inline-block;
  }

  .title-container {
    position: relative;
    .title {
      font-size: 26px;
      color: #000000;
      margin: 10px auto;
      text-align: center;
      font-weight: bold;
    }
  }
  .logo-container {
    position: relative;
    margin-bottom: 10px;
  }
  .show-pwd {
    position: absolute;
    right: 10px;
    top: 7px;
    font-size: 16px;
    color: #000000;
    cursor: pointer;
    user-select: none;
  }

  .footer {
    position: fixed;
    bottom: 0;
    width: 100%;
    overflow: visible;
    z-index: 99;
    clear: both;
    background-color: rgba(0, 0, 0, 0.8);
    filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0,startColorstr='#99000000',endColorstr='#99000000');
  }
  div.footerNodelf {
    float: left;
  }

  div.footerNode {
    margin: 0;
    float: right;
  }
  .text-secondary {
    color: #505050;
    color: rgba(170, 170, 170, 0.6);
    font-size: 13px;
    line-height: 25px;
  }
}
</style>
