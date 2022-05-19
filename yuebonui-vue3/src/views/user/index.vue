<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="queryParams" class="demo-form-inline">
      <el-form-item label="角色" prop="RoleId">
        <el-select v-model="queryParams.RoleId" clearable placeholder="请选择">
          <el-option v-for="item in selectRole" :key="item.Id" :label="item.FullName" :value="item.Id" />
        </el-select>
      </el-form-item>
      <el-form-item label="用户信息：" prop="Keywords">
        <el-input v-model="queryParams.Keywords" clearable placeholder="账号/姓名/昵称/电话" />
      </el-form-item>
      <el-form-item label="注册日期：" prop="CreateTime">
        <el-date-picker v-model="queryParams.CreateTime" type="daterange" align="right" value-format="YYYY-MM-DD" unlink-panels range-separator="至" start-placeholder="开始日期" end-placeholder="结束日期" :shortcuts="shortcuts" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="handleSearch">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['User/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
        <el-button v-hasPermi="['User/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify" @click="ShowEditOrViewDialog('edit')">修改</el-button>
        <el-button v-hasPermi="['User/Enable']" type="info" icon="video-pause" :disabled="multiple" @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['User/Enable']" type="success" icon="video-play" :disabled="multiple" @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['User/DeleteSoft']" type="warning" icon="delete" :disabled="multiple" @click="deleteSoft('0')">软删除</el-button>
        <el-button v-hasPermi="['User/Delete']" type="danger" icon="delete" :disabled="multiple" @click="deletePhysics()">删除</el-button>
        <el-button v-hasPermi="['User/ResetPassword']" type="default" icon="refresh-right" :disabled="single" @click="handleResetPassword()">重置密码</el-button>
      </el-button-group>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="loadTableData"></right-toolbar>
    </el-row>
    <el-table
      ref="gridtable"
      v-loading="tableloading"
      :data="tableData"
      stripe
      highlight-current-row
      style="width: 100%"
      :default-sort="{prop: 'SortCode', order: 'descending'}"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
    >
      <el-table-column type="selection" width="55" />
      <el-table-column prop="Account" label="账号/用户名" sortable="custom" width="230" fixed />
      <el-table-column prop="RealName" label="真实姓名" sortable="custom" width="180" fixed />
      <el-table-column prop="NickName" label="昵称" sortable="custom" width="180" fixed />
      <el-table-column prop="Gender" label="性别" sortable="custom" width="90" align="center">
        <template #default="scope">
          {{ scope.row.Gender=== 1 ? '男' : '女' }}
        </template>
      </el-table-column>
      <el-table-column prop="Birthday" label="生日" sortable="custom" width="120" align="center">
        <template #default="scope">
            <span>{{ parseTime(scope.row.Birthday, '{y}-{m}-{d}') }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="MobilePhone" label="手机号码" sortable="custom" width="120" align="center" />
      <el-table-column prop="DepartmentName" label="所属组织" width="260" align="center">
        <template #default="scope">
          {{ scope.row.OrganizeName+"/"+ scope.row.DepartmentName }}
        </template>
      </el-table-column>
      <el-table-column prop="RoleName" label="岗位角色" sortable="custom" width="280" align="center" />
      <el-table-column label="可用" sortable="custom" width="90" prop="EnabledMark" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{ scope.row.EnabledMark===true?'启用':'禁用' }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="删除" sortable="custom" width="90" prop="DeleteMark" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.DeleteMark === true ? 'danger' : 'success'" disable-transitions>{{ scope.row.DeleteMark===true?'已删除':'否' }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="CreatorTime" label="添加时间" width="180" sortable />
      <el-table-column prop="LastModifyTime" label="更新时间" width="180" sortable>
        <template #default="scope">
          {{ scope.row.LastModifyTime }}
        </template>
      </el-table-column>
    </el-table>
    <Pagination
      v-show="queryParams.pageTotal>0"
      :total="queryParams.pageTotal" 
      v-model:page="queryParams.CurrenetPageIndex"
      v-model:limit="queryParams.PageSize"
      @pagination="loadTableData"
    />
    <el-dialog ref="dialogEditFormRef" :title="editFormTitle+'用户'" v-model="dialogEditFormVisible" draggable>
      <el-form ref="editFromRef" :inline="true" :model="editFrom" :rules="rules" class="demo-form-inline">
        <el-form-item label="账号" :label-width="formLabelWidth" prop="Account">
          <el-input v-model="editFrom.Account" placeholder="请输入账号" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="姓名" :label-width="formLabelWidth" prop="RealName">
          <el-input v-model="editFrom.RealName" placeholder="请输入姓名" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="昵称" :label-width="formLabelWidth" prop="NickName">
          <el-input v-model="editFrom.NickName" placeholder="请输入昵称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="性别" :label-width="formLabelWidth" prop="Gender">
          <el-radio-group v-model="editFrom.Gender">
            <el-radio :label="1">男</el-radio>
            <el-radio :label="0">女</el-radio>
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
          <el-date-picker v-model="editFrom.Birthday" type="date" placeholder="选择日期" />
        </el-form-item>
        <el-form-item label="选项" :label-width="formLabelWidth" prop="">
          <el-checkbox v-model="editFrom.EnabledMark">启用</el-checkbox>
          <el-checkbox v-model="editFrom.IsAdministrator">管理员</el-checkbox>
        </el-form-item>
        <el-form-item label="所属组织" :label-width="formLabelWidth" prop="DepartmentId">
          <el-cascader v-model="selectedOrganizeOptions" style="width:500px;" :options="selectOrganize" filterable :props="{label:'FullName',value:'Id',children:'Children',emitPath:false, checkStrictly: true,expandTrigger: 'hover' }" clearable @change="handleSelectOrganizeChange" />
        </el-form-item>
        <el-form-item label="岗位角色" :label-width="formLabelWidth" prop="RoleId">
          <el-select v-model="editFrom.RoleId" style="width:500px" multiple clearable placeholder="请选择">
            <el-option v-for="item in selectRole" :key="item.Id" :label="item.FullName" :value="item.Id" />
          </el-select>
        </el-form-item>
        <el-form-item label="备注" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" style="width:500px" placeholder="" autocomplete="off" clearable />
        </el-form-item>
      </el-form>
      <template #footer>
      <div class="dialog-footer">
        <el-button @click="dialogEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditForm()">确 定</el-button>
      </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="User">
import {
  getUserListWithPager, getUserDetail, saveUser, setUserEnable,
  deleteSoftUser, deleteUser, resetPassword
} from '@/api/security/userservice'
import { getAllRoleList } from '@/api/security/roleservice'
import { getAllOrganizeTreeTable } from '@/api/security/organizeservice'

const { proxy } = getCurrentInstance()
const tableData=ref([])
const tableloading=ref(true)
const dialogEditFormVisible=ref(false)
const editFormTitle=ref("")
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);

const formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])

