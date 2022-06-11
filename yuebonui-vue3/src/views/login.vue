<template>
  <div class="login-container">
    <div v-show="closeWeb" class="close-web">
      {{webclosereason}}
    </div>
    <div class="login-form">
      <div class="title-container">
        <h3 class="title">{{ softName }}</h3>
      </div>
      <div class="logo-container">
        <div class="img">
        <img :src="companyLogo" width="220" height="40">
        </div>
      </div>
      <div class="form">
    <el-form
      v-if="isShow"
      ref="loginRef"
      :model="loginForm"
      :rules="rules"
      label-position="left"
    >
      <el-form-item prop="username">
        <el-input
          ref="username"
          v-model="loginForm.username"
          :placeholder="showLang.plAccount"
          name="username"
          type="text"
          tabindex="1"
          size="large"
          :prefix-icon="Search"
        />
      </el-form-item>

      <el-form-item prop="password">
        <el-input
          :key="passwordType"
          ref="password"
          v-model="loginForm.password"
          :type="passwordType"
          :placeholder="showLang.inputPassword"
          name="password"
          tabindex="2"
          auto-complete="on"
          size="large"
          show-password
          :prefix-icon="auth"
        />
      </el-form-item>

      <el-form-item prop="vcode">
        <el-input
          ref="vcode"
          v-model="loginForm.vcode"
          :placeholder="showLang.inputVcode"
          name="vcode"
          type="text"
          tabindex="3"
          maxlength="4"
          auto-complete="on" 
          size="large"
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
      </div>
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

<script setup name="Login">
import { getToken, getSysSetting, getVerifyCode } from '@/api/basebasic'
import defaultSettings from '@/settings'
import { ref } from '@vue/reactivity';
const store = useStore();
const router = useRouter();
const { proxy } = getCurrentInstance();
const showLang=ref({
  plAccount:proxy.$t("login.inputAccount"),
  inputPassword:proxy.$t("login.inputPassword"),
  inputVcode:proxy.$t("login.inputVcode"),
})
const validateUsername = (rule, value, callback) => {
  if (value.length < 1) {
    callback(new Error(proxy.$t("login.ruleAccount")))
  } else {
    callback()
  }
}
const validatePassword = (rule, value, callback) => {
  if (value.length < 6) {
    callback(new Error(proxy.$t("login.rulePassword")))
  } else {
    callback()
  }
}

const verifyCodeUrl = ref("");
const loading = ref(false);
const passwordType =ref("password");
const redirect = ref(undefined);
const softName= ref(proxy.$t("login.systemName"));
const companyLogo= ref('src/assets/images/login-logo.png');
const companyName=ref("");
const copyRight=ref("");
const isShow= ref(false);
const otherQuery=ref({});
const webclosereason=ref("")
const closeWeb=ref(false)

const data=reactive({
  loginForm:{
    username: '',
    password: '',
    vcode: '',
    verifyCodeKey: '',
    appId: defaultSettings.appId,
    systemCode: defaultSettings.activeSystemCode,
    host:window.location.host
  },
  rules:{
    username: [
      { required: true, trigger: 'blur', validator: validateUsername }
    ],
    password: [
      { required: true, trigger: 'blur', validator: validatePassword }
    ],
    vcode: [
      { required: true, message: proxy.$t("login.ruleVcodeTip"), trigger: 'blur' },
      { min: 4, max: 4, message: proxy.$t("login.ruleVcodeLengTip"), trigger: 'blur' }
    ]
  }
});
const { loginForm, rules} = toRefs(data);
function loadToken() {
  // getToken().then(response => {
  //   setToken(response.ResData.AccessToken)
    
  // })
  getSysSetting().then(res => {
      softName.value = res.ResData.SoftName
      companyLogo.value = res.ResData.SysLogo
      companyName.value = res.ResData.CompanyName
      copyRight.value = res.ResData.CopyRight
      if(res.ResData.Webstatus==='1'){closeWeb.value=true}
      webclosereason.value=res.ResData.Webclosereason
    })
    isShow.value = true
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
    .form{
      clear: both;
    }
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
    text-align: left;
    width: 100%;
    .img{
      width: 80%;
      float: left;
    }
    .lang{
      float:right;
    }
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
