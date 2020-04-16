<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form ref="searchform" :inline="true" :model="searchform" class="demo-form-inline" size="small">

          <el-form-item label="客户名称：">
            <el-input v-model="searchform.name" clearable placeholder="客户名称" />
          </el-form-item>
          <el-form-item label="客户编码：">
            <el-input v-model="searchform.code" clearable placeholder="客户代码" />
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
          prop="EnCode"
          label="客户编码"
          sortable="custom"
          width="180"
        />
        <el-table-column
          prop="Title"
          label="客户名称"
          sortable="custom"
          width="180"
        />
        <el-table-column
          prop="Contact"
          label="联系人"
          sortable="custom"
          width="120"
        />
        <el-table-column
          prop="Telphone"
          label="联系电话"
          sortable="custom"
          width="130"
        />
        <el-table-column
          prop="Mobile"
          label="手机号"
          sortable="custom"
          width="130"
        />
        <el-table-column
          prop="Address"
          label="联系地址"
          sortable="custom"
          width="180"
        />
        <el-table-column
          label="是否启用"
          sortable="custom"
          width="120"
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
          label="是否删除"
          sortable="custom"
          width="120"
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
          prop="LastModifyTime"
          label="更新时间"
          sortable
        >
          <template slot-scope="scope">
            {{ scope.row.LastModifyTime !== null?scope.row.LastModifyTime:scope.row.CreatorTime }}
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
    <el-dialog ref="dialogEditForm" :title="editFormTitle+'客户'" :visible.sync="dialogEditFormVisible" width="30%">
      <el-form ref="editFrom" :model="editFrom" :rules="rules">

        <el-form-item label="客户编码" :label-width="formLabelWidth" prop="EnCode">
          <el-input v-model="editFrom.EnCode" placeholder="请输入客户编码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="客户名称" :label-width="formLabelWidth" prop="Title">
          <el-input v-model="editFrom.Title" placeholder="请输入客户名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="联系人" :label-width="formLabelWidth" prop="Contact">
          <el-input v-model="editFrom.Contact" placeholder="请输入联系人" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="联系电话" :label-width="formLabelWidth" prop="Telphone">
          <el-input v-model="editFrom.Telphone" placeholder="请输入联系电话" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="联系手机" :label-width="formLabelWidth" prop="Mobile">
          <el-input v-model="editFrom.Mobile" placeholder="请输入联系手机" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="联系地址" :label-width="formLabelWidth" prop="Address">
          <el-input v-model="editFrom.Address" placeholder="请输入联系地址" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="是否启用" :label-width="formLabelWidth" prop="enable">
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
  </div>
</template>

<script>

import { getListItemDetailsByCode } from '@/api/basebasic'
import { getCustomerListWithPager, getCustomerDetail, saveCustomer, setCustomerEnable, deleteSoftCustomer, deleteCustomer } from '@/api/wms/customer'

export default {
  data() {
    return {
      searchform: {
        name: '',
        code: ''
      },
      loadBtnFunc: [],
      selectStoreTemperatureLayer: [],
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
        EnCode: '',
        Title: '',
        Contact: '',
        Telphone: '',
        Mobile: '',
        Address: '',
        EnabledMark: 'true'
      },
      rules: {
        Title: [
          { required: true, message: '请输入客户名称', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        EnCode: [
          { required: true, message: '请输入客户编码', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
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
      getListItemDetailsByCode('StoreTemperatureLayer').then(res => {
        this.selectStoreTemperatureLayer = res.ResData
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
        'Keywords': this.searchform.name,
        'EnCode': this.searchform.code,
        'Order': this.sortableData.order,
        'Sort': this.sortableData.sort
      }
      getCustomerListWithPager(seachdata).then(res => {
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
        this.dialogEditFormVisible = true
        this.$refs['editFrom'].resetFields()
      }
    },
    bindEditInfo: function() {
      getCustomerDetail(this.currentId).then(res => {
        this.editFrom.Title = res.ResData.Title
        this.editFrom.EnCode = res.ResData.EnCode
        this.editFrom.Contact = res.ResData.Contact
        this.editFrom.Telphone = res.ResData.Telphone
        this.editFrom.Mobile = res.ResData.Mobile
        this.editFrom.Address = res.ResData.Address
        this.editFrom.EnabledMark = res.ResData.EnabledMark + ''
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm() {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'Title': this.editFrom.Title,
            'EnCode': this.editFrom.EnCode,
            'Contact': this.editFrom.Contact,
            'Telphone': this.editFrom.Telphone,
            'Mobile': this.editFrom.Mobile,
            'Address': this.editFrom.Address,
            'EnabledMark': this.editFrom.EnabledMark,
            'Id': this.currentId
          }
          saveCustomer(data).then(res => {
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
        setCustomerEnable(data).then(res => {
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
        deleteSoftCustomer(data).then(res => {
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
        deleteCustomer(data).then(res => {
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
    }
  }
}
</script>
