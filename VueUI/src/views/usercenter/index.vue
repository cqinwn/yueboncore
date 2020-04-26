<template>
  <div class="app-container">
    <el-form ref="editFrom" :model="editFrom" :rules="rules" class="yuebon-setting-form">
      <el-tabs v-model="activeName" type="border-card">
        <el-tab-pane label="基本信息" name="first">
          <el-form-item label="头像" :label-width="formLabelWidth" prop="HeadIcon">
            <el-upload
              :action="httpFileUploadUrl"
              list-type="picture-card"
              :on-preview="handlePictureCardPreview"
              :on-remove="handleRemove"
              :limit="1"
              :file-list="filelist"
              :on-success="uploadFileSuccess"
            >
              <i class="el-icon-plus" />
            </el-upload>
            <el-dialog :visible.sync="dialogHeadIconVisible">
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
          <el-form-item label="所属组织" :label-width="formLabelWidth" prop="OrganizeId">
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
<script>

import { mapGetters } from 'vuex'
import defaultSettings from '@/settings'
import { getByUserName, saveUser } from '@/api/security/userservice'
import { getAllRoleList } from '@/api/security/roleservice'
import { getAllOrganizeTreeTable } from '@/api/security/organizeservice'
export default {
  data() {
    return {
      activeName: 'first',
      selectRole: [],
      selectedOrganizeOptions: '',
      selectOrganize: [],
      editFrom: {
        Account: '',
        HeadIcon: '',
        RealName: '',
        NickName: '',
        Gender: '1',
        Birthday: '',
        MobilePhone: '',
        Email: '',
        WeChat: '',
        OrganizeId: '',
        RoleId: '',
        IsAdministrator: true,
        EnabledMark: true,
        Description: ''
      },
      rules: {
        RealName: [
          { required: true, message: '请输入系统名称', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
        ],
        MobilePhone: [
          { required: true, message: '请输入访问地址', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
        ]
      },
      httpFileUploadUrl: defaultSettings.fileUploadUrl,
      dialogHeadIconVisible: false,
      dialogHeadIconImageUrl: '',
      filelist: [],
      formLabelWidth: '100px'
    }
  },
  computed: {
    ...mapGetters([
      'name'
    ])
  },
  created() {
    this.InitDictItem()
    this.bindEditInfo()
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem() {
      getAllRoleList().then(res => {
        this.selectRole = res.ResData
      })
      getAllOrganizeTreeTable().then(res => {
        this.selectOrganize = res.ResData
      })
    },
    handleClick(tab, event) {
      console.log(tab, event)
    },

    /**
     *选择组织
     */
    handleSelectOrganizeChange: function() {
      this.editFrom.OrganizeId = this.selectedOrganizeOptions
    },
    handleRemove(file, fileList) {
      console.log(file, fileList)
      this.editFrom.SysLogo = file.url
    },
    handlePictureCardPreview(file) {
      this.dialogImageUrl = file.url
      this.dialogVisible = true
    },
    bindEditInfo: function() {
      getByUserName(this.name).then(res => {
        this.editFrom.Account = res.ResData.Account
        this.editFrom.RealName = res.ResData.RealName
        this.editFrom.NickName = res.ResData.NickName
        this.editFrom.Gender = res.ResData.Gender + ''
        this.editFrom.Birthday = res.ResData.Birthday
        this.editFrom.MobilePhone = res.ResData.MobilePhone
        this.editFrom.Email = res.ResData.Email
        this.editFrom.WeChat = res.ResData.WeChat
        this.editFrom.OrganizeId = res.ResData.OrganizeId
        this.editFrom.IsAdministrator = res.ResData.IsAdministrator
        this.editFrom.EnabledMark = res.ResData.EnabledMark
        this.editFrom.RoleId = res.ResData.RoleId.split(',')
        this.editFrom.Description = res.ResData.Description
        this.selectedOrganizeOptions = res.ResData.OrganizeId
        this.currentId = res.ResData.Id
        this.editFrom.HeadIcon = res.ResData.HeadIcon
        this.filelist = [{ name: res.ResData.HeadIcon, url: res.ResData.HeadIcon }]
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm() {
      console.log(this.editFrom.RoleId)
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            Account: this.editFrom.Account,
            RealName: this.editFrom.RealName,
            NickName: this.editFrom.NickName,
            Gender: this.editFrom.Gender,
            Birthday: this.editFrom.Birthday,
            MobilePhone: this.editFrom.MobilePhone,
            Email: this.editFrom.Email,
            WeChat: this.editFrom.WeChat,
            OrganizeId: this.editFrom.OrganizeId,
            IsAdministrator: this.editFrom.IsAdministrator,
            EnabledMark: this.editFrom.EnabledMark,
            RoleId: this.editFrom.RoleId.join(','),
            Description: this.editFrom.Description,
            HeadIcon: this.editFrom.HeadIcon,
            Id: this.currentId
          }
          var url = 'User/Update?id=' + this.currentId
          saveUser(data, url).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.selectedOrganizeOptions = ''
              this.$refs['editFrom'].resetFields()
              this.bindEditInfo()
            } else {
              this.$message({
                message: res.ErrMsg,
                type: 'error'
              })
            }
          })
        } else {
          return false
        }
      })
    },
    uploadFileSuccess: function(response, file, fileList) {
      this.editFrom.HeadIcon = defaultSettings.fileUrl + response.ResData.FilePath
    }
  }
}
</script>
<style>
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
</style>
