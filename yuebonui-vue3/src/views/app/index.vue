<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="queryParams" class="demo-form-inline">
      <el-form-item label="应用名称：" prop="Keywords">
        <el-input v-model="queryParams.Keywords" clearable placeholder="应用AppId或授权Url" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['APP/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
        <el-button v-hasPermi="['APP/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify"
          @click="ShowEditOrViewDialog('edit')">修改</el-button>
        <el-button v-hasPermi="['APP/Enable']" type="info" icon="video-pause" :disabled="multiple"
          @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['APP/Enable']" type="success" icon="video-play" :disabled="multiple"
          @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['APP/DeleteSoft']" type="warning" icon="delete" :disabled="multiple"
          @click="deleteSoft('0')">软删除</el-button>
        <el-button v-hasPermi="['APP/Delete']" type="danger" icon="delete" :disabled="multiple"
          @click="deletePhysics()">删除</el-button>

        <el-button v-hasPermi="['APP/ResetAppSecret']" type="primary" icon="refresh-right" :disabled="single"
          @click="haddlerResetAppSecret()">重置AppSecret</el-button>

        <el-button v-hasPermi="['APP/ResetEncodingAESKey']" type="primary" icon="refresh-right" :disabled="single"
          @click="haddlerResetEncodingAESKey()">重置消息密钥</el-button>
      </el-button-group>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="loadTableData"></right-toolbar>
    </el-row>
    <el-table v-loading="tableloading" :data="tableData" stripe highlight-current-row style="width: 100%"
      :default-sort="{prop: 'SortCode', order: 'ascending'}" @selection-change="handleSelectChange"
      @sort-change="handleSortChange">
      <el-table-column type="selection" width="55" />
      <el-table-column prop="AppId" label="应用Id" sortable="custom" width="130" fixed />
      <el-table-column prop="AppSecret" label="AppSecret" sortable="custom" width="320" fixed />
      <el-table-column prop="Token" label="Token" sortable="custom" width="150" />
      <el-table-column label="消息加密" sortable="custom" width="120" prop="IsOpenAEKey" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.IsOpenAEKey === true ? 'success' : 'info'" disable-transitions>{{
            scope.row.IsOpenAEKey===true?'启用':'禁用' }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="RequestUrl" label="授权URL" sortable="custom" />
      <el-table-column label="启用" sortable="custom" width="90" prop="EnabledMark" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{
            scope.row.EnabledMark===true?'启用':'禁用' }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="是否删除" sortable="custom" width="120" prop="DeleteMark" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.DeleteMark === true ? 'danger' : 'success'" disable-transitions>{{
            scope.row.DeleteMark===true?'已删除':'否' }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="CreatorTime" label="创建时间" sortable width="170" />
      <el-table-column prop="LastModifyTime" label="更新时间" sortable width="170" />
    </el-table>
    <Pagination 
    v-show="queryParams.pageTotal>0" 
    :total="queryParams.pageTotal"
    v-model:page="queryParams.CurrenetPageIndex" 
    v-model:limit="queryParams.PageSize" 
    @pagination="loadTableData" />
    <el-dialog :title="editFormTitle+'应用'" v-model="dialogEditFormVisible">
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="应用Id" :label-width="formLabelWidth" prop="AppId">
          <el-input v-model="editFrom.AppId" placeholder="请输入应用Id" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="应用Secret" :label-width="formLabelWidth" prop="AppSecret">
          <el-input v-model="editFrom.AppSecret" placeholder="系统自动生成" readonly autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="消息加密密钥" :label-width="formLabelWidth" prop="EncodingAESKey">
          <el-input v-model="editFrom.EncodingAESKey" placeholder="系统自动生成" readonly autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="Token" :label-width="formLabelWidth" prop="Token">
          <el-input v-model="editFrom.Token" placeholder="请输入Token" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="选项" :label-width="formLabelWidth" prop="">
          <el-checkbox v-model="editFrom.EnabledMark">启用</el-checkbox>
          <el-checkbox v-model="editFrom.IsOpenAEKey">启用消息加密</el-checkbox>
        </el-form-item>
        <el-form-item label="授权Url" :label-width="formLabelWidth" prop="RequestUrl">
          <el-input v-model="editFrom.RequestUrl" type="textarea" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="描述" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" type="textarea" autocomplete="off" clearable />
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

