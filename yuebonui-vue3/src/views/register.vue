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
      <el-form ref="registerFormRef" :model="editFrom" :rules="registerRules" label-position="right"
        class="registerForm">
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
          <el-input v-model="editFrom.VerificationCode" placeholder="请输入验证码" style="width:150px; float:left;"
            maxlength="4" autocomplete="off" clearable />

          <div style="display:inline; float:left;margin-right:10px;margin-left:10px;">
            <img :src="verifyCodeUrl" style="cursor: pointer;vertical-align: middle;" alt="看不清？点击更换"
              @click="getLoginVerifyCode">
          </div>
        </el-form-item>
        <el-form-item prop="checkAgreement">
          <el-checkbox-group v-model="editFrom.checkAgreement">
            <el-checkbox label="true">我已阅读并同意<router-link class="link-type" :to="'#'">服务协议</router-link></el-checkbox>
          </el-checkbox-group>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" style="width:200px;" @click="handleLogin()">同意协议并提交</el-button>
        </el-form-item>
        <el-form-item>
          <router-link class="link-type" :to="'/login'">登录已有账号</router-link>
        </el-form-item>
      </el-form>
    </div>

    <div id="footer" class="footer" role="contentinfo">
      <div class="footerNodelf text-secondary">
        <span>本软件使用权属于：{{ companyName }}</span>
      </div>
      <div class="footerNode text-secondary">
        <span v-html="copyRight"></span>
      </div>
    </div>
  </div>
</template>

<script setup>
import { setToken } from '@/utils/auth'
import { getToken, getSysSetting, getVerifyCode } from '@/api/basebasic'
import { registerUser } from '@/api/security/userservice'
import { ref } from '@vue/reactivity';
import { ElMessageBox } from 'element-plus'

const router = useRouter();
const { proxy } = getCurrentInstance();

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
const validateemail = (rule, value, callback) => {
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
  } else if (value !== editFrom.value.Password) {
    callback(new Error('两次输入密码不一致!'))
  } else {
    callback()
  }
}
const editFrom=ref({
  Account: '',
  Email: '',
  Password: '',
  Password2: '',
  VerificationCode: '',
  VerifyCodeKey: '',
  checkAgreement: [],
  Host: window.location.host
})
const registerRules={
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
    { required: true, trigger: 'blur', validator: validateemail }
  ],
  VerificationCode: [
    { required: true, message: '请输入验证码', trigger: 'blur' },
    { min: 4, max: 4, message: '长度4字符', trigger: 'blur' }
  ],
  checkAgreement: [
    { type: 'array', required: true, trigger: 'change', message: '请勾选同意协议内容' }]
}
const verifyCodeUrl=ref('')
const formLabelWidth=ref('100px')
const softName=ref('管理系统')
const companyLogo= ref('src/assets/images/login-logo.png');
const companyName=ref('')
const copyRight=ref('')
const loading=ref(false)

function loadToken() {
  getToken().then(response => {
    //setToken(response.ResData.AccessToken)
    getSysSetting().then(res => {
      softName.value = res.ResData.SoftName
      //companyLogo.value = res.ResData.SysLogo
      companyName.value = res.ResData.CompanyName
      copyRight.value = res.ResData.CopyRight
    })
  })
}
function handleLogin(){
  proxy.$refs['registerFormRef'].validate((valid) => {
    if (valid) {
      if (!editFrom.value.checkAgreement) {
        proxy.$modal.msgError('请勾选同意协议内容')
        return
      }
      loading.value = true
      const data = editFrom.value
      registerUser(data).then(res => {
        if (res.true) {
          ElMessageBox.alert("<font color='red'>恭喜你，您的账号 " + editFrom.value.Account + " 注册成功！</font>", "系统提示", {
            dangerouslyUseHTMLString: true,
            type: "success",
          }).then(() => {
            router.push("/login");
          }).catch(() => {});
        } else {
          proxy.$modal.msgError(res.ErrMsg)
        }
        loading.value = false
      }).catch(res => {
        loading.value = false
      })
    } else {
      return false
    }
  })
}
// 获取验证码
async function getLoginVerifyCode() {
  editFrom.value.VerificationCode = ''
  const res = await getVerifyCode()
  if (res.Success) {
    verifyCodeUrl.value = 'data:image/png;base64,' + res.ResData.Img
    editFrom.value.VerifyCodeKey = res.ResData.Key
  }
}

loadToken()
getLoginVerifyCode()
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
  height: 60px;
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
 width: 800px;
 margin: 30px auto 0 auto;
  }
  div.footerNodelf {
    float: left;
  }

  div.footerNode {
    float: right;
  }
  .text-secondary {
    font-size: 13px;
    line-height: 25px;
  }
</style>
