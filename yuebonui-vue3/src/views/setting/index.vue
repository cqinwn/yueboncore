<template>
  <div class="app-container">
    <el-form ref="fromRef" :model="editFrom" :rules="rules" class="yuebon-setting-form">
      <el-tabs v-model="activeName" type="border-card">
        <el-tab-pane label="基本信息" name="first">
          <el-form-item label="系统名称" :label-width="formLabelWidth" prop="SoftName">
            <el-input v-model="editFrom.SoftName" placeholder="请输入系统名称" autocomplete="off" clearable />
            *系统名称最多20个字符
          </el-form-item>
          <el-form-item label="系统简介" :label-width="formLabelWidth" prop="SoftSummary">
            <el-input v-model="editFrom.SoftSummary" placeholder="请输入系统简介" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="访问域名" :label-width="formLabelWidth" prop="WebUrl">
            <el-input v-model="editFrom.WebUrl" placeholder="请输入访问域名" autocomplete="off" clearable />
            *域名授权请联系<a href="http://www.yuebon.com/" target="_blank">越邦客服</a>
          </el-form-item>
          <el-form-item label="Logo" :label-width="formLabelWidth" prop="SysLogo">
            <el-upload
              class="avatar-uploader"
              :action="httpFileUploadUrl"
              :headers="headers"
              :show-file-list="false"
              :on-success="uploadFileSuccess"
            >
              <img v-if="editFrom.SysLogo" :src="editFrom.SysLogo" class="avatar">
              <i v-else class="el-icon-plus avatar-uploader-icon" />
            </el-upload>
            <el-dialog v-model="dialogVisible">
              <img width="100%" :src="dialogImageUrl" alt="">
            </el-dialog>
          </el-form-item>
          <el-form-item label="公司名称" :label-width="formLabelWidth" prop="CompanyName">
            <el-input v-model="editFrom.CompanyName" placeholder="请输入公司名称" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="通讯地址" :label-width="formLabelWidth" prop="Address">
            <el-input v-model="editFrom.Address" placeholder="请输入通讯地址" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="电话" :label-width="formLabelWidth" prop="Telphone">
            <el-input v-model="editFrom.Telphone" placeholder="请输入电话" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="Email" :label-width="formLabelWidth" prop="Email">
            <el-input v-model="editFrom.Email" placeholder="请输入Email" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="ICP备案号" :label-width="formLabelWidth" prop="ICPCode">
            <el-input v-model="editFrom.ICPCode" placeholder="请输入ICP备案号" autocomplete="off" clearable />
            请到工业和信息化部http://beian.miit.gov.cn网站查询
          </el-form-item>
          <el-form-item label="公安备案号" :label-width="formLabelWidth" prop="PublicSecurityCode">
            <el-input v-model="editFrom.PublicSecurityCode" placeholder="请输入公安备案号" autocomplete="off" clearable />
            请到全国互联网安全管理服务平台http://www.beian.gov.cn网站备案查询
          </el-form-item>
        </el-tab-pane>
        <el-tab-pane label="功能权限" name="second">
          <el-form-item label="是否开启系统" :label-width="formLabelWidth" prop="Webstatus">
            <el-radio-group v-model="editFrom.Webstatus">
              <el-radio label="0">是</el-radio>
              <el-radio label="1">否</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="系统关闭原因" :label-width="formLabelWidth" prop="Webclosereason">
            <el-input v-model="editFrom.Webclosereason" type="textarea" placeholder="请输入系统关闭原因" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="系统统计代码" :label-width="formLabelWidth" prop="Webcountcode">
            <el-input v-model="editFrom.Webcountcode" type="textarea" placeholder="请输入系统统计代码" autocomplete="off" clearable />
          </el-form-item>
        </el-tab-pane>
        <el-tab-pane label="短信设置" name="three">
          <el-form-item label="短信API地址" :label-width="formLabelWidth" prop="Smsapiurl">
            <el-input v-model="editFrom.Smsapiurl" placeholder="请输入短信API地址" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="平台登录账户" :label-width="formLabelWidth" prop="Smsusername">
            <el-input v-model="editFrom.Smsusername" placeholder="请输入平台登录账户" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="平台通信密钥" :label-width="formLabelWidth" prop="Smspassword">
            <el-input v-model="editFrom.Smspassword" placeholder="请输入平台通信密钥" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="签名" :label-width="formLabelWidth" prop="SmsSignName">
            <el-input v-model="editFrom.SmsSignName" placeholder="请输入短信签名" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="短信平台说明" :label-width="formLabelWidth">
            请不要使用系统默认账户test，因为它是公用的测试账号；
            请在短信平台修改账户资料中绑定签名方可使用短信功能；
            如果您尚未申请开通，请点击这里注册成功后填写您的用户名和通讯密钥均可正常使用。
            目前实现了阿里云短信和助通科技短信接口。
          </el-form-item>
        </el-tab-pane>
        <el-tab-pane label="邮件设置" name="four">
          <el-form-item label="SMTP服务器" :label-width="formLabelWidth" prop="Emailsmtp">
            <el-input v-model="editFrom.Emailsmtp" placeholder="请输入SMTP服务器" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="SSL加密连接" :label-width="formLabelWidth" prop="Emailssl">
            <el-radio-group v-model="editFrom.Emailssl">
              <el-radio label="true">是</el-radio>
              <el-radio label="false">否</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="SMTP端口" :label-width="formLabelWidth" prop="Emailport">
            <el-input v-model="editFrom.Emailport" placeholder="请输入SMTP端口" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="发件人地址" :label-width="formLabelWidth" prop="Emailfrom">
            <el-input v-model="editFrom.Emailfrom" placeholder="请输入发件人地址" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="邮箱账号" :label-width="formLabelWidth" prop="Emailusername">
            <el-input v-model="editFrom.Emailusername" placeholder="请输入邮箱账号" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="邮箱密码" :label-width="formLabelWidth" prop="Emailpassword">
            <el-input v-model="editFrom.Emailpassword" placeholder="请输入邮箱密码" type="password" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="发件人昵称" :label-width="formLabelWidth" prop="Emailnickname">
            <el-input v-model="editFrom.Emailnickname" placeholder="请输入发件人昵称" autocomplete="off" clearable />
          </el-form-item>
        </el-tab-pane>
        <el-tab-pane label="文件上传" name="five">
          <el-form-item label="文件服务器" :label-width="formLabelWidth" prop="Fileserver">
            <el-select v-model="editFrom.Fileserver" placeholder="请选择">
              <el-option label="本地服务器" value="localhost" />
              <el-option label="阿里云OSS" value="alioss" />
              <el-option label="腾讯云OSS" value="tengxunoss" />
              <el-option label="七牛云" value="qiniu" />
            </el-select>
          </el-form-item>
          <el-form-item label="文件上传目录" :label-width="formLabelWidth" prop="Filepath">
            <el-input v-model="editFrom.Filepath" placeholder="请输入文件上传目录" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="文件保存方式" :label-width="formLabelWidth" prop="Filesave">
            <el-select v-model="editFrom.Filesave" placeholder="请选择">
              <el-option label="按年月日每天一个目录" value="1" />
              <el-option label="按年月日存入不同目录" value="2" />
            </el-select>
          </el-form-item>
          <el-form-item label="文件上传类型" :label-width="formLabelWidth" prop="Fileextension">
            <el-input v-model="editFrom.Fileextension" placeholder="请输入文件上传类型" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="图片缩略大小" :label-width="formLabelWidth" prop="Thumbnailheight">
            宽<el-input v-model="editFrom.Thumbnailwidth" placeholder="缩略图宽度" autocomplete="off" style="width:150px;" clearable />px
            *高<el-input v-model="editFrom.Thumbnailheight" placeholder="缩略图高度" autocomplete="off" style="width:150px;" clearable />px

          </el-form-item>
        </el-tab-pane>
      </el-tabs>
      <el-form-item>
        <el-button type="primary" class="btnset" @click="saveEditForm()">保 存</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>
