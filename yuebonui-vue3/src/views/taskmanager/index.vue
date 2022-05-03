<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="searchform" class="demo-form-inline" size="small">
      <el-form-item label="任务名称：" prop="name">
        <el-input v-model="searchform.name" clearable placeholder="任务名称或分组" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['TaskManager/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
        <el-button v-hasPermi="['TaskManager/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify" @click="ShowEditOrViewDialog('edit')">修改</el-button>
        <el-button v-hasPermi="['TaskManager/Enable']" type="info" icon="video-pause"  :disabled="multiple" @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['TaskManager/Enable']" type="success" icon="video-play" :disabled="multiple" @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['TaskManager/DeleteSoft']" type="warning" icon="delete" :disabled="multiple" @click="deleteSoft('0')">软删除</el-button>
        <el-button v-hasPermi="['TaskManager/Delete']" type="danger" icon="delete" :disabled="multiple" @click="deletePhysics()">删除</el-button>
        <el-button v-hasPermi="['TaskManager/ChangeStatus']" type="info" icon="video-pause" :disabled="multiple" @click="setStatus('0')">暂停</el-button>
        <el-button v-hasPermi="['TaskManager/ChangeStatus']" type="success" icon="video-play" :disabled="multiple" @click="setStatus('1')">启动</el-button>
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
      :default-sort="{ prop: 'Id', order: 'ascending' }"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
      @row-click="handleRowClick"
    >
      <el-table-column type="selection" width="30" />
      <el-table-column prop="Id" label="任务ID" sortable="custom" width="150" />
      <el-table-column prop="TaskName" label="任务名称" sortable="custom" width="150" />
      <el-table-column prop="GroupName" label="分组名称" sortable="custom" width="150" />
      <el-table-column prop="Cron" label="Cron表达式" sortable="custom" width="130" />
      <el-table-column label="状态" sortable="custom" width="90" prop="Status" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.Status === 1 ? 'success' : 'danger'" disable-transitions>{{ scope.row.Status === 1 ? "正在运行" : "暂停" }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="Description" label="简述" sortable="custom" width="110" />
      <el-table-column prop="JobCallAddress" label="任务地址" sortable="custom" width="180" />
      <el-table-column prop="StartTime" label="任务开始时间" sortable width="160" />
      <el-table-column prop="EndTime" label="任务结束时间" sortable width="160" />
      <el-table-column prop="LastRunTime" label="最近执行时间" sortable width="160" />
      <el-table-column prop="NextRunTime" label="下次执行时间" sortable width="160" />
      <el-table-column prop="RunCount" label="执行次数" sortable="custom" width="110" />
      <el-table-column prop="ErrorCount" label="出错次数" sortable="custom" width="110" />
      <el-table-column prop="LastErrorTime" label="出错时间" sortable width="160" />
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
      <el-table-column fixed="right" label="操作" width="100">
        <template #default="scope">
          <el-button type="text" @click="handleShowLogs(scope.row)">查看日志</el-button>
        </template>
      </el-table-column>
    </el-table>
    <Pagination
      v-show="pagination.pageTotal>0"
      :total="pagination.pageTotal"
      :page="pagination.currentPage"
      :limit="pagination.pageSize"
      @pagination="loadTableData"
    />
    <el-dialog ref="dialogEditForm" :title="editFormTitle + '任务'" v-model="dialogEditFormVisible" width="880px" append-to-body>
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-row>
          <el-col :span="12">
            <el-form-item label="任务名称" :label-width="formLabelWidth" prop="TaskName">
              <el-input v-model="editFrom.TaskName" placeholder="请输入任务名称" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="分组名称" :label-width="formLabelWidth" prop="GroupName">
              <el-input v-model="editFrom.GroupName" placeholder="请输入分组名称" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item label="起止时间" :label-width="formLabelWidth" prop="StartEndTime">
              <el-date-picker v-model="editFrom.StartEndTime" type="datetimerange" start-placeholder="开始时间" end-placeholder="结束结束" :default-time="['12:00:00']" />
            </el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item label="Cron表达式" :label-width="formLabelWidth" prop="Cron">
              <template #reference>
                <el-input
                  @focus="togglePopover(true)"
                  v-model="editFrom.Cron"
                  placeholder="请输入Cron表达式"
                ></el-input>
              </template>
              <el-popover v-model:visible="cronPopover"  trigger="manual">
              <vue3Cron @change="changeCron" @close="togglePopover(false)" max-height="400px" i18n="cn"></vue3Cron>
              </el-popover>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="执行方式" :label-width="formLabelWidth" prop="IsLocal">
              <el-radio-group v-model="editFrom.IsLocal" @change="changeIsLocal">
                <el-radio :label="true">本地任务</el-radio>
                <el-radio :label="false">外部接口任务</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item v-if="isShowSelect" label="任务地址" :label-width="formLabelWidth" prop="JobCallAddress">
              <el-select v-model="editFrom.JobCallAddress" clearable filterable placeholder="请输入任务地址" style="width: 300px">
                <el-option v-for="item in selectLocalTask" :key="item.FullName" :label="item.FullName" :value="item.FullName" />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item v-if="!isShowSelect" label="任务地址" :label-width="formLabelWidth" prop="JobCallAddress">
              <el-input v-model="editFrom.JobCallAddress" placeholder="请输入外部接口任务地址" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item label="任务参数" :label-width="formLabelWidth" prop="JobCallParams">
              <el-input v-model="editFrom.JobCallParams" type="textarea" placeholder="请输入任务参数，JSON格式,为空时请求访问方式为get，反之为post" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item label="描述" :label-width="formLabelWidth" prop="Description">
              <el-input v-model="editFrom.Description" type="textarea" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="邮件通知" :label-width="formLabelWidth" prop="IsSendMail">
              <el-radio-group v-model="editFrom.SendMail">
                <el-radio :label="0">不通知</el-radio>
                <el-radio :label="1">异常通知</el-radio>
                <el-radio :label="2">所有通知</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item v-if="editFrom.SendMail != '0'" label="Email地址" :label-width="formLabelWidth" prop="EmailAddress">
              <el-input v-model="editFrom.EmailAddress" placeholder="接收通知邮件多个用英文逗号隔开，为空默认系统配置邮箱" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="是否启用" :label-width="formLabelWidth" prop="EnabledMark">
              <el-radio-group v-model="editFrom.EnabledMark">
                <el-radio :label="true">是</el-radio>
                <el-radio :label="false">否</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button @click="dialogEditFormVisible = false">取 消</el-button>
          <el-button type="primary" @click="saveEditForm()">确 定</el-button>
        </div>
      </template>
    </el-dialog>

    <el-dialog ref="dialogShowLogForm" :title="editFormTitle + '任务日志最近40条记录'" v-model="dialogShowLogFormVisible" width="940px">
      <el-timeline>
        <el-timeline-item v-for="(activity, index) in activities" :key="index" :color="activity.Color" :timestamp="activity.CreatorTime">
          {{ activity.Description }}
        </el-timeline-item>
      </el-timeline>
    </el-dialog>
  </div>
</template>

<script setup name="TaskManager">
import {
  getTaskManagerListWithPager, getTaskManagerDetail,
  saveTaskManager, setTaskManagerEnable, deleteSoftTaskManager,
  deleteTaskManager, changeStatus, getLocalTaskJobs, getTaskJobLogListWithPager
} from '@/api/security/taskmanager'

import { Vue3Cron } from 'vue3-cron'
import { ref } from '@vue/reactivity'
//import 'vue3-cron/lib/vue3Cron.css' // 引入样式

const { proxy } = getCurrentInstance()
const tableData=ref([])
const tableloading=ref(true)
const dialogEditFormVisible=ref(false)
const editFormTitle=ref("")
const showSearch = ref(true)
const single = ref(true)
const multiple = ref(true)

const formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])


