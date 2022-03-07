<template>
  <div class="app-container">
    <el-form
      ref="searchformRef" v-show="showSearch"
      :inline="true"
      :model="searchform"
      class="demo-form-inline"
    >
      <el-form-item label="业务单据名称：" prop="name">
        <el-input v-model="searchform.name" clearable placeholder="业务单据名称" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['Sequence/Add']" type="primary" icon="plus"  @click="ShowEditOrViewDialog()">新增</el-button>
        <el-button v-hasPermi="['Sequence/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify"  @click="ShowEditOrViewDialog('edit')">修改</el-button>
        <el-button v-hasPermi="['Sequence/Enable']" type="info" icon="video-pause" :disabled="multiple"   @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['Sequence/Enable']" type="success" icon="video-play" :disabled="multiple"  @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['Sequence/DeleteSoft']" type="warning" icon="delete" :disabled="multiple"  @click="deleteSoft('0')">软删除</el-button>
        <el-button v-hasPermi="['Sequence/Delete']" type="danger" icon="delete" :disabled="multiple"  @click="deletePhysics()">删除</el-button>
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
      :default-sort="{prop: 'SortCode', order: 'ascending'}"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
    >
      <el-table-column type="selection" width="50" />
      <el-table-column prop="SequenceName" label="业务单据名称" sortable="custom" width="180" />
      <el-table-column prop="SequenceDelimiter" label="分隔符" sortable="custom" width="90" />
      <el-table-column prop="SequenceReset" label="重置规则" sortable="custom" width="120">
        <template #default="scope">
          <el-tag v-if="scope.row.SequenceReset==='D'">每天</el-tag>
          <el-tag v-else-if="scope.row.SequenceReset==='M'">每月</el-tag>
          <el-tag v-else-if="scope.row.SequenceReset==='Y'">每年</el-tag>
          <el-tag v-else />
        </template>
      </el-table-column>
      <el-table-column prop="Step" label="步长" sortable="custom" width="80" />
      <el-table-column prop="CurrentNo" label="当前值" sortable="custom" width="90" />
      <el-table-column prop="CurrentCode" label="当前编码" sortable="custom" width="200" />
      <el-table-column prop="CurrentReset" label="当前重置依赖" sortable="custom" width="150" />
      <el-table-column prop="Description" label="描述" sortable="custom" width="280" />
      <el-table-column
        label="是否启用"
        sortable="custom"
        width="120"
        prop="EnabledMark"
        align="center"
      >
        <template #default="scope">
          <el-tag
            :type="scope.row.EnabledMark === true ? 'success' : 'info'"
            disable-transitions
          >{{ scope.row.EnabledMark===true?'启用':'禁用' }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column
        label="是否删除"
        sortable="custom"
        width="120"
        prop="DeleteMark"
        align="center"
      >
        <template #default="scope">
          <el-tag
            :type="scope.row.DeleteMark === true ? 'danger' : 'success'"
            disable-transitions
          >{{ scope.row.DeleteMark===true?'已删除':'否' }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column
        prop="CreatorTime"
        label="创建时间"
        sortable
        width="160"
      />
      <el-table-column
        prop="LastModifyTime"
        label="更新时间"
        sortable
        width="160"
      />
    </el-table>
    <Pagination
      v-show="pagination.pageTotal>0"
      :total="pagination.pageTotal"
      :page="pagination.currentPage"
      :limit="pagination.pageSize"
      @pagination="loadTableData"
    />
    <el-dialog
      ref="dialogEditForm"
      :title="editFormTitle+'业务单据号规则'"
      v-model="dialogEditFormVisible"
    >
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="单据名称" :label-width="formLabelWidth" prop="SequenceName">
          <el-input v-model="editFrom.SequenceName" placeholder="请输入业务单据名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="分隔符" :label-width="formLabelWidth" prop="SequenceDelimiter">
          <el-input v-model="editFrom.SequenceDelimiter" placeholder="请输入分隔符" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="重置规则" :label-width="formLabelWidth" prop="SequenceReset">
          <el-select v-model="editFrom.SequenceReset" clearable placeholder="请选重置规则">
            <el-option
              v-for="item in selectSequenceReset"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="步长" :label-width="formLabelWidth" prop="Step">
          <el-input v-model="editFrom.Step" placeholder="请输入步长" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="当前值" :label-width="formLabelWidth" prop="CurrentNo">
          <el-input v-model="editFrom.CurrentNo" placeholder="请输入当前值" autocomplete="off" readonly="readonly" />
        </el-form-item>
        <el-form-item label="当前编码" :label-width="formLabelWidth" prop="CurrentCode">
          <el-input v-model="editFrom.CurrentCode" placeholder="请输入当前编码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="是否启用" :label-width="formLabelWidth" prop="EnabledMark">
          <el-radio-group v-model="editFrom.EnabledMark">
            <el-radio :label="true">是</el-radio>
            <el-radio :label="false">否</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item label="描述" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" autocomplete="off" clearable />
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

<script setup name="Sequence">

import { getSequenceListWithPager, getSequenceDetail,
  saveSequence, setSequenceEnable, deleteSoftSequence,
  deleteSequence } from '@/api/security/sequence'

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

const selectSequenceType=ref([])
const data = reactive({
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
    SequenceName: [
      { required: true, message: '请输入业务单据名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ]
  },
  selectSequenceReset: [{
    value: 'D',
    label: '每天'
  }, {
    value: 'M',
    label: '每月'
  }, {
    value: 'Y',
    label: '每年'
  }
  ]
})
const { searchform, editFrom, rules ,pagination,sortableData,selectSequenceReset} = toRefs(data);

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
  getSequenceListWithPager(seachdata).then(res => {
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
  if (!currentId.value) {
    editFrom.value = {
      SequenceName: '',
      SequenceDelimiter: '',
      SequenceReset: '',
      Step: 1,
      CurrentNo: 0,
      CurrentCode: '',
      CurrentReset: '',
      Description: '',
      EnabledMark: true
    }
    proxy.resetForm('editFromRef')
  } else {
    bindEditInfo()
  }
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
      dialogEditFormVisible .value= true
      bindEditInfo()
    }
  } else {
    editFormTitle.value = '新增'
    currentId.value = ''
    dialogEditFormVisible.value = true
  }
}
function bindEditInfo() {
  getSequenceDetail(currentId.value).then(res => {
    editFrom.value = res.ResData
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      var url = 'Sequence/Insert'
      if (currentId.value !== '') {
        url = 'Sequence/Update'
      }
      saveSequence(editFrom.value, url).then(res => {
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
    setSequenceEnable(data).then(res => {
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
    deleteSoftSequence(data).then(res => {
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
      return deleteSequence(data)
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
    sortableData.order = 'asc'
  } else {
    sortableData.order = 'desc'
  }
  loadTableData()
}
/**
 * 当用户手动勾选checkbox数据行事件
 */
function handleSelectChange(selection, row) {
  ids.value = selection.map(item => item.Id);
  single.value = selection.length != 1;
  multiple.value = !selection.length;
}
loadTableData()
</script>

<style>
</style>
