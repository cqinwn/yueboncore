<template>
  <div class="login-container">
    <el-form
      v-if="isShow"
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
          <i class="el-icon-user" />
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
          <i class="iconfont icon-auth" />
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
          <svg-icon
            :icon-class="passwordType === 'password' ? 'eye' : 'eye-open'"
          />
        </span>
      </el-form-item>

      <el-form-item prop="vcode">
        <span class="svg-container">
          <i class="iconfont icon-approve" />
        </span>
        <el-input
          ref="vcode"
          v-model="loginForm.vcode"
          placeholder="验证码"
          name="vcode"
          type="text"
          tabindex="3"
          maxlength="4"
          auto-complete="on"
          style="width:150px; "
        />
        <div style="margin-top:8px; display:inline; float:right;margin-right:10px;">
          <img :src="verifyCodeUrl" style="cursor: pointer;vertical-align: middle;" alt="看不清？点击更换" @click="getLoginVerifyCode">
        </div>
      </el-form-item>
      <el-button
        :loading="loading"
        type="primary"
        style="width: 100%; margin-bottom: 30px"
        @click.native.prevent="handleLogin"
      >登录</el-button>
      <div style="text-align:right;">
        没有账号？<router-link :to="{name:'register'}">点此注册</router-link>
      </div>
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
import { getToken, getSysSetting, getVerifyCode } from '@/api/basebasic'
import { Loading } from 'element-ui'
export default {
  name: 'Login',
  data () {
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
        password: '',
        vcode: '',
        verifyCodeKey: ''
      },
      loginRules: {
        username: [
          { required: true, trigger: 'blur', validator: validateUsername }
        ],
        password: [
          { required: true, trigger: 'blur', validator: validatePassword }
        ],
        vcode: [
          { required: true, message: '请输入验证码', trigger: 'blur' },
          { min: 4, max: 4, message: '长度4字符', trigger: 'blur' }
        ]
      },
      loading: false,
      passwordType: 'password',
      verifyCodeUrl: '',
      redirect: undefined,
      softName: '管理系统',
      companyLogo: '/assets/images/login-logo.png',
      companyName: '',
      copyRight: '',
      pageLoading: '',
      isShow: false
    }
  },
  watch: {
    $route: {
      handler: function (route) {
        this.redirect = route.query && route.query.redirect
      },
      immediate: true
    }
  },
  created () {
    var loadop = {
      lock: true,
      text: '正在初始化...',
      spinner: 'el-icon-loading',
      background: 'rgba(0, 0, 0, 0.7)'
    }
    this.pageLoading = Loading.service(loadop)
    this.loadToken()
    this.getLoginVerifyCode()
  },
  methods: {
    loadToken () {
      getToken().then(response => {
        setToken(response.ResData.AccessToken)
        getSysSetting().then(res => {
          this.softName = res.ResData.SoftName
          this.companyLogo = res.ResData.SysLogo
          this.companyName = res.ResData.CompanyName
          this.copyRight = res.ResData.CopyRight

          this.pageLoading.close()
          this.isShow = true
        })
      })
    },
    showPwd () {
      if (this.passwordType === 'password') {
        this.passwordType = ''
      } else {
        this.passwordType = 'password'
      }
      this.$nextTick(() => {
        this.$refs.password.focus()
      })
    },
    handleLogin () {
      this.$refs.loginForm.validate(valid => {
        if (valid) {
          this.loading = true
          this.$store
            .dispatch('user/userlogin', this.loginForm)
            .then(res => {
              // this.$router.push({ path: this.redirect || '/' })
              this.$router.push('/')
              this.loading = false
            })
            .catch(res => {
              this.loading = false
            })
        } else {
          return false
        }
      })
    },
    // 获取验证码
    async getLoginVerifyCode () {
      this.loginForm.vcode = ''
      const res = await getVerifyCode()
      if (res.Success) {
        this.verifyCodeUrl = 'data:image/png;base64,' + res.ResData.Img
        this.loginForm.verifyCodeKey = res.ResData.Key
      }
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
  height: 100%;
  width: 100%;
  background-image: url("~@/assets/images/convergedbg_v2.jpg");
  overflow: hidden;
  background-size:100% 100%;

  .login-form {
    position: relative;
    width: 369px;
    max-width: 100%;
    margin: 10% auto;
    overflow: hidden;
    background: #fff;
    border-radius: 10px;
    padding: 0 20px;
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