const selectRole=ref([])
const selectedOrganizeOptions=ref("")
const selectOrganize=ref([])

const data = reactive({
  queryParams:{
    CurrenetPageIndex: 1,
    PageSize: 20,
    pageTotal: 0,
    Order: 'desc',
    Sort: 'CreatorTime',
    RoleId: '',
    Keywords: '',
    CreateTime: ''
  },
  
  editFrom:{},
  rules: {
    Account: [
      { required: true, message: '请输入账号', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 16 个字符', trigger: 'blur' }
    ],
    RealName: [
      { required: true, message: '请输入姓名', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    DepartmentId: [
      { required: true, message: '请输选择所属组织', trigger: 'blur' }
    ],
    RoleId: [
      { required: true, message: '请输选择岗位角色', trigger: 'blur' }
    ]
  },
  shortcuts:[{
    text: '今天',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime())
      return [start, end]
    }
  }, {
    text: '昨天',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 1)
      return [start, end]
    }
  }, {
    text: '最近两天',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 2)
      return [start, end]
    }
  }, {
    text: '最近三天',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 3)
      return [start, end]
    }
  }, {
    text: '最近一周',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 7)
      return [start, end]
    }
  }, {
    text: '最近一个月',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 30)
      return [start, end]
    }
  }, {
    text: '最近两个月',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 60)
      return [start, end]
    }
  }]
})