<script setup>
import { getAllSysSetting, saveSysSetting } from '@/api/basebasic'
import defaultSettings from '@/settings'
import { getToken } from '@/utils/auth'
const { proxy } = getCurrentInstance()

const activeName=ref('first')
const httpFileUploadUrl=ref(defaultSettings.fileUploadUrl)
const dialogVisible=ref(false)
const dialogImageUrl=ref('')
const filelist=ref([])
const formLabelWidth=ref('150px')
const headers=ref([])

const data = reactive({
  editFrom: {
    SoftName: '',
    SoftSummary: '',
    WebUrl: '',
    SysLogo: '',
    CompanyName: '',
    Address: '',
    Telphone: '',
    Email: '',
    ICPCode: '',
    PublicSecurityCode: '',
    Webstatus: 0,
    Webclosereason: '',
    Webcountcode: '',
    Smsapiurl: '',
    Smsusername: '',
    Smspassword: '',
    SmsSignName: '',
    Emailsmtp: '',
    Emailssl: '',
    Emailport: '',
    Emailfrom: '',
    Emailusername: '',
    Emailpassword: '',
    Emailnickname: '',
    Fileserver: '',
    Filepath: '',
    Filesave: '',
    Fileextension: ''
  },
  rules: {
    SoftName: [
      { required: true, message: '请输入系统名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
    ],
    WebUrl: [
      { required: true, message: '请输入访问地址', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
    ]
  }
})

const { editFrom,rules} = toRefs(data);
function handleRemove(file, fileList) {
  editFrom.value.SysLogo = file.url
}
function handlePictureCardPreview(file) {
  dialogImageUrl.value = file.url
  dialogVisible.value = true
}
function loadSettingData() {
  getAllSysSetting().then(res => {
    editFrom.value = res.ResData
  })
}
function uploadFileSuccess(response, file, fileList) {
  editFrom.value.SysLogo = defaultSettings.fileUrl + response.ResData.FilePath
}
function saveEditForm() {
  proxy.$refs['fromRef'].validate((valid) => {
    if (valid) {
      const data =editFrom.value
      saveSysSetting(data).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          proxy.resetForm("fromRef")
          loadSettingData()
        } else {
          proxy.$modal.msgError(res.ErrMsg)
        }
      })
    } else {
      return false
    }
  })
}
loadSettingData()
</script>
<style lang="scss" scoped>
.yuebon-setting-form .el-form-item{
  width: 100%;
}
.yuebon-setting-form .el-input{
width: 40%;
}
.yuebon-setting-form .el-select .el-input{
        width: 100%;
}
.yuebon-setting-form .btnset{
    float:right;
    margin-right: 30px;
    margin-top: 20px;
}

.avatar-uploader .el-upload {
    border: 1px solid #ccc;
    border-radius: 6px;
    cursor: pointer;
    position: relative;
    overflow: hidden;
  }
  .avatar-uploader .el-upload:hover {
    border-color: #409EFF;
  }
  .avatar-uploader-icon {
    font-size: 28px;
    color: #8c939d;
    width: 176px;
    height: 176px;
    line-height: 176px;
    border: 1px solid #ccc;
    text-align: center;
  }
  .avatar {
    width: 176px;
    height: 176px;
    display: block;
    border: 1px solid #ccc;
  }
</style>
