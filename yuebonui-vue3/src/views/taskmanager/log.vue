<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="queryParams" class="demo-form-inline">
      <el-form-item label="任务名称：" prop="name">
        <el-input v-model="queryParams.name" clearable placeholder="任务Id或任务名称" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['TaskJobsLog/Delete']" type="danger" icon="delete" :disabled="multiple"
          @click="deletePhysics()">删除</el-button>
      </el-button-group>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="loadTableData"></right-toolbar>
    </el-row>
    <el-table ref="gridtable" v-loading="tableloading" :data="tableData" stripe highlight-current-row
      style="width: 100%" :default-sort="{ prop: 'CreatorTime', order: 'ascending' }"
      @selection-change="handleSelectChange" @sort-change="handleSortChange">
      <el-table-column type="selection" width="50" />
      <el-table-column prop="TaskId" label="任务Id" sortable="custom" width="150" />
      <el-table-column prop="TaskName" label="任务名称" sortable="custom" width="220" />
      <el-table-column prop="JobAction" label="执行动作" sortable="custom" width="120" />
      <el-table-column prop="Status" label="执行状态" sortable="custom" width="120">
        <template #default="scope">
          <el-tag :type="scope.row.Status === true ? 'success' : 'info'" disable-transitions>{{ scope.row.Status ===
            true ? "正常" : "异常" }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="CreatorTime" label="创建时间" sortable="custom" width="160" />
      <el-table-column prop="Resume" label="简述" sortable="custom" />
      <el-table-column fixed="right" label="操作" width="60">
        <template #default="scope">
          <el-button type="primary" link @click="showDetailDialog(scope.row)">详情</el-button>
        </template>
      </el-table-column>
    </el-table>
    <Pagination v-show="queryParams.pageTotal>0" :total="queryParams.pageTotal"
      v-model:page="queryParams.CurrenetPageIndex" v-model:limit="queryParams.PageSize" @pagination="loadTableData" />
    <el-dialog ref="dialogEditForm" :title="editFormTitle + '详情'" v-model="dialogEditFormVisible"
      width="640px">
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="任务Id" :label-width="formLabelWidth" prop="TaskId">
          <el-input v-model="editFrom.TaskId" placeholder="请输入任务Id" autocomplete="off" readonly />
        </el-form-item>
        <el-form-item label="任务名称" :label-width="formLabelWidth" prop="TaskName">
          <el-input v-model="editFrom.TaskName" placeholder="请输入任务名称" autocomplete="off" readonly />
        </el-form-item>
        <el-form-item label="执行动作" :label-width="formLabelWidth" prop="JobAction">
          <el-input v-model="editFrom.JobAction" placeholder="请输入执行动作" autocomplete="off" readonly />
        </el-form-item>
        <el-form-item label="执行状态" :label-width="formLabelWidth" prop="Status">
          <el-radio-group v-model="editFrom.Status">
            <el-radio :label="true">正常</el-radio>
            <el-radio :label="false">异常</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item label="简述" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Resume" autocomplete="off" readonly />
        </el-form-item>
        <el-form-item label="返回消息" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" show-word-limit :rows="20" type="textarea"
            autocomplete="off" readonly />
        </el-form-item>
        <el-form-item label="创建时间" :label-width="formLabelWidth" prop="CreatorTime">
          <el-input v-model="editFrom.CreatorTime" placeholder="请输入创建时间" autocomplete="off" readonly />
        </el-form-item>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button @click="dialogEditFormVisible = false">取 消</el-button>
        </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="TaskJobsLog">
import {
  getTaskJobsLogListWithPager,
  getTaskJobsLogDetail,
  saveTaskJobsLog,
  setTaskJobsLogEnable,
  deleteSoftTaskJobsLog,
  deleteTaskJobsLog
} from '@/api/security/taskjobslog'


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
  queryParams:{
    CurrenetPageIndex: 1,
    PageSize: 20,
    pageTotal: 0,
    Order: 'desc',
    Sort: 'CreatorTime',
    Keywords: ''
  },
  editFrom:{},
  rules: {
    TaskId: [
      { required: true, message: '请输入任务Id', trigger: 'blur' },
      {
        min: 2,
        max: 50,
        message: '长度在 2 到 50 个字符',
        trigger: 'blur'
      }
    ],
    Status: [
      {
        required: true,
        message: '请输入执行状态 正常、异常',
        trigger: 'blur'
      },
      {
        min: 2,
        max: 50,
        message: '长度在 2 到 50 个字符',
        trigger: 'blur'
      }
    ],
    CreatorTime: [
      { required: true, message: '请输入创建时间', trigger: 'blur' },
      {
        min: 2,
        max: 50,
        message: '长度在 2 到 50 个字符',
        trigger: 'blur'
      }
    ]
  }
})
const {editFrom, rules ,queryParams} = toRefs(data);

/**
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  getTaskJobsLogListWithPager(queryParams.value).then((res) => {
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
    Status: true
  }
  proxy.resetForm('editFromRef')
}
/**
 * 新增、修改或查看明细信息（绑定显示数据）     *
 */
function showDetailDialog(row) {
  reset()
  getTaskJobsLogDetail(row.Id).then((res) => {
    editFrom.value = res.ResData
  })
  dialogEditFormVisible.value = true
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
      return deleteTaskJobsLog(data)
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
function handleSelectChange(selection, row) {
  ids.value = selection.map(item => item.Id);
  single.value = selection.length != 1;
  multiple.value = !selection.length;
}
loadTableData()
</script>

<style>
</style>
