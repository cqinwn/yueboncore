<template>
  <div class="app-container">
    <el-form
      ref="searchformRef" v-show="showSearch"
      :inline="true"
      :model="queryParams"
      class="demo-form-inline"
    >
      <el-form-item :label="$t('app.title')" prop="Keywords">
        <el-input v-model="queryParams.Keywords" clearable :placeholder="$t('app.phTitle')" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">{{$t('button.btnSearch')}}</el-button>
        <el-button icon="Refresh" @click="resetQuery">{{$t('button.btnReset')}}</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button
          v-hasPermi="['APP/Add']"
          type="primary"
          icon="plus"
          @click="ShowEditOrViewDialog()"
        >{{$t('toolbar.btnAdd')}}</el-button>
        <el-button
          v-hasPermi="['APP/Edit']"
          type="primary"
          icon="edit"
          :disabled="single"
          class="el-button-modify"
          @click="ShowEditOrViewDialog('edit')"
        >{{$t('toolbar.btnModify')}}</el-button>
        <el-button
          v-hasPermi="['APP/Enable']"
          type="info"
          icon="video-pause"
          :disabled="multiple"
          @click="setEnable('0')"
        >{{$t('toolbar.btnDisable')}}</el-button>
        <el-button
          v-hasPermi="['APP/Enable']"
          type="success"
          icon="video-play"
          :disabled="multiple"
          @click="setEnable('1')"
        >{{$t('toolbar.btnEnable')}}</el-button>
        <el-button
          v-hasPermi="['APP/DeleteSoft']"
          type="warning"
          icon="delete"
          :disabled="multiple"
          @click="deleteSoft('0')"
        >{{$t('toolbar.btnSoftDelete')}}</el-button>
        <el-button
          v-hasPermi="['APP/Delete']"
          type="danger"
          icon="delete"
          :disabled="multiple"
          @click="deletePhysics()"
        >{{$t('toolbar.btnDelete')}}</el-button>

        <el-button
          v-hasPermi="['APP/ResetAppSecret']"
          type="primary"
          icon="refresh-right"
          :disabled="single"
          @click="haddlerResetAppSecret()"
        >{{$t('toolbar.btnResetAppSecret')}}</el-button>

        <el-button
          v-hasPermi="['APP/ResetEncodingAESKey']"
          type="primary"
          icon="refresh-right"
          :disabled="single"
          @click="haddlerResetEncodingAESKey()"
        >{{$t('toolbar.btnResetEncodingAESKey')}}</el-button>
      </el-button-group>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="loadTableData"></right-toolbar>
    </el-row>
    <el-table
      v-loading="tableloading"
      :data="tableData"
      stripe
      highlight-current-row
      style="width: 100%"
      :default-sort="{prop: 'SortCode', order: 'ascending'}"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
    >
      <el-table-column type="selection" width="55" />
      <el-table-column prop="AppId" :label="$t('app.appId')" sortable="custom" width="130" fixed />
      <el-table-column
        prop="AppSecret"
        :label="$t('app.appSecret')"
        sortable="custom"
        width="320"
        fixed
      />
      <el-table-column
        prop="Token"
        label="Token"
        sortable="custom"
        width="150"
      />
      <el-table-column
        :label="$t('app.isOpenAEKey')"
        sortable="custom"
        width="160"
        prop="IsOpenAEKey"
        align="center"
      >
        <template #default="scope">
          <el-tag
            :type="scope.row.IsOpenAEKey === true ? 'success' : 'info'"
            disable-transitions
          >{{ scope.row.IsOpenAEKey===true? $t('table.Yes') : $t('table.No') }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="RequestUrl" :label="$t('app.authUrl')" sortable="custom" width="420" />
      <el-table-column
        :label="$t('table.enable')"
        sortable="custom"
        width="90"
        prop="EnabledMark"
        align="center"
      >
        <template #default="scope">
          <el-tag
            :type="scope.row.EnabledMark === true ? 'success' : 'info'"
            disable-transitions
          >{{ scope.row.EnabledMark===true?$t('table.Yes'):$t('table.No') }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column
        :label="$t('table.removeStatus')"
        sortable="custom"
        width="120"
        prop="DeleteMark"
        align="center"
      >
      <template #default="scope">
        <el-tag
          :type="scope.row.DeleteMark === true ? 'danger' : 'success'"
          disable-transitions
        >{{ scope.row.DeleteMark===true?$t('table.Yes'):$t('table.No') }}</el-tag>
      </template>
      </el-table-column>
      <el-table-column
        :label="$t('table.createTime')"
        sortable
        width="170"
      />
      <el-table-column
        :label="$t('table.updateTime')"
        sortable
        width="170"
      />
    </el-table>
    <Pagination
      v-show="queryParams.pageTotal>0"
      :total="queryParams.pageTotal"
      v-model:page="queryParams.CurrenetPageIndex"
      v-model:limit="queryParams.PageSize"
      @pagination="loadTableData"
    />
    <el-dialog
      :title="editFormTitle+' '+$t('app.editFormTitle')"
      v-model="dialogEditFormVisible"
      draggable
    >
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item :label="$t('app.appId')" :label-width="formLabelWidth" prop="AppId">
          <el-input v-model="editFrom.AppId" :placeholder="$t('app.ruleAppId')" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item :label="$t('app.appSecret')" :label-width="formLabelWidth" prop="AppSecret">
          <el-input v-model="editFrom.AppSecret" :placeholder="$t('app.ruleAutoCreate')" readonly autocomplete="off" clearable />
        </el-form-item>
        <el-form-item :label="$t('app.encodingAESKey')" :label-width="formLabelWidth" prop="EncodingAESKey">
          <el-input v-model="editFrom.EncodingAESKey" :placeholder="$t('app.ruleAutoCreate')" readonly autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="Token" :label-width="formLabelWidth" prop="Token">
          <el-input v-model="editFrom.Token" :placeholder="$t('app.ruleToken')" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item :label="$t('app.option')" :label-width="formLabelWidth">
          <el-checkbox v-model="editFrom.EnabledMark">{{$t('table.enable')}}</el-checkbox>
          <el-checkbox v-model="editFrom.IsOpenAEKey">{{$t('app.isOpenAEKey')}}</el-checkbox>
        </el-form-item>
        <el-form-item :label="$t('app.authUrl')" :label-width="formLabelWidth" prop="RequestUrl">
          <el-input v-model="editFrom.RequestUrl" type="textarea" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item :label="$t('app.desc')" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" type="textarea" autocomplete="off" clearable />
        </el-form-item>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button @click="dialogEditFormVisible = false">{{$t('button.btnCancel')}}</el-button>
          <el-button type="primary" @click="saveEditForm()">{{$t('button.btnSave')}}</el-button>
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
      { required: true, message: proxy.$t('app.ruleAppId'), trigger: 'blur' },
      { min: 4, max: 32, message: proxy.$t('app.ruleAppIdLengTip'), trigger: 'blur' }
    ],
    Token: [
      { required: true, message: proxy.$t('app.ruleToken'), trigger: 'blur' },
      { min: 4, max: 32, message: proxy.$t('app.ruleTokenLengTip'), trigger: 'blur' }
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
      proxy.$modal.alert(proxy.$t('message.editAlertTips'))
    } else {
      currentId.value = ids.value[0]
      editFormTitle.value = proxy.$t('editform.edit')
      dialogEditFormVisible.value = true
    }
  } else {
    editFormTitle.value = proxy.$t('editform.add')
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
          proxy.$modal.msgSuccess(proxy.$t('message.successTips'))
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
    proxy.$modal.alert(proxy.$t('message.alertTips1'))
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    setAPPEnable(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess(proxy.$t('message.successTips'))
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}

function deleteSoft(val) {
  if (ids.value.length === 0) {
    proxy.$modal.alert(proxy.$t('message.alertTips1'))
    return false
  } else {
    proxy.$modal.confirm(proxy.$t('message.deleteTips')).then(function() {
      const data = {
        Ids: ids.value,
        Flag: val
      }
      return deleteSoftAPP(data)
    }).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess(proxy.$t('message.successTips'))
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function deletePhysics() {
  if (ids.value.length === 0) {
    proxy.$modal.alert(proxy.$t('message.alertTips1'))
    return false
  } else {
    proxy.$modal.confirm(proxy.$t('message.deleteTips')).then(function() {
      const data = {
        Ids: ids.value
      }
      return deleteAPP(data)
    }).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess(proxy.$t('message.successTips'))
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
function haddlerResetAppSecret() {
  if (ids.value.length === 0 || ids.value.length > 1) {
    proxy.$modal.alert(proxy.$t('message.selectDataTips'))
    return false
  } else {
    const data = {
      id: ids.value[0]
    }
    resetAppSecret(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess(proxy.$t('message.successTips'))
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
    proy.$modal.alert(proxy.$t('message.selectDataTips'))
    return false
  } else {
    const data = {
      id: ids.value[0]
    }
    resetEncodingAESKey(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess(proxy.$t('message.successTips'))
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
