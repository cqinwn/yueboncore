<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form ref="searchform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
          <el-form-item label="数据库表名">
            <el-input v-model="searchform.tableName" clearable placeholder="输入要查询的表名" />
          </el-form-item>
          <el-form-item>
            <el-button type="primary" @click="handleSearch()">查询</el-button>
          </el-form-item>
        </el-form>
      </el-card>
    </div>
    <el-card>
      <div class="list-btn-container">

        <el-form ref="codeform" :inline="true" :rules="rules" :model="codeform" class="demo-form-inline" size="small">
          <el-button type="default" icon="el-icon-refresh" size="small" @click="loadTableData()">刷新</el-button>
          <el-form-item label="项目命名空间：" prop="baseSpace">
            <el-tooltip class="item" effect="dark" content="系统会根据项目命名空间自动生成IService、Service、Models等子命名空间" placement="top">
              <el-input v-model="codeform.baseSpace" clearable placeholder="如Yuebon.WMS" />
            </el-tooltip>
          </el-form-item>
          <el-form-item label="去掉表名前缀：">
            <el-tooltip class="item" effect="dark" content="表名直接变为类名，去掉表名前缀。多个前缀用“;”隔开和结束" placement="top">
              <el-input v-model="codeform.replaceTableNameStr" clearable width="300" placeholder="多个前缀用“;”隔开" />
            </el-tooltip>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" icon="iconfont icon-code" @click="handleGenerate()">生成代码</el-button>
          </el-form-item>
        </el-form>
      </div>
      <el-table
        ref="gridtable"
        v-loading="tableloading"
        :data="tableData"
        border
        stripe
        highlight-current-row
        style="width: 100%"
        :default-sort="{prop: 'TableName', order: 'ascending'}"
        @select="handleSelectChange"
        @select-all="handleSelectAllChange"
        @sort-change="handleSortChange"
      >
        <el-table-column
          type="selection"
          width="30"
        />
        <el-table-column
          prop="TableName"
          label="表名"
          sortable="custom"
          width="380"
        />
        <el-table-column
          prop="Description"
          label="表描述"
          sortable
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
  </div>
</template>

<script>
import { codeGetTableList, codeGenerator } from '@/api/developers/toolsservice'
export default {
  data() {
    return {
      searchform: {
        tableName: ''
      },
      codeform: {
        baseSpace: '',
        replaceTableNameStr: ''
      },
      rules: {
        baseSpace: [
          { required: true, message: '请输入项目名称', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        replaceTableNameStr: [
          { min: 0, max: 50, message: '长度小于50个字符', trigger: 'blur' }
        ]
      },
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
      currentSelected: []
    }
  },
  created() {
    this.pagination.currentPage = 1
    this.loadTableData()
  },
  methods: {
    /**
     * 加载页面table数据
     */
    loadTableData: function () {
      this.tableloading = true
      var seachdata = {
        'CurrentPage': this.pagination.currentPage,
        'length': this.pagination.pagesize,
        'Keywords': this.searchform.tableName,
        'Order': this.sortableData.order,
        'Sort': this.sortableData.sort
      }
      codeGetTableList(seachdata).then(res => {
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
     * 点击生成服务端代码
     */
    handleGenerate: function () {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要生成代码的数据表', '提示')
        return false
      } else {
        this.$refs['codeform'].validate((valid) => {
          if (valid) {
            var currentTables = ''
            this.currentSelected.forEach(element => {
              currentTables += element.TableName + ','
            })
            var seachdata = {
              'tables': currentTables,
              'baseSpace': this.codeform.baseSpace,
              'replaceTableNameStr': this.codeform.replaceTableNameStr
            }
            codeGenerator(seachdata).then(res => {
              if (res.Success) {
                this.$message({
                  message: '恭喜你，操作成功',
                  type: 'success'
                })
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
