<template>
  <div class="login-container">
    <div v-show="closeWeb" class="close-web">
      {{webclosereason}}
    </div>
    <el-form
      v-if="isShow"
      ref="loginRef"
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
        <img :src="companyLogo" width="220" height="40">
      </div>
      <el-form-item prop="username">
        <span class="svg-container">
          <svg-icon icon-class="user" />
        </span>
        <el-input
          ref="username"
          v-model="loginForm.username"
          :placeholder="showLang.plAccount"
          name="username"
          type="text"
          tabindex="1"
          auto-complete="on"
        />
      </el-form-item>

      <el-form-item prop="password">
        <span class="svg-container">
          <svg-icon icon-class="auth" />
        </span>
        <el-input
          :key="passwordType"
          ref="password"
          v-model="loginForm.inputPassword"
          :type="passwordType"
          :placeholder="showLang.plAccount"
          name="password"
          tabindex="2"
          auto-complete="on"
        />
        <span class="show-pwd" @click="showPwd">
          <svg-icon
            :icon-class="passwordType.value === 'password' ? 'eye' : 'eye-open'"
          />
        </span>
      </el-form-item>

      <el-form-item prop="vcode">
        <span class="svg-container">
          <svg-icon icon-class="password" />
        </span>
        <el-input
          ref="vcode"
          v-model="loginForm.vcode"
          :placeholder="showLang.inputVcode"
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
        type="primary"
        :loading="loading"
        style="width: 100%; margin-bottom: 30px"
        @click.prevent="handleLogin">
        <span v-if="!loading">{{ $t('login.btnLoginText')}}</span>
        <span v-else>{{ $t('login.btnLoginIngText')}}</span>
      </el-button>
      <div style="text-align:right;">
        {{ $t('login.txtReg')}}<router-link class="link-type" :to="'/register'">{{ $t('login.regLink')}}</router-link>
      </div>
      <div class="tips" />
    </el-form>
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

<script setup name="Login">
import { setToken } from '@/utils/auth'
import { getToken, getSysSetting, getVerifyCode } from '@/api/basebasic'
import defaultSettings from '@/settings'
import { ref } from '@vue/reactivity';
import i18n from '@/lang/index'
const store = useStore();
const router = useRouter();
const { proxy } = getCurrentInstance();
const showLang=ref({
  plAccount:i18n.global.t("login.inputAccount"),
  inputPassword:i18n.global.t("login.inputPassword"),
  inputVcode:i18n.global.t("login.inputVcode"),
})
const loginForm=ref({
  username: '',
  password: '',
  vcode: '',
  verifyCodeKey: '',
  appId: defaultSettings.appId,
  systemCode: defaultSettings.activeSystemCode
});
const validateUsername = (rule, value, callback) => {
  if (value.length < 1) {
    callback(new Error(i18n.global.t("login.ruleAccount")))
         // proxy.$modal.msgSuccess(i18n.global.t('message.successTips'))
  } else {
    callback()
  }
}
const validatePassword = (rule, value, callback) => {
  if (value.length < 6) {
    callback(new Error(i18n.global.t("login.rulePassword")))
  } else {
    callback()
  }
}
const loginRules={
  username: [
    { required: true, trigger: 'blur', validator: validateUsername }
  ],
  password: [
    { required: true, trigger: 'blur', validator: validatePassword }
  ],
  vcode: [
    { required: true, message: i18n.global.t("login.ruleVcodeTip"), trigger: 'blur' },
    { min: 4, max: 4, message: i18n.global.t("login.ruleVcodeLengTip"), trigger: 'blur' }
  ]
};

const verifyCodeUrl = ref("");
const loading = ref(false);
const passwordType =ref("password");
const redirect = ref(undefined);
const softName= ref(i18n.global.t("login.systemName"));
const companyLogo= ref('src/assets/images/login-logo.png');
const companyName=ref("");
const copyRight=ref("");
const isShow= ref(false);
const otherQuery=ref({});
const webclosereason=ref("")
const closeWeb=ref(false)

function loadToken() {
  getToken().then(response => {
    setToken(response.ResData.AccessToken)
    getSysSetting().then(res => {
      softName.value = res.ResData.SoftName
      companyLogo.value = res.ResData.SysLogo
      companyName.value = res.ResData.CompanyName
      copyRight.value = res.ResData.CopyRight
      if(res.ResData.Webstatus==='1'){closeWeb.value=true}
      webclosereason.value=res.ResData.Webclosereason
    })
    isShow.value = true
  })
}
function showPwd() {
  if (passwordType.value === 'password') {
    passwordType.value= ''
  } else {
    passwordType.value= 'password'
  }
  nextTick(() => {
    proxy.$refs.password.focus()
  })
}
function handleLogin() {
  proxy.$refs.loginRef.validate(valid => {
    if (valid) {
      loading.value = true
      store.dispatch('Login', loginForm.value)
        .then(res => {
          router.push({ path: redirect.value || "/" });
          loading.value = false
        })
        .catch(res => {
          loading.value = false
          getLoginVerifyCode()
        })
    } else {
      return false
    }
  })
}
// 获取验证码
async function getLoginVerifyCode() {
  loginForm.vcode = ''
  const res =await getVerifyCode()
  if (res.Success) {
    verifyCodeUrl.value = 'data:image/png;base64,' + res.ResData.Img
    loginForm.value.verifyCodeKey = res.ResData.Key
  }
}
function getOtherQuery() {
  return Object.keys(proxy.$route.query).reduce((acc, cur) => {
    if (cur !== 'redirect') {
      acc[cur] = query[cur]
    }
    return acc
  }, {})
}
loadToken()
getLoginVerifyCode()
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
  background-image: url("@/assets/images/convergedbg_v2.jpg");
  overflow: hidden;
  background-size:100% 100%;

  .close-web{
    text-align: center;
    margin: 20px auto;
    font-size: 26px;
    color: red;
  }
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
