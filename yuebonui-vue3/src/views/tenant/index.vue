<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="searchform" class="demo-form-inline">
      <el-form-item label="名称：" prop="name">
        <el-input v-model="searchform.name" clearable placeholder="名称" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['Tenant/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
        <el-button v-hasPermi="['Tenant/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify" @click="ShowEditOrViewDialog('edit')">修改</el-button>
        <el-button v-hasPermi="['Tenant/InitTenantData']" type="primary" icon="Refresh" :disabled="single" @click="handerInit()">初始化</el-button>
        <el-button v-hasPermi="['Tenant/Enable']" type="info" icon="video-pause" :disabled="multiple" @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['Tenant/Enable']" type="success" icon="video-play" :disabled="multiple" @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['Tenant/DeleteSoft']" type="warning" icon="delete" :disabled="multiple" @click="deleteSoft('0')">软删除</el-button>
        <el-button v-hasPermi="['Tenant/Delete']" type="danger" icon="delete" :disabled="multiple" @click="deletePhysics()">删除</el-button>
      </el-button-group>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="loadTableData"></right-toolbar>
    </el-row>
    <el-table ref="gridtable" v-loading="tableloading" :data="tableData" stripe highlight-current-row style="width: 100%" :default-sort="{ prop: 'CreatorTime', order: 'ascending' }" @selection-change="handleSelectChange">
      <el-table-column type="selection" width="55" />
      <el-table-column prop="TenantName" label="租户账号" sortable="custom" width="120" />
      <el-table-column prop="CompanyName" label="公司名称" sortable="custom" width="180" />
      <el-table-column prop="TenantType" label="租户类型" sortable="custom" width="120" >
        <template #default="scope">
          <el-tag v-if="scope.row.TenantType === 0">普通租户</el-tag>
          <el-tag v-if="scope.row.TenantType === 1">系统租户</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="Schema" label="数据架构" sortable="custom" width="120" >
        <template #default="scope">
          <el-tag v-if="scope.row.Schema === 0">共享数据库</el-tag>
          <el-tag v-if="scope.row.Schema === 1">独立数据库</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="HostDomain" label="访问域名" sortable="custom" width="180" />
      <el-table-column prop="LinkMan" label="联系人" sortable="custom" width="120" />
      <el-table-column prop="Telphone" label="联系电话" sortable="custom" width="120" />
      <el-table-column prop="Description" label="租户介绍" sortable="custom" width="220" />
      <el-table-column label="是否启用" sortable="custom" width="120" prop="EnabledMark" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{ scope.row.EnabledMark === true ? "启用" : "禁用" }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="是否删除" sortable="custom" width="120" prop="DeleteMark" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.DeleteMark === true ? 'danger' : 'success'" disable-transitions>{{ scope.row.DeleteMark === true ? "已删除" : "否" }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="CreatorTime" label="创建时间" sortable width="160" />
      <el-table-column prop="LastModifyTime" label="更新时间" sortable width="160" />
    </el-table>
    <Pagination
      v-show="pagination.pageTotal>0"
      :total="pagination.pageTotal"
      :page="pagination.currentPage"
      :limit="pagination.pageSize"
      @pagination="loadTableData"
    />
    <el-dialog ref="dialogEditForm" :title="editFormTitle + '租户'" v-model="dialogEditFormVisible" width="640px">
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="租户账号" :label-width="formLabelWidth" prop="TenantName">
          <el-input v-model="editFrom.TenantName" placeholder="请输入租户账号" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="公司名称" :label-width="formLabelWidth" prop="CompanyName">
          <el-input v-model="editFrom.CompanyName" placeholder="请输入公司名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="访问域名" :label-width="formLabelWidth" prop="HostDomain">
          <el-input v-model="editFrom.HostDomain" placeholder="请输入访问域名" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="租户类型" :label-width="formLabelWidth" prop="TenantType">
          <el-select v-model="editFrom.TenantType" class="m-2" placeholder="请选择">
            <el-option
              v-for="item in selectTenantType"
              :key="item.Value"
              :label="item.Label"
              :value="item.Value"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="数据架构" :label-width="formLabelWidth" prop="TenantType">
          <el-select v-model="editFrom.Schema" class="m-2" placeholder="请选择">
            <el-option
              v-for="item in selectSchema"
              :key="item.Value"
              :label="item.Label"
              :value="item.Value"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="联系人" :label-width="formLabelWidth" prop="LinkMan">
          <el-input v-model="editFrom.LinkMan" placeholder="请输入联系人" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="联系电话" :label-width="formLabelWidth" prop="Telphone">
          <el-input v-model="editFrom.Telphone" placeholder="请输入联系电话" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="数据源" :label-width="formLabelWidth" prop="DataSource">
          <el-input v-model="editFrom.DataSource" placeholder="请输入数据源，分库使用" type="textarea" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="是否可用" :label-width="formLabelWidth" prop="EnabledMark">
          <el-radio-group v-model="editFrom.EnabledMark">
            <el-radio :label="true">是</el-radio>
            <el-radio :label="false">否</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item label="租户介绍" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" placeholder="请输入租户介绍" type="textarea" autocomplete="off" clearable />
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

<script setup name="Tenant">
import {
  getTenantListWithPager,
  getTenantDetail,
  saveTenant,
  setTenantEnable,
  deleteSoftTenant,
  deleteTenant,
  initTenantData
} from '@/api/security/tenant'


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

const data = reactive({
  selectTenantType:[{
    Value:0,
    Label:"普通租户"
  },{
    Value:1,
    Label:"系统租户"
  }],
  selectSchema:[{
    Value:0,
    Label:"共享数据库"
  },{
    Value:1,
    Label:"独立数据库"
  }],
  searchform: {
    name: ''
  },
  pagination: {
    currentPage: 1,
    pageSize: 20,
    pageTotal: 0
  },
  sortableData: {
    order: 'desc',
    sort: 'CreatorTime'
  },
  editFrom:{},
  rules: {
    TenantName: [
      { required: true, message: '请输入租户名称', trigger: 'blur' },
      {
        min: 2,
        max: 50,
        message: '长度在 2 到 50 个字符',
        trigger: 'blur'
      }
    ],
    HostDomain: [
      { required: true, message: '请输入访问域名', trigger: 'blur' },
      {
        min: 2,
        max: 50,
        message: '长度在 2 到 50 个字符',
        trigger: 'blur'
      }
    ]
  }
})
const { selectTenantType,selectSchema,searchform, editFrom, rules ,pagination,sortableData} = toRefs(data);

/**
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  var seachdata = {
    CurrenetPageIndex: pagination.value.currentPage,
    PageSize: pagination.value.pageSize,
    Keywords: searchform.value.name,
    Order: sortableData.value.order,
    Sort: sortableData.value.sort
  }
  getTenantListWithPager(seachdata).then((res) => {
    tableData.value = res.ResData.Items
    pagination.value.pageTotal = res.ResData.TotalItems
    tableloading.value = false
  })
}
/**
 * 点击查询
 */
function handleSearch() {
  pagination.value.currentPage = 1
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
    TenantName: '',
    CompanyName: '',
    HostDomain: '',
    LinkMan: '',
    Telphone: '',
    DataSource: '',
    Description: '',
    EnabledMark: true
  }
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
    dialogEditFormVisible.value = true
  }
}
function bindEditInfo() {
  getTenantDetail(currentId.value).then((res) => {
    editFrom.value = res.ResData
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      var url = 'Tenants/Tenant/Insert'
      if (currentId.value !== '') {
        url = 'Tenants/Tenant/Update'
      }
      saveTenant(editFrom.value, url).then((res) => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          dialogEditFormVisible.value = false
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

function handerInit(){
  if (ids.value.length > 1 || ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    proxy.$modal.confirm('你确定要初始化该租户所有产品，初始化后数据将清空?').then(function() {
      return initTenantData(ids.value[0])
    }).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
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
    setTenantEnable(data).then((res) => {
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
    deleteSoftTenant(data).then((res) => {
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
      return deleteTenant(data)
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
    sortableData.value.sort = column.prop
  }
  if (column.order === 'ascending') {
    sortableData.value.order = 'asc'
  } else {
    sortableData.value.order = 'desc'
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
loadTableData()
</script>

<style>
</style>
