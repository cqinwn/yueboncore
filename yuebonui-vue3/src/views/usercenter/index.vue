<template>
  <div class="app-container">
    <el-form ref="editFromRef" :model="editFrom" :rules="rules" class="yuebon-setting-form">
      <el-tabs v-model="activeName" type="border-card">
        <el-tab-pane label="基本信息" name="first">
          <el-form-item label="头像" :label-width="formLabelWidth" prop="HeadIcon">
            <el-upload
              class="avatar-uploader"
              :action="httpFileUploadUrl"
              :headers="headers"
              :show-file-list="false"
              :on-success="uploadFileSuccess"
            >
              <img v-if="editFrom.HeadIcon" :src="headIconUrl" class="avatar">
              <i v-else class="avatar-uploader-icon" />
            </el-upload>
            <el-dialog v-model="dialogHeadIconVisible">
              <img width="100%" :src="dialogHeadIconImageUrl" alt="">
            </el-dialog>
          </el-form-item>
          <el-form-item label="账号" :label-width="formLabelWidth" prop="Account">
            <el-input v-model="editFrom.Account" placeholder="请输入登录系统账号" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="姓名" :label-width="formLabelWidth" prop="RealName">
            <el-input v-model="editFrom.RealName" placeholder="请输入姓名" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="昵称" :label-width="formLabelWidth" prop="NickName">
            <el-input v-model="editFrom.NickName" placeholder="请输入昵称" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="性别" :label-width="formLabelWidth" prop="Gender">
            <el-radio-group v-model="editFrom.Gender">
              <el-radio label="1">男</el-radio>
              <el-radio label="0">女</el-radio>
              <el-radio label="2">未知</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="手机号" :label-width="formLabelWidth" prop="MobilePhone">
            <el-input v-model="editFrom.MobilePhone" placeholder="请输入手机号" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="微信号" :label-width="formLabelWidth" prop="WeChat">
            <el-input v-model="editFrom.WeChat" placeholder="请输入微信号" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="邮箱" :label-width="formLabelWidth" prop="Email">
            <el-input v-model="editFrom.Email" placeholder="请输入Email @" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="出身日期" :label-width="formLabelWidth" prop="Birthday">
            <el-date-picker
              v-model="editFrom.Birthday"
              type="date"
              placeholder="选择日期"
            />
          </el-form-item>
          <el-form-item label="选项" :label-width="formLabelWidth" prop="">
            <el-checkbox v-model="editFrom.EnabledMark">启用</el-checkbox>
            <el-checkbox v-model="editFrom.IsAdministrator">管理员</el-checkbox>
          </el-form-item>
          <el-form-item label="所属组织" style="width:500px" :label-width="formLabelWidth" prop="DepartmentId">
            <el-cascader
              v-model="selectedOrganizeOptions"
              style="width:500px;"
              :options="selectOrganize"
              filterable
              :props="{label:'FullName',value:'Id',children:'Children',emitPath:false, checkStrictly: true,expandTrigger: 'hover' }"
              clearable
              @change="handleSelectOrganizeChange"
            />
          </el-form-item>
          <el-form-item label="岗位角色" :label-width="formLabelWidth" prop="RoleId">
            <el-select
              v-model="editFrom.RoleId"
              style="width:500px"
              multiple
              clearable
              disabled
              placeholder="请选择"
            >
              <el-option
                v-for="item in selectRole"
                :key="item.Id"
                :label="item.FullName"
                :value="item.Id"
              />
            </el-select>
          </el-form-item>
          <el-form-item label="备注" :label-width="formLabelWidth" prop="Description">
            <el-input v-model="editFrom.Description" style="width:500px" placeholder="" autocomplete="off" clearable />
          </el-form-item>
        </el-tab-pane>
      </el-tabs>
      <el-form-item>
        <el-button type="primary" class="btnset" @click="saveEditForm()">保 存</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>
<script setup name="UserCenter">
import defaultSettings from '@/settings'
import { saveUser } from '@/api/security/userservice'
import { getAllRoleList } from '@/api/security/roleservice'
import { getAllOrganizeTreeTable } from '@/api/security/organizeservice'
import { GetProfile} from '@/api/basebasic'
import { getToken } from '@/utils/auth'

const { proxy } = getCurrentInstance()
const activeName=ref('first')
const selectRole=ref([])
const selectedOrganizeOptions=ref('')
const selectOrganize=ref([])
const httpFileUploadUrl=ref(defaultSettings.fileUploadUrl)
const dialogHeadIconVisible=ref(false)
const dialogHeadIconImageUrl=ref('')
const filelist=ref([])
const formLabelWidth=ref('100px')
const headers=ref([])
const headIconUrl=ref("")

const data = reactive({
  editFrom:{},
  rules: {
    RealName: [
      { required: true, message: '请输入系统名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
    ],
    MobilePhone: [
      { required: true, message: '请输入访问地址', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
    ]
  }
})
const {editFrom, rules} = toRefs(data);

function created() {
  InitDictItem()
  bindEditInfo()
  headers.value = { Authorization: 'Bearer ' + (getToken() || '') }
}
/**
 * 初始化数据
 */
function InitDictItem() {
  getAllRoleList().then(res => {
    selectRole.value = res.ResData
  })
  getAllOrganizeTreeTable().then(res => {
    selectOrganize.value = res.ResData
  })
}

/**
 *选择组织
  */
function handleSelectOrganizeChange() {
  editFrom.value.DepartmentId = selectedOrganizeOptions
}
function handleRemove(file, fileList) {
  editFrom.value.SysLogo = file.url
}
function handlePictureCardPreview(file) {
  dialogImageUrl.value = file.url
  dialogVisible.value = true
}
function bindEditInfo() {
  GetProfile().then(res => {
    editFrom.value=res.ResData
    editFrom.value.RoleId = res.ResData.RoleId.split(',')
    editFrom.value.Gender=res.ResData.Gender+''
    selectedOrganizeOptions.value=res.ResData.DepartmentId
    headIconUrl.value=defaultSettings.fileUrl+res.ResData.HeadIcon
    filelist.value = [{ name: res.ResData.HeadIcon, url: res.ResData.HeadIcon }]
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      //editFrom.value.RoleId= editFrom.value.RoleId.join(',')
      var url = 'User/Update'
      
      const data =editFrom.value
      data.RoleId= editFrom.value.RoleId.join(',')
      saveUser(editFrom.value, url).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          selectedOrganizeOptions.value = ''
          bindEditInfo()
        } else {
          proxy.$modal.msgError(res.ErrMsg)
        }
      })
    } else {
      return false
    }
  })
}
function uploadFileSuccess(response, file, fileList) {
  editFrom.value.HeadIcon = response.ResData.FilePath
  headIconUrl.value=defaultSettings.fileUrl+response.ResData.FilePath
}
created()
</script>
<style lang="scss" scoped>
.yuebon-setting-form .el-tab-pane{
  width: 40%;
}
.yuebon-setting-form .el-input{
width: 100%;
}
.yuebon-setting-form .el-select .el-input,.yuebon-setting-form .el-cascader .el-input{
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
