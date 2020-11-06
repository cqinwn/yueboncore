<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form ref="searchform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
          <el-form-item label="任务名称：">
            <el-input v-model="searchform.name" clearable placeholder="任务名称或分组" />
          </el-form-item>
          <el-form-item>
            <el-button type="primary" @click="handleSearch()">查询</el-button>
          </el-form-item>
        </el-form>
      </el-card>
    </div>
    <el-card>
      <div class="list-btn-container">
        <el-button-group>
          <slot v-for="itemf in loadBtnFunc">
            <el-button v-if="itemf.FullName === '新增'" type="primary" icon="el-icon-plus" size="small" @click="ShowEditOrViewDialog()">新增</el-button>
            <el-button v-if="itemf.FullName === '修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="small" @click="ShowEditOrViewDialog('edit')">修改</el-button>
            <el-button v-if="itemf.EnCode == 'TaskManager/ChangeStatus'" type="info" icon="el-icon-video-pause" size="small" @click="setStatus('0')">暂停</el-button>
            <el-button v-if="itemf.EnCode == 'TaskManager/ChangeStatus'" type="success" icon="el-icon-video-play" size="small" @click="setStatus('1')">启动</el-button>
            <el-button v-if="itemf.FullName == '禁用'" type="info" icon="el-icon-video-pause" size="small" @click="setEnable('0')">禁用</el-button>
            <el-button v-if="itemf.FullName == '启用'" type="success" icon="el-icon-video-play" size="small" @click="setEnable('1')">启用</el-button>
            <el-button v-if="itemf.FullName === '软删除'" type="warning" icon="el-icon-delete" size="small" @click="deleteSoft('0')">软删除</el-button>
            <el-button v-if="itemf.FullName === '删除'" type="danger" icon="el-icon-delete" size="small" @click="deletePhysics()">删除</el-button>
          </slot>
          <el-button type="default" icon="el-icon-refresh" size="small" @click="loadTableData()">刷新</el-button>
        </el-button-group>
      </div>
      <el-table ref="gridtable" v-loading="tableloading" :data="tableData" border stripe highlight-current-row style="width: 100%" :default-sort="{ prop: 'Id', order: 'ascending' }" @select="handleSelectChange" @select-all="handleSelectAllChange" @sort-change="handleSortChange">
        <el-table-column type="selection" width="30" />
        <el-table-column prop="Id" label="任务Id" sortable="custom" width="100" />
        <el-table-column prop="TaskName" label="任务名称" sortable="custom" width="150" />
        <el-table-column prop="GroupName" label="分组名称" sortable="custom" width="150" />
        <el-table-column prop="Cron" label="Cron表达式" sortable="custom" width="130" />
        <el-table-column label="状态" sortable="custom" width="90" prop="Status" align="center">
          <template slot-scope="scope">
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
          <template slot-scope="scope">
            <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{ scope.row.EnabledMark === true ? "启用" : "禁用" }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column label="是否删除" sortable="custom" width="120" prop="DeleteMark" align="center">
          <template slot-scope="scope">
            <el-tag :type="scope.row.DeleteMark === true ? 'danger' : 'success'" disable-transitions>{{ scope.row.DeleteMark === true ? "已删除" : "否" }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column prop="CreatorTime" label="创建时间" sortable width="160" />
        <el-table-column prop="LastModifyTime" label="更新时间" sortable width="160" />
        <el-table-column fixed="right" label="操作" width="100">
          <template slot-scope="scope">
            <el-button type="text" size="small" @click="handleShowLogs(scope.row)">查看日志</el-button>
          </template>
        </el-table-column>
      </el-table>
      <div class="pagination-container">
        <el-pagination background :current-page="pagination.currentPage" :page-sizes="[5, 10, 20, 50, 100, 200, 300, 400]" :page-size="pagination.pagesize" layout="total, sizes, prev, pager, next, jumper" :total="pagination.pageTotal" @size-change="handleSizeChange" @current-change="handleCurrentChange" />
      </div>
    </el-card>
    <el-dialog ref="dialogEditForm" :title="editFormTitle + '任务'" :visible.sync="dialogEditFormVisible" width="640px">
      <el-form ref="editFrom" :model="editFrom" :rules="rules">
        <el-form-item label="任务名称" :label-width="formLabelWidth" prop="TaskName">
          <el-input v-model="editFrom.TaskName" placeholder="请输入任务名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="分组名称" :label-width="formLabelWidth" prop="GroupName">
          <el-input v-model="editFrom.GroupName" placeholder="请输入分组名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="起止时间" :label-width="formLabelWidth" prop="StartEndTime">
          <el-date-picker v-model="editFrom.StartEndTime" type="datetimerange" start-placeholder="开始时间" end-placeholder="结束结束" :default-time="['12:00:00']" />
        </el-form-item>
        <el-form-item label="Cron表达式" :label-width="formLabelWidth" prop="Cron">
          <el-input v-model="editFrom.Cron" placeholder="请输入Cron表达式" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="任务执行方式" :label-width="formLabelWidth" prop="IsLocal">
          <el-radio-group v-model="editFrom.IsLocal" @change="changeIsLocal">
            <el-radio label="true">本地任务</el-radio>
            <el-radio label="false">外部接口任务</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item v-if="isShowSelect === 'true'" label="任务地址" :label-width="formLabelWidth" prop="JobCallAddress">
          <el-select v-model="editFrom.JobCallAddress" clearable filterable placeholder="请输入任务地址" style="width: 300px">
            <el-option v-for="item in selectLocalTask" :key="item.FullName" :label="item.FullName" :value="item.FullName" />
          </el-select>
        </el-form-item>
        <el-form-item v-if="isShowSelect !== 'true'" label="任务地址" :label-width="formLabelWidth" prop="JobCallAddress">
          <el-input v-model="editFrom.JobCallAddress" placeholder="请输入外部接口任务地址" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="任务参数" :label-width="formLabelWidth" prop="JobCallParams">
          <el-input v-model="editFrom.JobCallParams" type="textarea" placeholder="请输入任务参数，JSON格式,为空时请求访问方式为get，反之为post" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="描述" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" type="textarea" autocomplete="off" clearable />
        </el-form-item>

        <el-form-item label="邮件通知" :label-width="formLabelWidth" prop="IsSendMail">
          <el-radio-group v-model="editFrom.SendMail">
            <el-radio label="0">不通知</el-radio>
            <el-radio label="1">异常通知</el-radio>
            <el-radio label="2">所有通知</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item v-if="editFrom.SendMail != '0'" label="Email地址" :label-width="formLabelWidth" prop="EmailAddress">
          <el-input v-model="editFrom.EmailAddress" placeholder="接收通知邮件多个用英文逗号隔开，为空默认系统配置邮箱" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="是否启用" :label-width="formLabelWidth" prop="EnabledMark">
          <el-radio-group v-model="editFrom.EnabledMark">
            <el-radio label="true">是</el-radio>
            <el-radio label="false">否</el-radio>
          </el-radio-group>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditForm()">确 定</el-button>
      </div>
    </el-dialog>

    <el-dialog ref="dialogShowLogForm" :title="editFormTitle + '任务日志最近40条记录'" :visible.sync="dialogShowLogFormVisible" width="940px">
      <el-timeline>
        <el-timeline-item v-for="(activity, index) in activities" :key="index" :color="activity.Color" :timestamp="activity.CreatorTime">
          {{ activity.Description }}
        </el-timeline-item>
      </el-timeline>
    </el-dialog>
  </div>
</template>

<script>

import {
  getTaskManagerListWithPager, getTaskManagerDetail,
  saveTaskManager, setTaskManagerEnable, deleteSoftTaskManager,
  deleteTaskManager, changeStatus, getLocalTaskJobs, getTaskJobLogListWithPager
} from '@/api/security/taskmanager'

export default {
  data () {
    return {
      searchform: {
        name: ''
      },
      loadBtnFunc: [],
      selectLocalTask: [],
      tableData: [],
      tableloading: true,
      pagination: {
        currentPage: 1,
        pagesize: 20,
        pageTotal: 0
      },
      sortableData: {
        order: 'desc',
        sort: 'Id'
      },
      dialogEditFormVisible: false,
      dialogShowLogFormVisible: false,
      editFormTitle: '',
      editFrom: {
        TaskName: '',
        GroupName: '',
        Cron: '',
        JobCallAddress: '',
        JobCallParams: '',
        EnabledMark: 'true',
        IsLocal: 'true',
        Description: '',
        SendMail: '0',
        EmailAddress: '',
        StartTime: '',
        EndTime: '',
        StartEndTime: ''
      },
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
      },
      formLabelWidth: '120px',
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: [],
      isShowSelect: 'true',
      activities: [],
      reverse: true
    }
  },
  created () {
    this.pagination.currentPage = 1
    this.InitDictItem()
    this.loadTableData()
    this.loadBtnFunc = JSON.parse(localStorage.getItem('yueboncurrentfuns'))
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem () {
      getLocalTaskJobs().then(res => {
        this.selectLocalTask = res.ResData
      })
    },
    /**
     * 加载页面table数据
     */
    loadTableData: function () {
      this.tableloading = true
      var seachdata = {
        CurrenetPageIndex: this.pagination.currentPage,
        PageSize: this.pagination.pagesize,
        Keywords: this.searchform.name,
        Order: this.sortableData.order,
        Sort: this.sortableData.sort
      }
      getTaskManagerListWithPager(seachdata).then(res => {
        this.tableData = res.ResData.Items
        this.pagination.pageTotal = res.ResData.TotalItems
        this.tableloading = false
      })
    },
    /**
     * 点击查询
     */
    handleSearch: function () {
      this.pagination.currentPage = 1
      this.loadTableData()
    },
    changeIsLocal: function () {
      this.isShowSelect = this.editFrom.IsLocal
      this.editFrom.JobCallAddress = ''
    },
    handleShowLogs: function (row) {
      this.dialogShowLogFormVisible = true
      this.loadJobLogData(row)
    },
    /**
     * 加载页面table数据
     */
    loadJobLogData: function (row) {
      var seachdata = {
        'Keywords': row.Id
      }
      getTaskJobLogListWithPager(seachdata).then(res => {
        this.activities = res.ResData
      })
    },
    /**
     * 新增、修改或查看明细信息（绑定显示数据）     *
     */
    ShowEditOrViewDialog: function (view) {
      if (view !== undefined) {
        if (this.currentSelected.length > 1 || this.currentSelected.length === 0) {
          this.$alert('请选择一条数据进行编辑/修改', '提示')
        } else {
          this.currentId = this.currentSelected[0].Id
          this.editFormTitle = '编辑'
          this.dialogEditFormVisible = true
          this.bindEditInfo()
        }
      } else {
        this.editFormTitle = '新增'
        this.currentId = ''
        this.dialogEditFormVisible = true
      }
    },
    bindEditInfo: function () {
      getTaskManagerDetail(this.currentId).then(res => {
        this.editFrom.TaskName = res.ResData.TaskName
        this.editFrom.GroupName = res.ResData.GroupName
        this.editFrom.Cron = res.ResData.Cron
        this.editFrom.JobCallParams = res.ResData.JobCallParams
        this.editFrom.EnabledMark = res.ResData.EnabledMark + ''
        this.editFrom.IsLocal = res.ResData.IsLocal + ''
        this.editFrom.Description = res.ResData.Description
        this.editFrom.JobCallAddress = res.ResData.JobCallAddress
        this.editFrom.SendMail = res.ResData.SendMail + ''
        this.editFrom.EmailAddress = res.ResData.EmailAddress
        this.isShowSelect = res.ResData.IsLocal + ''
        this.editFrom.StartEndTime = [res.ResData.StartTime, res.ResData.EndTime]
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm () {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'TaskName': this.editFrom.TaskName,
            'GroupName': this.editFrom.GroupName,
            'Cron': this.editFrom.Cron,
            'JobCallAddress': this.editFrom.JobCallAddress,
            'JobCallParams': this.editFrom.JobCallParams,
            'StartTime': this.editFrom.StartEndTime[0],
            'EndTime': this.editFrom.StartEndTime[1],
            'IsLocal': this.editFrom.IsLocal,
            'Description': this.editFrom.Description,
            'SendMail': this.editFrom.SendMail,
            'EmailAddress': this.editFrom.EmailAddress,
            'EnabledMark': this.editFrom.EnabledMark,
            'Id': this.currentId
          }
          var url = 'TaskManager/Insert'
          if (this.currentId !== '') {
            url = 'TaskManager/Update?id=' + this.currentId
          }
          saveTaskManager(data, url).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogEditFormVisible = false
              this.currentSelected = ''
              this.editFrom.StartEndTime = ''
              this.$refs['editFrom'].resetFields()
              this.loadTableData()
              this.InitDictItem()
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
    },
    setEnable: function (val) {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = []
        this.currentSelected.forEach(element => {
          currentIds.push(element.Id)
        })
        const data = {
          Ids: currentIds,
          Flag: val
        }
        setTaskManagerEnable(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    deleteSoft: function (val) {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = []
        this.currentSelected.forEach(element => {
          currentIds.push(element.Id)
        })
        const data = {
          Ids: currentIds,
          Flag: val
        }
        deleteSoftTaskManager(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    deletePhysics: function () {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = []
        this.currentSelected.forEach(element => {
          currentIds.push(element.Id)
        })
        const data = {
          Ids: currentIds
        }
        deleteTaskManager(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    // 启动/暂停
    setStatus: function (val) {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = this.currentSelected[0].Id
        const data = {
          Id: currentIds,
          Status: val
        }
        changeStatus(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    /**
     * 当表格的排序条件发生变化的时候会触发该事件
     */
    handleSortChange: function (column) {
      this.sortableData.sort = column.prop
      if (column.order === 'ascending') {
        this.sortableData.order = 'asc'
      } else {
        this.sortableData.order = 'desc'
      }
      this.loadTableData()
    },
    /**
     * 当用户手动勾选checkbox数据行事件
     */
    handleSelectChange: function (selection, row) {
      this.currentSelected = selection
    },
    /**
     * 当用户手动勾选全选checkbox事件
     */
    handleSelectAllChange: function (selection) {
      this.currentSelected = selection
    },
    /**
     * 选择每页显示数量
     */
    handleSizeChange (val) {
      this.pagination.pagesize = val
      this.pagination.currentPage = 1
      this.loadTableData()
    },
    /**
     * 选择当页面
     */
    handleCurrentChange (val) {
      this.pagination.currentPage = val
      this.loadTableData()
    }
  }
}
</script>

<style>
</style>
