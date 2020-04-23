<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form ref="searchform" :inline="true" :model="searchform" class="demo-form-inline" size="small">

          <el-form-item label="角色">
            <el-select v-model="searchform.RoleId" clearable placeholder="请选择">
              <el-option
                v-for="item in selectRole"
                :key="item.Id"
                :label="item.FullName"
                :value="item.Id"
              />
            </el-select>
          </el-form-item>
          <el-form-item label="用户信息：">
            <el-input v-model="searchform.Keywords" clearable placeholder="账号/姓名/昵称/电话" />
          </el-form-item>
          <el-form-item label="注册日期：">
            <el-date-picker
              v-model="searchform.CreateTime"
              type="daterange"
              align="right"
              value-format="yyyy-MM-dd"
              unlink-panels
              range-separator="至"
              start-placeholder="开始日期"
              end-placeholder="结束日期"
              :picker-options="pickerOptions"
            />
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
            <el-button v-if="itemf.FullName==='新增'" type="primary" icon="el-icon-plus" size="small" @click="ShowEditOrViewDialog()">新增</el-button>
            <el-button v-if="itemf.FullName==='修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="small" @click="ShowEditOrViewDialog('edit')">修改</el-button>
            <el-button v-if="itemf.FullName=='禁用'" type="info" icon="el-icon-video-pause" size="small" @click="setEnable('0')">禁用</el-button>
            <el-button v-if="itemf.FullName=='启用'" type="success" icon="el-icon-video-play" size="small" @click="setEnable('1')">启用</el-button>
            <el-button v-if="itemf.FullName==='软删除'" type="warning" icon="el-icon-delete" size="small" @click="deleteSoft('0')">软删除</el-button>
            <el-button v-if="itemf.FullName==='删除'" type="danger" icon="el-icon-delete" size="small" @click="deletePhysics()">删除</el-button>
            <el-button v-if="itemf.FullName==='重置密码'" type="primary" icon="el-icon-refresh-right" class="el-button-modify" size="small" @click="handleResetPassword()">重置密码</el-button>
          </slot>
          <el-button type="default" icon="el-icon-refresh" size="small" @click="loadTableData()">刷新</el-button>
        </el-button-group>
      </div>
      <el-table
        ref="gridtable"
        v-loading="tableloading"
        :data="tableData"
        border
        stripe
        highlight-current-row
        style="width: 100%"
        :default-sort="{prop: 'SortCode', order: 'descending'}"
        @select="handleSelectChange"
        @select-all="handleSelectAllChange"
        @sort-change="handleSortChange"
      >
        <el-table-column
          type="selection"
          width="30"
        />
        <el-table-column
          prop="Account"
          label="账号/用户名"
          sortable="custom"
          width="230"
          fixed
        />
        <el-table-column
          prop="RealName"
          label="真实姓名"
          sortable="custom"
          width="180"
          fixed
        />
        <el-table-column
          prop="NickName"
          label="昵称"
          sortable="custom"
          width="180"
          fixed
        />
        <el-table-column
          prop="Gender"
          label="性别"
          sortable="custom"
          width="90"
          align="center"
        >
          <template slot-scope="scope">
            {{ scope.row.Gender=== 1 ? '男' : '女' }}
          </template>
        </el-table-column>
        <el-table-column
          prop="Birthday"
          label="生日"
          sortable="custom"
          width="120"
          align="center"
          :formatter="dateformatter"
        />
        <el-table-column
          prop="MobilePhone"
          label="手机号码"
          sortable="custom"
          width="120"
          align="center"
        />
        <el-table-column
          prop="OrganizeName"
          label="所属组织"
          sortable="custom"
          width="260"
          align="center"
        />
        <el-table-column
          prop="RoleName"
          label="岗位角色"
          sortable="custom"
          width="280"
          align="center"
        />
        <el-table-column
          label="可用"
          sortable="custom"
          width="90"
          prop="EnabledMark"
          align="center"
        >
          <template slot-scope="scope">
            <el-tag
              :type="scope.row.EnabledMark === true ? 'success' : 'info'"
              disable-transitions
            >{{ scope.row.EnabledMark===true?'启用':'禁用' }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column
          label="删除"
          sortable="custom"
          width="90"
          prop="DeleteMark"
          align="center"
        >
          <template slot-scope="scope">
            <el-tag
              :type="scope.row.DeleteMark === true ? 'danger' : 'success'"
              disable-transitions
            >{{ scope.row.DeleteMark===true?'已删除':'否' }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column
          prop="CreatorTime"
          label="添加时间"
          width="180"
          sortable
        />
        <el-table-column
          prop="LastModifyTime"
          label="更新时间"
          width="180"
          sortable
        >
          <template slot-scope="scope">
            {{ scope.row.LastModifyTime }}
          </template>
        </el-table-column>
      </el-table>
      <div class="pagination-container">
        <el-pagination
          background
          :current-page="pagination.currentPage"
          :page-sizes="[5,10,20,50,100, 200, 300, 400]"
          :page-size="pagination.pagesize"
          layout="total, sizes, prev, pager, next, jumper"
          :total="pagination.pageTotal"
          @size-change="handleSizeChange"
          @current-change="handleCurrentChange"
        />
      </div>
    </el-card>
    <el-dialog ref="dialogEditForm" :title="editFormTitle+'用户'" :visible.sync="dialogEditFormVisible" width="660px">
      <el-form ref="editFrom" :inline="true" :model="editFrom" :rules="rules" class="demo-form-inline">
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
            <el-radio label="1">男</el-radio>
            <el-radio label="0">女</el-radio>
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
          <el-date-picker
            v-model="editFrom.Birthday"
            type="date"
            placeholder="选择日期"
          />
        </el-form-item>
        <el-form-item label="选项" :label-width="formLabelWidth" prop="">
          <el-checkbox v-model="editFrom.EnabledMark">启用</el-checkbox>
          <el-checkbox v-model="editFrom.IsAdministrator">管理员</el-checkbox>
        </el-form-item>
        <el-form-item label="所属组织" :label-width="formLabelWidth" prop="OrganizeId">
          <el-cascader
            v-model="selectedOrganizeOptions"
            style="width:500px;"
            :options="selectOrganize"
            filterable
            :props="{label:'FullName',value:'Id',children:'Children',emitPath:false, checkStrictly: true,expandTrigger: 'hover' }"
            clearable
            @change="handleSelectOrganizeChange"
          />
        </el-form-item>
        <el-form-item label="岗位角色" :label-width="formLabelWidth" prop="RoleId">
          <el-select
            v-model="editFrom.RoleId"
            style="width:500px"
            multiple
            clearable
            placeholder="请选择"
          >
            <el-option
              v-for="item in selectRole"
              :key="item.Id"
              :label="item.FullName"
              :value="item.Id"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="备注" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" style="width:500px" placeholder="" autocomplete="off" clearable />
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditForm()">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>

import { getUserListWithPager, getUserDetail, saveUser, setUserEnable, deleteSoftUser, deleteUser, resetPassword } from '@/api/user/userservice'
import * as fecha from 'element-ui/lib/utils/date'
import { getAllRoleList } from '@/api/role/roleservice'
import { getAllOrganizeTreeTable } from '@/api/organize/organizeservice'

export default {
  data() {
    return {
      searchform: {
        RoleId: '',
        Keywords: '',
        CreateTime: ''
      },
      selectRole: [],
      selectedOrganizeOptions: '',
      selectOrganize: [],
      pickerOptions: {
        shortcuts: [{
          text: '今天',
          onClick(picker) {
            const end = new Date()
            const start = new Date()
            start.setTime(start.getTime())
            picker.$emit('pick', [start, end])
          }
        }, {
          text: '昨天',
          onClick(picker) {
            const end = new Date()
            const start = new Date()
            start.setTime(start.getTime() - 3600 * 1000 * 24 * 1)
            picker.$emit('pick', [start, end])
          }
        }, {
          text: '最近两天',
          onClick(picker) {
            const end = new Date()
            const start = new Date()
            start.setTime(start.getTime() - 3600 * 1000 * 24 * 2)
            picker.$emit('pick', [start, end])
          }
        }, {
          text: '最近三天',
          onClick(picker) {
            const end = new Date()
            const start = new Date()
            start.setTime(start.getTime() - 3600 * 1000 * 24 * 3)
            picker.$emit('pick', [start, end])
          }
        }, {
          text: '最近一周',
          onClick(picker) {
            const end = new Date()
            const start = new Date()
            start.setTime(start.getTime() - 3600 * 1000 * 24 * 7)
            picker.$emit('pick', [start, end])
          }
        }, {
          text: '最近一个月',
          onClick(picker) {
            const end = new Date()
            const start = new Date()
            start.setTime(start.getTime() - 3600 * 1000 * 24 * 30)
            picker.$emit('pick', [start, end])
          }
        }, {
          text: '最近两个月',
          onClick(picker) {
            const end = new Date()
            const start = new Date()
            start.setTime(start.getTime() - 3600 * 1000 * 24 * 60)
            picker.$emit('pick', [start, end])
          }
        }]
      },
      loadBtnFunc: [],
      tableData: [],
      tableloading: true,
      pagination: {
        currentPage: 1,
        pagesize: 20,
        pageTotal: 0
      },
      sortableData: {
        order: '',
        sort: ''
      },
      dialogEditFormVisible: false,
      editFormTitle: '',
      editFrom: {
        Account: '',
        RealName: '',
        NickName: '',
        Gender: '1',
        Birthday: '',
        MobilePhone: '',
        Email: '',
        WeChat: '',
        OrganizeId: '',
        RoleId: '',
        IsAdministrator: true,
        EnabledMark: true,
        Description: ''
      },
      rules: {
        Account: [
          { required: true, message: '请输入账号', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 16 个字符', trigger: 'blur' }
        ],
        RealName: [
          { required: true, message: '请输入姓名', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        OrganizeId: [
          { required: true, message: '请输选择所属组织', trigger: 'blur' }
        ],
        RoleId: [
          { required: true, message: '请输选择岗位角色', trigger: 'blur' }
        ]
      },
      formLabelWidth: '80px',
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: []
    }
  },
  created() {
    this.pagination.currentPage = 1
    this.InitDictItem()
    this.loadTableData()
    this.loadBtnFunc = JSON.parse(localStorage.getItem('yueboncurrentfuns'))
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem() {
      getAllRoleList().then(res => {
        this.selectRole = res.ResData
      })
      getAllOrganizeTreeTable().then(res => {
        this.selectOrganize = res.ResData
      })
    },
    /**
     * 加载页面table数据
     */
    loadTableData: function() {
      this.tableloading = true
      var seachdata = {
        'CurrentPage': this.pagination.currentPage,
        'length': this.pagination.pagesize,
        'Keywords': this.searchform.Keywords,
        'CreatorTime1': this.searchform.CreateTime[0],
        'CreatorTime2': this.searchform.CreateTime[1],
        'RoleId': this.searchform.RoleId,
        'Order': this.sortableData.order,
        'Sort': this.sortableData.sort
      }
      getUserListWithPager(seachdata).then(res => {
        this.tableData = res.ResData.Items
        this.pagination.pageTotal = res.ResData.TotalItems
        this.tableloading = false
      })
    },
    /**
     * 点击查询
     */
    handleSearch: function() {
      this.pagination.currentPage = 1
      this.loadTableData()
    },
    /**
     * 新增、修改或查看明细信息（绑定显示数据）     *
     */
    ShowEditOrViewDialog: function(view) {
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
        this.selectedOrganizeOptions = ''
        this.dialogEditFormVisible = true
        this.$refs['editFrom'].resetFields()
      }
    },
    bindEditInfo: function() {
      getUserDetail(this.currentId).then(res => {
        this.editFrom.Account = res.ResData.Account
        this.editFrom.RealName = res.ResData.RealName
        this.editFrom.NickName = res.ResData.NickName
        this.editFrom.Gender = res.ResData.Gender + ''
        this.editFrom.Birthday = res.ResData.Birthday
        this.editFrom.MobilePhone = res.ResData.MobilePhone
        this.editFrom.Email = res.ResData.Email
        this.editFrom.WeChat = res.ResData.WeChat
        this.editFrom.OrganizeId = res.ResData.OrganizeId
        this.editFrom.IsAdministrator = res.ResData.IsAdministrator
        this.editFrom.EnabledMark = res.ResData.EnabledMark
        this.editFrom.RoleId = res.ResData.RoleId.split(',')
        this.editFrom.Description = res.ResData.Description
        this.selectedOrganizeOptions = res.ResData.OrganizeId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm() {
      console.log(this.editFrom.RoleId)
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            Account: this.editFrom.Account,
            RealName: this.editFrom.RealName,
            NickName: this.editFrom.NickName,
            Gender: this.editFrom.Gender,
            Birthday: this.editFrom.Birthday,
            MobilePhone: this.editFrom.MobilePhone,
            Email: this.editFrom.Email,
            WeChat: this.editFrom.WeChat,
            OrganizeId: this.editFrom.OrganizeId,
            IsAdministrator: this.editFrom.IsAdministrator,
            EnabledMark: this.editFrom.EnabledMark,
            RoleId: this.editFrom.RoleId.join(','),
            Description: this.editFrom.Description,
            'Id': this.currentId
          }

          var url = 'User/Insert'
          if (this.currentId !== '') {
            url = 'User/Update?id=' + this.currentId
          }
          saveUser(data, url).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogEditFormVisible = false
              this.currentSelected = ''
              this.selectedOrganizeOptions = ''
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
    setEnable: function(val) {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = ''
        this.currentSelected.forEach(element => {
          currentIds += element.Id + ','
        })
        const data = {
          ids: currentIds,
          bltag: val
        }
        setUserEnable(data).then(res => {
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
    deleteSoft: function(val) {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = ''
        this.currentSelected.forEach(element => {
          currentIds += element.Id + ','
        })
        const data = {
          ids: currentIds,
          bltag: val
        }
        deleteSoftUser(data).then(res => {
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
    deletePhysics: function() {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = ''
        this.currentSelected.forEach(element => {
          currentIds += element.Id + ','
        })
        const data = {
          ids: currentIds
        }
        deleteUser(data).then(res => {
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
    handleSortChange: function(column) {
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
    handleSelectChange: function(selection, row) {
      this.currentSelected = selection
    },
    /**
     * 当用户手动勾选全选checkbox事件
     */
    handleSelectAllChange: function(selection) {
      this.currentSelected = selection
    },
    /**
     * 选择每页显示数量
     */
    handleSizeChange(val) {
      this.pagination.pagesize = val
      this.pagination.currentPage = 1
      this.loadTableData()
    },
    /**
     * 选择当页面
     */
    handleCurrentChange(val) {
      this.pagination.currentPage = val
      this.loadTableData()
    },

    /**
     *选择组织
     */
    handleSelectOrganizeChange: function() {
      this.editFrom.OrganizeId = this.selectedOrganizeOptions
    },
    dateformatter(row, column, cellValue, index) {
      var date = row[column.property]
      return cellValue ? fecha.format(new Date(date), 'yyyy-MM-dd') : ''
    },
    handleResetPassword: function(val) {
      if (this.currentSelected.length > 1 || this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        const data = {
          userId: this.currentSelected[0].Id
        }
        resetPassword(data).then(res => {
          if (res.Success) {
            this.$alert('重置密码成功，新密为' + res.ErrMsg, '提醒', {
              confirmButtonText: '确定',
              callback: action => {
              }
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
    }
  }
}
</script>
