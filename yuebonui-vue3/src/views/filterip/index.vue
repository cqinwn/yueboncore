<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" 
      :inline="true"
      :model="searchform"
      class="demo-form-inline"
    >
      <el-form-item label="IP地址" prop="name">
        <el-input v-model="searchform.name" clearable placeholder="IP地址" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button
          v-hasPermi="['FilterIP/Add']"
          type="primary"
          icon="plus"
          @click="ShowEditOrViewDialog()"
        >新增</el-button>
        <el-button
          v-hasPermi="['FilterIP/Edit']"
          type="primary"
          icon="edit"
          :disabled="single" 
          class="el-button-modify"
          @click="ShowEditOrViewDialog('edit')"
        >修改</el-button>
        <el-button
          v-hasPermi="['FilterIP/Enable']"
          type="info"
          :disabled="multiple" 
          icon="video-pause"
          @click="setEnable('0')"
        >禁用</el-button>
        <el-button
          v-hasPermi="['FilterIP/Enable']"
          type="success"
          :disabled="multiple" 
          icon="video-play"
          @click="setEnable('1')"
        >启用</el-button>
        <el-button
          v-hasPermi="['FilterIP/DeleteSoft']"
          type="warning"
          :disabled="multiple" 
          icon="delete"
          @click="deleteSoft('0')"
        >软删除</el-button>
        <el-button
          v-hasPermi="['FilterIP/Delete']"
          type="danger"
          :disabled="multiple" 
          icon="delete"
          @click="deletePhysics()"
        >删除</el-button>
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
      <el-table-column type="selection" width="55" />
      <el-table-column prop="FilterType" label="控制策略" sortable="custom" width="120">
        <template #default="scope">
          <el-tag
            :type="scope.row.FilterType === true ? 'success' : 'info'"
            disable-transitions
          >{{ scope.row.FilterType===true?'允许访问':'拒绝访问' }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="StartIP" label="起始IP" sortable="custom" width="150" />
      <el-table-column prop="EndIP" label="结束IP" sortable="custom" width="150" />
      <el-table-column prop="SortCode" label="排序" sortable="custom" width="120" />
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
      draggable
      :title="editFormTitle"
      v-model="dialogEditFormVisible"
      width="640px"
    >
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="控制策略" :label-width="formLabelWidth" prop="FilterType">
          <el-select v-model="editFrom.FilterType" placeholder="请选择">
            <el-option label="允许访问" :value="true" />
            <el-option label="拒绝访问" :value="false" />
          </el-select>
        </el-form-item>
        <el-form-item label="起始IP" :label-width="formLabelWidth" prop="StartIP">
          <el-input v-model="editFrom.StartIP" placeholder="请输入起始IP" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="结束IP" :label-width="formLabelWidth" prop="EndIP">
          <el-input v-model="editFrom.EndIP" placeholder="请输入结束IP地址" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
          <el-input
            v-model.number="editFrom.SortCode"
            placeholder="请输入排序,默认为99"
            autocomplete="off"
            clearable
          />
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

<script setup name="FilterIP">
import { getFilterIPListWithPager, getFilterIPDetail, saveFilterIP, setFilterIPEnable,
  deleteSoftFilterIP, deleteFilterIP } from '@/api/security/filteripservice'


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
    sort: 'SortCode'
  },
  editFrom:{},
  rules: {
    FilterType: [
      { required: true, message: '请选择控制策略', trigger: 'blur' }
    ],
    StartIP: [
      { required: true, message: '请输入起始IP地址', trigger: 'blur' },
      { min: 7, max: 15, message: '长度在 7 到 15 个字符', trigger: 'blur' }
    ],
    EndIP: [
      { required: true, message: '请输入结束IP地址', trigger: 'blur' },
      { min: 7, max: 15, message: '长度在 7 到 15 个字符', trigger: 'blur' }
    ]
  }
})
const { searchform, editFrom, rules ,pagination,sortableData} = toRefs(data);

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
  getFilterIPListWithPager(seachdata).then(res => {
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
    FilterType: false,
    StartIP: '',
    EndIP: '',
    SortCode: 99,
    EnabledMark: true,
    Description: ''
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
  getFilterIPDetail(currentId.value).then(res => {
    editFrom.value = res.ResData
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      var url = 'FilterIP/Insert'
      if (currentId.value !== '') {
        url = 'FilterIP/Update'
      }
      saveFilterIP(editFrom.value, url).then(res => {
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
    setFilterIPEnable(data).then(res => {
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
    deleteSoftFilterIP(data).then(res => {
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
      return deleteFilterIP(data)
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
