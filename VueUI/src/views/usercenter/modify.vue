<template>
  <div class="app-container">
    <el-tabs v-model="activeName" type="border-card">
      <el-tab-pane label="修改密码" name="first">
        <el-form ref="editFrom" :model="editFrom" :rules="rules" class="yuebon-setting-form">
          <el-form-item label="原密码" :label-width="formLabelWidth" prop="OldPassword">
            <el-input v-model="editFrom.OldPassword" type="password" placeholder="请输入原密码" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="新密码" :label-width="formLabelWidth" prop="NewPassword">
            <el-input v-model="editFrom.NewPassword" type="password" placeholder="请输入新密码" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="再输入一次" :label-width="formLabelWidth" prop="NewPassword2">
            <el-input v-model="editFrom.NewPassword2" type="password" placeholder="请再输入一次新密码" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item>
            <el-button type="primary" @click="saveEditForm()">保 存</el-button>
          </el-form-item>
        </el-form>
      </el-tab-pane>
    </el-tabs>
  </div>
</template>
<script>

import { modifyPassword } from '@/api/security/userservice'
export default {
  name: 'Usercentermodify',
  data () {
    return {
      activeName: 'first',
      editFrom: {
        OldPassword: '',
        NewPassword: '',
        NewPassword2: ''
      },
      rules: {
        OldPassword: [
          { required: true, message: '请输入原密码', trigger: 'blur' },
          { min: 6, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
        ],
        NewPassword: [
          { required: true, message: '请输入新密码', trigger: 'blur' },
          { min: 6, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
        ],
        NewPassword2: [
          { required: true, message: '请再输入一次新密码', trigger: 'blur' },
          { min: 6, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
        ]
      },
      formLabelWidth: '100px'
    }
  },
  methods: {
    /**
     * 新增/修改保存
     */
    saveEditForm () {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            oldpassword: this.editFrom.OldPassword,
            password: this.editFrom.NewPassword,
            password2: this.editFrom.NewPassword2
          }
          modifyPassword(data).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.$refs['editFrom'].resetFields()
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
</style>
