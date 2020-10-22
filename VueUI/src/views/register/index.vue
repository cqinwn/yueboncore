<template>
  <div class="registWrapper">

    <div class="header">
      <div class="logo-container">
        <img :src="companyLogo">
      </div>
    </div>
    <div class="register-container">
      <div class="title-container">
        <h3 class="title">欢迎注册{{ softName }}</h3>
      </div>
      <el-form
        ref="registerForm"
        :model="editFrom"
        :rules="registerRules"
        label-position="right"
        class="registerForm"
      >
        <el-form-item prop="Account">
          <el-input v-model="editFrom.Account" placeholder="请输入登录系统账号" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item prop="Email">
          <el-input v-model="editFrom.Email" placeholder="请输入Email @" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item prop="Password">
          <el-input v-model="editFrom.Password" type="password" placeholder="请输入密码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item prop="Password2">
          <el-input v-model="editFrom.Password2" type="password" placeholder="请再输入一遍密码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item prop="VerificationCode">
          <el-input v-model="editFrom.VerificationCode" placeholder="请输入验证码" style="width:150px; float:left;" maxlength="4" autocomplete="off" clearable />
          <div style="margin-top:5px; float:left;">
            <img :src="apiHostUrl" alt="看不清？点击更换" onclick="this.src = this.src + '?'">
          </div>
        </el-form-item>
        <el-form-item>
          <el-checkbox v-model="checked" false-label="false" true-label="true">我已阅读并同意</el-checkbox> 服务协议 和 隐私声明
        </el-form-item>
        <el-form-item>
          <el-button type="primary" style="width:200px;" @click="handleLogin()">同意协议并提交</el-button>
        </el-form-item>

        <el-form-item>
          <router-link :to="{path:'/'}">登录已有账号</router-link>
        </el-form-item>
      </el-form>
    </div>

    <div id="footer" class="footer" role="contentinfo">
      <div class="footerNode text-secondary">
        <span v-html="copyRight">{{ copyRight }}</span>
      </div>
    </div>
  </div>
</template>

<script>
import defaultSettings from '@/settings'
import { setToken } from '@/utils/auth'
import { getToken, getSysSetting } from '@/api/basebasic'
import { registerUser } from '@/api/security/userservice'

export default {
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
    const emailPassword = (rule, value, callback) => {
      const mailReg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/
      if (!value) {
        return callback(new Error('邮箱不能为空'))
      }
      setTimeout(() => {
        if (mailReg.test(value)) {
          callback()
        } else {
          callback(new Error('请输入正确的邮箱格式'))
        }
      }, 100)
    }
    const validatePass2 = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请再次输入密码'))
      } else if (value !== this.editFrom.Password) {
        callback(new Error('两次输入密码不一致!'))
      } else {
        callback()
      }
    }
    const validateCheck = (rule, value, callback) => {
      if (value === 'false') {
        callback(new Error('请勾选同意协议内容'))
      } else {
        callback()
      }
    }
    return {
      editFrom: {
        Account: '',
        Email: '',
        Password: '',
        Password2: '',
        VerificationCode: '',
        checked: false
      },
      registerRules: {
        Account: [
          { required: true, trigger: 'blur', validator: validateUsername }
        ],
        Password: [
          { required: true, trigger: 'blur', validator: validatePassword }
        ],
        Password2: [
          { required: true, trigger: 'blur', validator: validatePass2 }
        ],
        Email: [
          { required: true, trigger: 'blur', validator: emailPassword }
        ],
        VerificationCode: [
          { required: true, message: '请输入验证码', trigger: 'blur' },
          { min: 4, max: 4, message: '长度在 4字符', trigger: 'blur' }
        ],
        checked: [
          { required: true, trigger: 'blur', validator: validateCheck }]
      },
      apiHostUrl: defaultSettings.apiHostUrl + 'Captcha',
      formLabelWidth: '100px',
      loading: false,
      softName: '管理系统',
      companyLogo: '/assets/images/login-logo.png',
      companyName: '',
      copyRight: ''
    }
  },
  created () {
    this.loadToken()
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
        })
      })
    },
    handleLogin () {
      this.$refs['registerForm'].validate((valid) => {
        if (valid) {
          this.loading = true
          const data = this.editFrom
          registerUser(data).then(res => {
            this.$router.push('/')
            this.loading = false
          }).catch(res => {
            this.loading = false
          })
        } else {
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
body{
  background: #f5f6f7;
color: #000;
}
@supports (-webkit-mask: none) and (not (cater-color: $cursor)) {
  .register-container .el-input input {
    color: $cursor;
  }
}
.header{
  width: 100%;
  .logo-container{
  margin-top: 10px;
  float: left;
  }
}
.registWrapper{

.header{
  width: 100%;
  height: 40px;
  border-bottom: 1px solid #999;
  .logo-container{

  margin-top: 10px;
  float: left;
  }
}
}

.register-container {
 width: 800px;
 margin: 30px auto 30px auto;
 background: #ffffff;
 padding: 20px;
 .title-container{
margin: 20px auto;
  text-align: center;
  .title{
    font-size: 28px;
  }
 }
 .registerForm{
   width: 300px;
   margin: 0 auto;
 }
}
</style>

<style lang="scss" scoped>
$dark_gray: #5e6163;
$light_gray: #eee;

  .footer {
    text-align: center;
  }
  div.footerNodelf {
  }

  div.footerNode {
  }
  .text-secondary {
    font-size: 13px;
    line-height: 25px;
  }
</style>