<script setup name="app">
import { getAPPListWithPager, getAPPDetail, saveAPP, setAPPEnable,
  deleteSoftAPP, deleteAPP, resetAppSecret, resetEncodingAESKey } from '@/api/developers/appservice'


const { proxy } = getCurrentInstance()
const loadBtnFunc=ref([])
const tableData=ref([])
const tableloading=ref(true)
const dialogEditFormVisible=ref(false)
const editFormTitle=ref("")
      
const formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);

const data = reactive({
  queryParams:{
    CurrenetPageIndex: 1,
    PageSize: 20,
    pageTotal: 0,
    Order: 'desc',
    Sort: 'CreatorTime',
    Keywords: ''
  },
  editFrom: {},
  rules: {
    AppId: [
      { required: true, message: '请输入应用AppId', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
    ],
    Token: [
      { required: true, message: '请输入Token', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
    ]
  }
})

const { editFrom, rules ,queryParams} = toRefs(data);

/**
 * 初始化数据
 */
function InitDictItem() {
  loadBtnFunc.value = JSON.parse(localStorage.getItem('yueboncurrentfuns'))
}
/**
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  getAPPListWithPager(queryParams.value).then(res => {
    tableData.value = res.ResData.Items
    queryParams.value.pageTotal = res.ResData.TotalItems
    tableloading.value = false
  })
}
/**
 * 点击查询
 */
function handleSearch(){
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
  if (!currentId.value) {
    editFrom.value = {
      AppId: '',
      AppSecret: '',
      EncodingAESKey: '',
      RequestUrl: '',
      Token: '',
      IsOpenAEKey: false,
      EnabledMark: true,
      Description: ''
    }
    proxy.resetForm("editFromRef")
  } else {
    bindEditInfo()
  }
}
/**
 * 新增、修改或查看明细信息（绑定显示数据）     *
 */
function ShowEditOrViewDialog(view) {
  if (view !== undefined) {
    if (ids.value.length > 1 || ids.value.length === 0) {
      proxy.$modal.alert('请选择一条数据进行编辑/修改')
    } else {
      currentId.value = ids.value[0]
      editFormTitle.value = '编辑'
      dialogEditFormVisible.value = true
    }
  } else {
    editFormTitle.value = '新增'
    currentId.value = ''
    dialogEditFormVisible.value = true
  }
  reset()
}
function bindEditInfo() {
  getAPPDetail(currentId.value).then(res => {
    editFrom.value = res.ResData
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      const data = {
        'AppId': editFrom.value.AppId,
        'AppSecret': editFrom.value.AppSecret,
        'EncodingAESKey': editFrom.value.EncodingAESKey,
        'RequestUrl': editFrom.value.RequestUrl,
        'Token': editFrom.value.Token,
        'IsOpenAEKey': editFrom.value.IsOpenAEKey,
        'EnabledMark': editFrom.value.EnabledMark,
        'Description': editFrom.value.Description,
        'Id': currentId.value
      }
      var url = 'APP/Insert'
      if (currentId.value !== '') {
        url = 'APP/Update'
      }
      saveAPP(data, url).then(res => {
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
function setEnable(val) {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    setAPPEnable(data).then(res => {
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
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value,
        Flag: val
      }
      return deleteSoftAPP(data)
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
function deletePhysics() {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value
      }
      return deleteAPP(data)
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
    queryParams.Order = 'asc'
  } else {
    queryParams.Order = 'desc'
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
function haddlerResetAppSecret() {
  if (ids.value.length === 0 || ids.value.length > 1) {
    proxy.$modal.alert('请选择一条数据进行重置')
    return false
  } else {
    const data = {
      id: ids.value[0]
    }
    resetAppSecret(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        ids.value = ''
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function haddlerResetEncodingAESKey() {
  if (ids.value.length === 0 || ids.value.length > 1) {
    proy.$modal.alert('请选择一条数据进行重置')
    return false
  } else {
    const data = {
      id: ids.value[0]
    }
    resetEncodingAESKey(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        ids.value = ''
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