const selectLocalTask=ref([])
const dialogShowLogFormVisible=ref(false)

const isShowSelect = ref(true)
const activities=ref([])
const reverse = ref(true)
const cronPopover=ref(false)
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
    TaskName: [
      { required: true, message: '请输入任务名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    GroupName: [
      { required: true, message: '请输入分组名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    StartEndTime: [
      { required: true, message: '请设置任务起止时间', trigger: 'blur' }
    ],
    Cron: [
      { required: true, message: '请输入Cron表达式', trigger: 'blur' },
      { min: 1, max: 50, message: '长度在 1 到 50 个字符', trigger: 'blur' }
    ],
    JobCallAddress: [
      { required: true, message: '请输入远程接口地址', trigger: 'blur' },
      { min: 1, max: 250, message: '长度在 1 到 50 个字符', trigger: 'blur' }
    ]
  }
})
const { searchform, editFrom, rules ,pagination,sortableData} = toRefs(data);

/**
 * 初始化数据
 */
function InitDictItem() {
  getLocalTaskJobs().then(res => {
    selectLocalTask.value = res.ResData
  })
}
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
  getTaskManagerListWithPager(seachdata).then(res => {
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
function changeIsLocal() {
  isShowSelect.value= editFrom.value.IsLocal
  editFrom.value.JobCallAddress = ''
}
function handleShowLogs(row) {
  dialogShowLogFormVisible.value = true
  loadJobLogData(row)
}
/**
 * 加载页面table数据
 */
function loadJobLogData(row) {
  var seachdata = {
    'Keywords': row.Id
  }
  getTaskJobLogListWithPager(seachdata).then(res => {
    activities.value = res.ResData
  })
}
// 表单重置
function reset() {
  if (!currentId.value) {
    editFrom.value = {
      TaskName: '',
      GroupName: '',
      Cron: '',
      JobCallAddress: '',
      JobCallParams: '',
      EnabledMark: true,
      IsLocal: true,
      Description: '',
      SendMail: 1,
      EmailAddress: '',
      StartTime: '',
      EndTime: '',
      StartEndTime: ''
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
  getTaskManagerDetail(currentId).then(res => {
    editFrom.value = res.ResData
    isShowSelect.value = res.ResData.IsLocal
    editFrom.value.StartEndTime = [res.ResData.StartTime, res.ResData.EndTime]
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFrom'].validate((valid) => {
    if (valid) {
      const data = {
        'TaskName': editFrom.TaskName,
        'GroupName': editFrom.GroupName,
        'Cron': editFrom.Cron,
        'JobCallAddress': editFrom.JobCallAddress,
        'JobCallParams': editFrom.JobCallParams,
        'StartTime': editFrom.StartEndTime[0],
        'EndTime': editFrom.StartEndTime[1],
        'IsLocal': editFrom.IsLocal,
        'Description': editFrom.Description,
        'SendMail': editFrom.SendMail,
        'EmailAddress': editFrom.EmailAddress,
        'EnabledMark': editFrom.EnabledMark,
        'Id': currentId
      }
      var url = 'TaskManager/Insert'
      if (currentId.value !== '') {
        url = 'TaskManager/Update'
      }
      saveTaskManager(data, url).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          dialogEditFormVisible.value = false
          editFrom.value.StartEndTime = ''
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
    setTaskManagerEnable(data).then(res => {
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
    deleteSoftTaskManager(data).then(res => {
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
      return deleteTaskManager(data)
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
// 启动/暂停
function setStatus(val) {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Id: ids.value[0],
      Status: val
    }
    changeStatus(data).then(res => {
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
/**
 * 单击行
 */
function handleRowClick(row, column, event) {
  currentId.value = row.Id
}
const changeCron = (val) => {
  if(typeof(val) !== 'string') return false
  editFrom.val.Cron = val
}
const togglePopover = (bol) => {
  cronPopover.value = bol
}
InitDictItem()
loadTableData()
</script>


<style lang="scss" scoped>
.cron {
  width: 400px;
  margin: 0 auto;
  margin-top: 100px;
  h1 {
    font-size: 50px;
    text-align: center;
  }
}
</style>
