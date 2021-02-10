<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form
          ref="searchform"
          :inline="true"
          :model="searchform"
          class="demo-form-inline"
          size="small"
        >
          <el-form-item label="软件名称：">
            <el-input v-model="searchform.name" clearable placeholder="应用AppId或授权Url" />
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
            <el-button
              v-if="itemf.FullName==='新增'"
              type="primary"
              icon="el-icon-plus"
              size="small"
              @click="ShowEditOrViewDialog()"
            >新增</el-button>
            <el-button
              v-if="itemf.FullName==='修改'"
              type="primary"
              icon="el-icon-edit"
              class="el-button-modify"
              size="small"
              @click="ShowEditOrViewDialog('edit')"
            >修改</el-button>
            <el-button
              v-if="itemf.FullName=='禁用'"
              type="info"
              icon="el-icon-video-pause"
              size="small"
              @click="setEnable('0')"
            >禁用</el-button>
            <el-button
              v-if="itemf.FullName=='启用'"
              type="success"
              icon="el-icon-video-play"
              size="small"
              @click="setEnable('1')"
            >启用</el-button>
            <el-button
              v-if="itemf.FullName==='软删除'"
              type="warning"
              icon="el-icon-delete"
              size="small"
              @click="deleteSoft('0')"
            >软删除</el-button>
            <el-button
              v-if="itemf.FullName==='删除'"
              type="danger"
              icon="el-icon-delete"
              size="small"
              @click="deletePhysics()"
            >删除</el-button>

            <el-button
              v-if="itemf.EnCode==='APP/ResetAppSecret'"
              type="primary"
              icon="el-icon-refresh-right"
              size="small"
              @click="haddlerResetAppSecret()"
            >重置AppSecret</el-button>

            <el-button
              v-if="itemf.EnCode==='APP/ResetEncodingAESKey'"
              type="primary"
              icon="el-icon-refresh-right"
              size="small"
              @click="haddlerResetEncodingAESKey()"
            >重置消息密钥</el-button>
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
        :default-sort="{prop: 'SortCode', order: 'ascending'}"
        @select="handleSelectChange"
        @select-all="handleSelectAllChange"
        @sort-change="handleSortChange"
      >
        <el-table-column type="selection" width="30" />
        <el-table-column prop="CompanyName" label="公司名称" sortable="custom" width="300" fixed />
        <el-table-column
          prop="LinkMan"
          label="联系人"
          sortable="custom"
          width="100"
          fixed
        />
        <el-table-column
          prop="TelPhone"
          label="联系电话"
          sortable="custom"
          width="150"
        />
        <el-table-column
          prop="SoftName"
          label="软件名称"
          sortable="custom"
          width="150"
        />
        <el-table-column
          prop="Version"
          label="版本"
          sortable="custom"
          width="150"
        />
        <el-table-column
          label="有效性"
          sortable="custom"
          width="120"
          prop="AuthorizeStatus"
          align="center"
        >
          <template slot-scope="scope">
            <el-tag
              :type="scope.row.IsOpenAEKey === true ? 'success' : 'info'"
              disable-transitions
            >{{ scope.row.IsOpenAEKey===true?'启用':'禁用' }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column
          label="启用"
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
    <el-dialog
      ref="dialogEditForm"
      :title="editFormTitle+'授权'"
      :visible.sync="dialogEditFormVisible"
      width="660px"
    >
      <el-form ref="editFrom" :inline="true" :model="editFrom" :rules="rules" class="demo-form-inline">
        <el-form-item label="公司名称" :label-width="formLabelWidth" prop="CompanyName">
          <el-input v-model="editFrom.CompanyName" style="width:500px" placeholder="请输入公司名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="联系人" :label-width="formLabelWidth" prop="LinkMan">
          <el-input v-model="editFrom.LinkMan" placeholder="请输入联系人" readonly autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="联系电话" :label-width="formLabelWidth" prop="TelPhone">
          <el-input v-model="editFrom.TelPhone" placeholder="请输入联系电话" readonly autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="软件名称" :label-width="formLabelWidth" prop="SoftName">
          <el-input v-model="editFrom.SoftName" placeholder="请输入软件名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="版本号" :label-width="formLabelWidth" prop="Version">
          <el-input v-model="editFrom.Version" placeholder="请输入版本号" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="有效期" :label-width="formLabelWidth" prop="StartDate">
          <el-date-picker
            v-model="searchform.StartDate"
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
        <el-form-item label="特征码" :label-width="formLabelWidth" prop="MachineCode">
          <el-input v-model="editFrom.MachineCode" style="width:500px" placeholder="请输入特征码或机器码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="公钥" :label-width="formLabelWidth" prop="PublicKey">
          <el-input v-model="editFrom.PublicKey" style="width:500px" type="textarea" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="私钥" :label-width="formLabelWidth" prop="PrivateKey">
          <el-input v-model="editFrom.PrivateKey" style="width:500px" type="textarea" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="注册码" :label-width="formLabelWidth" prop="RegistryCode">
          <el-input v-model="editFrom.RegistryCode" type="textarea" style="width:500px" placeholder="请输入生成注册码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="描述" :label-width="formLabelWidth" prop="Remark">
          <el-input v-model="editFrom.Remark" type="textarea" style="width:500px" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="状态" :label-width="formLabelWidth" prop="">
          <el-checkbox v-model="editFrom.AuthorizeStatus">有效</el-checkbox>
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
import { getAPPListWithPager, getAPPDetail, saveAPP, setAPPEnable,
  deleteSoftAPP, deleteAPP, resetAppSecret, resetEncodingAESKey } from '@/api/developers/appservice'

export default {
  data() {
    return {
      searchform: {
        name: ''
      },
      loadBtnFunc: [],
      selectedOrganizeOptions: '',
      selectOrganize: [],
      selectAPPType: [],
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
        AppId: '',
        AppSecret: '',
        EncodingAESKey: '',
        RequestUrl: '',
        Token: '',
        IsOpenAEKey: false,
        EnabledMark: true,
        Description: ''
      },
      rules: {
        AppId: [
          { required: true, message: '请输入应用AppId', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
        ],
        Token: [
          { required: true, message: '请输入Token', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 6 到 32 个字符', trigger: 'blur' }
        ]
      },
      formLabelWidth: '100px',
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
        'Order': this.sortableData.order,
        'Sort': this.sortableData.sort
      }
      getAPPListWithPager(seachdata).then(res => {
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
      }
    },
    bindEditInfo: function() {
      getAPPDetail(this.currentId).then(res => {
        this.editFrom.AppId = res.ResData.AppId
        this.editFrom.AppSecret = res.ResData.AppSecret
        this.editFrom.EncodingAESKey = res.ResData.EncodingAESKey
        this.editFrom.RequestUrl = res.ResData.RequestUrl
        this.editFrom.Token = res.ResData.Token
        this.editFrom.IsOpenAEKey = res.ResData.IsOpenAEKey
        this.editFrom.EnabledMark = res.ResData.EnabledMark
        this.editFrom.Description = res.ResData.Description
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm() {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'AppId': this.editFrom.AppId,
            'AppSecret': this.editFrom.AppSecret,
            'EncodingAESKey': this.editFrom.EncodingAESKey,
            'RequestUrl': this.editFrom.RequestUrl,
            'Token': this.editFrom.Token,
            'IsOpenAEKey': this.editFrom.IsOpenAEKey,
            'EnabledMark': this.editFrom.EnabledMark,
            'Description': this.editFrom.Description,
            'Id': this.currentId
          }
          var url = 'APP/Insert'
          if (this.currentId !== '') {
            url = 'APP/Update?id=' + this.currentId
          }
          saveAPP(data, url).then(res => {
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
        setAPPEnable(data).then(res => {
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
        deleteSoftAPP(data).then(res => {
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
        deleteAPP(data).then(res => {
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
    haddlerResetAppSecret: function() {
      if (this.currentSelected.length === 0 || this.currentSelected.length > 1) {
        this.$alert('请选择一条数据进行重置', '提示')
        return false
      } else {
        const data = {
          id: this.currentSelected[0].Id
        }
        resetAppSecret(data).then(res => {
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
    haddlerResetEncodingAESKey: function() {
      if (this.currentSelected.length === 0 || this.currentSelected.length > 1) {
        this.$alert('请选择一条数据进行重置', '提示')
        return false
      } else {
        const data = {
          id: this.currentSelected[0].Id
        }
        resetEncodingAESKey(data).then(res => {
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
    }
  }
}
</script>
