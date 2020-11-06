<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form ref="searchform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
          <el-form-item label="名称：">
            <el-input v-model="searchform.name" clearable placeholder="名称" />
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
            <el-button v-if="itemf.FullName === '修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="small" @click="ShowEditOrViewDialog('edit')">
              修改</el-button>
            <el-button v-if="itemf.FullName == '禁用'" type="info" icon="el-icon-video-pause" size="small" @click="setEnable('0')">禁用</el-button>
            <el-button v-if="itemf.FullName == '启用'" type="success" icon="el-icon-video-play" size="small" @click="setEnable('1')">启用</el-button>
            <el-button v-if="itemf.FullName === '软删除'" type="warning" icon="el-icon-delete" size="small" @click="deleteSoft('0')">软删除</el-button>
            <el-button v-if="itemf.FullName === '删除'" type="danger" icon="el-icon-delete" size="small" @click="deletePhysics()">删除</el-button>
          </slot>
          <el-button type="default" icon="el-icon-refresh" size="small" @click="loadTableData()">刷新</el-button>
        </el-button-group>
      </div>
      <el-table ref="gridtable" v-loading="tableloading" :data="tableData" border stripe highlight-current-row style="width: 100%" :default-sort="{ prop: 'CreatorTime', order: 'ascending' }" @select="handleSelectChange" @select-all="handleSelectAllChange">
        <el-table-column type="selection" width="30" />
        <el-table-column prop="TenantName" label="租户名称" sortable="custom" width="120" />
        <el-table-column prop="CompanyName" label="公司名称" sortable="custom" width="180" />
        <el-table-column prop="HostDomain" label="访问域名" sortable="custom" width="180" />
        <el-table-column prop="LinkMan" label="联系人" sortable="custom" width="120" />
        <el-table-column prop="Telphone" label="联系电话" sortable="custom" width="120" />
        <el-table-column prop="Description" label="租户介绍" sortable="custom" width="220" />
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
      </el-table>
      <div class="pagination-container">
        <el-pagination background :current-page="pagination.currentPage" :page-sizes="[5, 10, 20, 50, 100, 200, 300, 400]" :page-size="pagination.pagesize" layout="total, sizes, prev, pager, next, jumper" :total="pagination.pageTotal" @size-change="handleSizeChange" @current-change="handleCurrentChange" />
      </div>
    </el-card>
    <el-dialog ref="dialogEditForm" :title="editFormTitle + '租户'" :visible.sync="dialogEditFormVisible" width="640px">
      <el-form ref="editFrom" :model="editFrom" :rules="rules">
        <el-form-item label="租户名称" :label-width="formLabelWidth" prop="TenantName">
          <el-input v-model="editFrom.TenantName" placeholder="请输入租户名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="公司名称" :label-width="formLabelWidth" prop="CompanyName">
          <el-input v-model="editFrom.CompanyName" placeholder="请输入公司名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="访问域名" :label-width="formLabelWidth" prop="HostDomain">
          <el-input v-model="editFrom.HostDomain" placeholder="请输入访问域名" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="联系人" :label-width="formLabelWidth" prop="LinkMan">
          <el-input v-model="editFrom.LinkMan" placeholder="请输入联系人" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="联系电话" :label-width="formLabelWidth" prop="Telphone">
          <el-input v-model="editFrom.Telphone" placeholder="请输入联系电话" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="数据源" :label-width="formLabelWidth" prop="DataSource">
          <el-input v-model="editFrom.DataSource" placeholder="请输入数据源，分库使用" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="是否可用" :label-width="formLabelWidth" prop="EnabledMark">
          <el-radio-group v-model="editFrom.EnabledMark">
            <el-radio label="true">是</el-radio>
            <el-radio label="false">否</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item label="租户介绍" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" placeholder="请输入租户介绍" autocomplete="off" clearable />
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
import {
  getTenantListWithPager,
  getTenantDetail,
  saveTenant,
  setTenantEnable,
  deleteSoftTenant,
  deleteTenant
} from '@/api/security/tenant'

export default {
  data () {
    return {
      searchform: {
        name: ''
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
        order: 'desc',
        sort: 'CreatorTime'
      },
      dialogEditFormVisible: false,
      editFormTitle: '',
      editFrom: {
        TenantName: '',
        CompanyName: '',
        HostDomain: '',
        LinkMan: '',
        Telphone: '',
        DataSource: '',
        Description: '',
        EnabledMark: 'true'
      },
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
      },
      formLabelWidth: '80px',
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: []
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
    InitDictItem () { },
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
      getTenantListWithPager(seachdata).then((res) => {
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

    /**
     * 新增、修改或查看明细信息（绑定显示数据）     *
     */
    ShowEditOrViewDialog: function (view) {
      if (view !== undefined) {
        if (
          this.currentSelected.length > 1 ||
          this.currentSelected.length === 0
        ) {
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
      getTenantDetail(this.currentId).then((res) => {
        this.editFrom.TenantName = res.ResData.TenantName
        this.editFrom.CompanyName = res.ResData.CompanyName
        this.editFrom.HostDomain = res.ResData.HostDomain
        this.editFrom.LinkMan = res.ResData.LinkMan
        this.editFrom.Telphone = res.ResData.Telphone
        this.editFrom.DataSource = res.ResData.DataSource
        this.editFrom.Description = res.ResData.Description
        this.editFrom.EnabledMark = res.ResData.EnabledMark + ''
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm () {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            TenantName: this.editFrom.TenantName,
            CompanyName: this.editFrom.CompanyName,
            HostDomain: this.editFrom.HostDomain,
            LinkMan: this.editFrom.LinkMan,
            Telphone: this.editFrom.Telphone,
            DataSource: this.editFrom.DataSource,
            Description: this.editFrom.Description,
            EnabledMark: this.editFrom.EnabledMark
          }

          var url = 'Tenant/Insert'
          if (this.currentId !== '') {
            url = 'Tenant/Update?id=' + this.currentId
          }
          saveTenant(data, url).then((res) => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogEditFormVisible = false
              this.currentSelected = ''
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
        setTenantEnable(data).then((res) => {
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
        deleteSoftTenant(data).then((res) => {
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
        deleteTenant(data).then((res) => {
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
