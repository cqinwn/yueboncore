<template>
  <div class="app-container">
    <el-form
      :inline="true"
      :model="searchform"
      class="demo-form-inline"
      ref="searchformRef" v-show="showSearch"
    >
      <el-form-item label="文件名称" prop="name">
        <el-input v-model="searchform.name" clearable placeholder="文件名称" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="handleSearch">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
        <el-button-group>
          <el-button v-hasPermi="['UploadFile/Delete']" :disabled=multiple type="danger" icon="delete" @click="deletePhysics()">删除</el-button>
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
      :default-sort="{prop: 'CreatorTime', order: 'ascending'}"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
    >
      <el-table-column type="selection" width="55" />
      <el-table-column prop="FileName" label="文件名称" sortable="custom" width="350" fixed>
        <template #default="scope">
          <el-image :src="httpfileUrl+scope.row.FilePath"></el-image>
        </template>
      </el-table-column>
      <el-table-column prop="FilePath" label="文件路径" sortable="custom" width="450" />
      <el-table-column prop="FileType" label="文件类型" sortable="custom" width="150" />
      <el-table-column prop="FileSize" label="文件大小" sortable="custom" width="150" />
      <el-table-column prop="Extension" label="扩展名" sortable="custom" width="150" />
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
    </el-table>
    <Pagination
      v-show="pagination.pageTotal>0"
      :total="pagination.pageTotal"
      :page="pagination.currentPage"
      :limit="pagination.pageSize"
      @pagination="loadTableData"
    />
  </div>
</template>

<script setup name="UploadFile">
import { getUploadFileListWithPager, deleteUploadFile } from '@/api/security/uploadfileservice'
import defaultSettings from '@/settings'

const { proxy } = getCurrentInstance()
const tableData=ref([])
const tableloading=ref(true)
const showSearch = ref(true);
const multiple = ref(true);

const ids=ref([])
const httpfileUrl=ref(defaultSettings.fileUrl) 
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
  }
})

const { searchform,pagination,sortableData} = toRefs(data);

/**
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  var seachdata = {
    CurrenetPageIndex:pagination.value.currentPage,
    PageSize:pagination.value.pageSize,
    Keywords:searchform.value.name,
    Order:sortableData.value.order,
    Sort:sortableData.value.sort
  }
  getUploadFileListWithPager(seachdata).then(res => {
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

function deletePhysics() {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value
      }
      return deleteUploadFile(data)
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
  multiple.value = !selection.length;
}
loadTableData()
</script>

<style>
</style>