const { queryParams, editFrom, rules ,shortcuts} = toRefs(data);
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
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  var seachdata = {
    CurrenetPageIndex: queryParams.value.CurrenetPageIndex,
    PageSize: queryParams.value.PageSize,
    Keywords: queryParams.value.Keywords,
    Order: queryParams.value.Order,
    Sort: queryParams.value.Sort,
    CreatorTime1: queryParams.value.CreateTime !== '' ? searchform.value.CreateTime[0] : '',
    CreatorTime2: queryParams.value.CreateTime !== '' ? searchform.value.CreateTime[1] : '',
    RoleId: queryParams.value.RoleId
  }
  getUserListWithPager(seachdata).then(res => {
    tableData.value = res.ResData.Items
    queryParams.value.pageTotal = res.ResData.TotalItems
    tableloading.value = false
  })
}
/**
 * 点击查询
 */
function handleSearch() {
  queryParams.value.CurrenetPageIndex = 1
  loadTableData()
}

/** 重置查询操作 */
function resetQuery() {
  proxy.resetForm("searchformRef");
  handleSearch();
}
// 表单重置
function reset() {
  editFrom.value = {
    Account: '',
    RealName: '',
    NickName: '',
    Gender: 1,
    Birthday: '',
    MobilePhone: '',
    Email: '',
    WeChat: '',
    DepartmentId: '',
    RoleId: '',
    IsAdministrator: true,
    EnabledMark: true,
    Description: ''
  }
  selectedOrganizeOptions.value = ''
  proxy.resetForm('editFromRef')
}
/**
 * 新增、修改或查看明细信息（绑定显示数据）     *
 */
function ShowEditOrViewDialog(view) {
  reset()
  if (view !== undefined) {
    if (ids.value.length > 1 || ids.value.length === 0) {
      proxy.$modal.alert('请选择一条数据进行编辑/修改')
    } else {
      currentId.value = ids.value[0]
      editFormTitle.value = '编辑'
      dialogEditFormVisible.value = true
      bindEditInfo()
    }
  } else {
    editFormTitle.value = '新增'
    currentId.value = ''
    selectedOrganizeOptions.value = ''
    dialogEditFormVisible.value = true
  }
}
function bindEditInfo() {
  getUserDetail(currentId.value).then(res => {
    editFrom.value = res.ResData
    editFrom.value.RoleId = res.ResData.RoleId.split(',')
    selectedOrganizeOptions.value = res.ResData.DepartmentId
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      const data =editFrom.value
      data.RoleId=editFrom.value.RoleId.join(',')
      var url = 'User/Insert'
      if (currentId.value !== '') {
        url = 'User/Update'
      }
      saveUser(data, url).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          dialogEditFormVisible.value = false
          selectedOrganizeOptions.value = ''
          loadTableData()
        } else {
          proxy.$modal.msgError(res.ErrMsg)
        }
      })
    } else {
      return false
    }
  })
}
function setEnable(val) {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    setUserEnable(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function deleteSoft(val) {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    deleteSoftUser(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function deletePhysics() {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value
      }
      return deleteUser(data)
    }).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
/**
 * 当表格的排序条件发生变化的时候会触发该事件
 */
function handleSortChange(column) {
  if(column.prop!=null){
    queryParams.value.Sort = column.prop
  }
  if (column.order === 'ascending') {
    queryParams.value.Order = 'asc'
  } else {
    queryParams.value.Order = 'desc'
  }
  loadTableData()
}
/**
 * 当用户手动勾选checkbox数据行事件
 */
function handleSelectChange(selection) {
  ids.value = selection.map(item => item.Id);
  single.value = selection.length != 1;
  multiple.value = !selection.length;
}

/**
 *选择组织
  */
function handleSelectOrganizeChange() {
  editFrom.value.DepartmentId = selectedOrganizeOptions.value
}
function handleResetPassword(val) {
  if (ids.value.length > 1 || ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      userId: ids.value[0]
    }
    resetPassword(data).then(res => {
      if (res.Success) {
        proxy.$modal.alertSuccess('重置密码成功，新密为' + res.ErrMsg)
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
InitDictItem()
loadTableData()
</script>
