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
          <el-form-item label="应用名称：">
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
        <el-table-column prop="AppId" label="应用Id" sortable="custom" width="130" fixed />
        <el-table-column
          prop="AppSecret"
          label="AppSecret"
          sortable="custom"
          width="300"
          fixed
        />
        <el-table-column
          prop="Token"
          label="Token"
          sortable="custom"
          width="150"
        />
        <el-table-column
          label="消息加密"
          sortable="custom"
          width="120"
          prop="IsOpenAEKey"
          align="center"
        >
          <template slot-scope="scope">
            <el-tag
              :type="scope.row.IsOpenAEKey === true ? 'success' : 'info'"
              disable-transitions
            >{{ scope.row.IsOpenAEKey===true?'启用':'禁用' }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column prop="RequestUrl" label="授权URL" sortable="custom" width="520" />
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
      :title="editFormTitle+'应用'"
      :visible.sync="dialogEditFormVisible"
      width="640px"
    >
      <el-form ref="editFrom" :model="editFrom" :rules="rules">
        <el-form-item label="应用Id" :label-width="formLabelWidth" prop="AppId">
          <el-input v-model="editFrom.AppId" placeholder="请输入应用Id" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="应用Secret" :label-width="formLabelWidth" prop="AppSecret">
          <el-input v-model="editFrom.AppSecret" placeholder="系统自动生成" readonly autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="消息加密密钥" :label-width="formLabelWidth" prop="EncodingAESKey">
          <el-input v-model="editFrom.EncodingAESKey" placeholder="系统自动生成" readonly autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="Token" :label-width="formLabelWidth" prop="Token">
          <el-input v-model="editFrom.Token" placeholder="请输入Token" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="选项" :label-width="formLabelWidth" prop="">
          <el-checkbox v-model="editFrom.EnabledMark">启用</el-checkbox>
          <el-checkbox v-model="editFrom.IsOpenAEKey">启用消息加密</el-checkbox>
        </el-form-item>
        <el-form-item label="授权Url" :label-width="formLabelWidth" prop="RequestUrl">
          <el-input v-model="editFrom.RequestUrl" type="textarea" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="描述" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" type="textarea" autocomplete="off" clearable />
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
        this.$refs['editFrom'].resetFields()
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
