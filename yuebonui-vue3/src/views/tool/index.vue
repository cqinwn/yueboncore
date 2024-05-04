<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form ref="searchDbformRef" :inline="true" :model="searchform" class="demo-form-inline">
          <el-form-item label="连接字符串" prop="DbAddress" width="300">
            <el-input v-model="searchDbform.DbAddress"  placeholder="请输入数据库连接字符串" autocomplete="off" clearable />
          </el-form-item>
          <el-form-item label="数据库类型" prop="DbType">
            <el-select v-model="searchDbform.DbType" clearable placeholder="请选数据库类型">
              <el-option
                v-for="item in selectDbTypes"
                :key="item.Id"
                :label="item.Title"
                :value="item.Id"
              />
            </el-select>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" @click="handleDbConn()"><svg-icon icon-class="link1"></svg-icon>链接</el-button>
          </el-form-item>
        </el-form>
      </el-card>
    </div>
    <el-card>
      <div class="list-btn-container">
        <el-form ref="codeformRef" :inline="true" :rules="rules" :model="codeform" class="demo-form-inline">
          <el-button type="default" icon="refresh" size="small" @click="loadTableData()">刷新</el-button>
          <el-form-item label="数据库">
            <el-tooltip class="item" effect="dark" content="默认为系统访问数据库" placement="top">
              <el-select v-model="searchform.DbName" clearable placeholder="请选择" @change="handleShowTable">
                <el-option
                  v-for="item in selectedDataBase"
                  :key="item"
                  :label="item"
                  :value="item"
                />
              </el-select>
            </el-tooltip>
          </el-form-item>
          <el-form-item label="数据库表名">
            <el-input v-model="searchform.tableName" clearable placeholder="输入要查询的表名" />
          </el-form-item>
          <el-form-item>
            <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
          </el-form-item>
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
            <el-button type="primary"  @click="handleGenerate()"><svg-icon icon-class="code"></svg-icon>生成代码</el-button>
          </el-form-item>
        </el-form>
      </div>
      <el-table
        ref="gridtable"
        v-loading="tableloading"
        :data="tableData"
        stripe
        highlight-current-row
        style="width: 100%"
        :default-sort="{prop: 'Name', order: 'ascending'}"
        @select="handleSelectChange"
        @select-all="handleSelectAllChange"
        @sort-change="handleSortChange"
      >
        <el-table-column
          type="selection"
          width="50"
        />
        <el-table-column
          prop="Name"
          label="表名"
          sortable="custom"
          width="380"
        />
        <el-table-column
          prop="Description"
          label="表描述"
        />
      </el-table>
    <Pagination
      v-show="pagination.pageTotal>0"
      :total="pagination.pageTotal"
      :page="pagination.currentPage"
      :limit="pagination.pageSize"
      @pagination="loadTableData"
    />
    </el-card>
  </div>
</template>

<script setup name="CodeGenerator">
import { createGetDBConn, codeGetDBList, codeGetTableList, codeGenerator } from '@/api/developers/toolsservice'
import { downloadFile } from '@/utils/index'
import { ElLoading } from 'element-plus'
import defaultSettings from '@/settings'

const { proxy } = getCurrentInstance()

const formLabelWidth=ref("120px")
const tableloading=ref(true)
const tableData=ref([])
const currentSelected=ref([])
const selectedDataBase=ref([])

const data = reactive({
  searchDbform: {
    DbName: '',
    DbAddress: '',
    DbPort: '1433',
    DbUserName: '',
    DbPassword: '',
    DbType: ''
  },
  searchform: {
    DbName: '',
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
  selectDbTypes: [{
    Id: 1,
    Title: 'SqlServer'
  }, {
    Id: 0,
    Title: 'MySql'
  }],
  pagination: {
    currentPage: 1,
    pageSize: 20,
    pageTotal: 0
  },
  sortableData: {
    order: '',
    sort: ''
  }
})

const { searchDbform,searchform,codeform, rules, selectDbTypes,pagination,sortableData} = toRefs(data);

/**
 * 获取数据库
 */
function loadDbsData() {
  codeGetDBList().then(res => {
    selectedDataBase.value = res.ResData
  })
}
/**
 * 加载页面table数据
 */
function loadTableData() {
  if (searchform.value.dataBaseName !== '') {
    tableloading.value = true
    var seachdata = {
      'CurrenetPageIndex': pagination.value.currentPage,
      'PageSize': pagination.value.pageSize,
      'Keywords': searchform.value.tableName,
      'EnCode': searchform.value.DbName,
      'Order': sortableData.value.order,
      'Sort': sortableData.value.sort
    }
    codeGetTableList(seachdata).then(res => {
      tableData.value = res.ResData.Items
      pagination.value.pageTotal = res.ResData.TotalItems
      tableloading.value = false
    })
  }
}
/**
 * 点击查询
 */
function handleSearch() {
  pagination.value.currentPage = 1
  loadTableData()
}
function handleShowTable() {
  pagination.value.currentPage = 1
  loadTableData()
}
function handleDbConn() {
  var dataInfo = {
    DbAddress: searchDbform.value.DbAddress,
    DbPort: "",
    DbName: "",
    DbUserName: "",
    DbPassword: "",
    DbType: searchDbform.value.DbType
  }
  createGetDBConn(dataInfo).then(res => {
    selectedDataBase.value = res.ResData
    searchform.value.DbName = searchDbform.DbName
    pagination.value.currentPage = 1
  // loadData()
  // loadTableData()
  })
}
/**
 * 点击生成服务端代码
 */
async function handleGenerate() {
  if (currentSelected.value.length === 0) {
    proxy.$modal.alert('请先选择要生成代码的数据表')
    return false
  } else {
    proxy.$refs['codeformRef'].validate((valid) => {
      if (valid) {
        let loadop = {
          lock: true,
          text: '正在生成代码...',
          spinner: 'loading',
          background: 'rgba(0, 0, 0, 0.7)'
        }
        const pageLoading = ElLoading.service(loadop)
        var currentTables = ''
        currentSelected.value.forEach(element => {
          currentTables += element.Name + ','
        })
        var seachdata = {
          'tables': currentTables,
          'baseSpace': codeform.value.baseSpace,
          'replaceTableNameStr': codeform.value.replaceTableNameStr
        }
        codeGenerator(seachdata).then(res => {
          if (res.Success) {
            downloadFile(defaultSettings.fileUrl + res.ResData[0], res.ResData[1])
            proxy.$modal.msgSuccess('恭喜你，代码生成完成！')
          } else {
            proxy.$modal.msgError(res.ErrMsg)
          }
          pageLoading.close()
        }).catch(erre => {
          pageLoading.close()
        })
      } else {
        return false
      }
    })
  }
}
/**
 * 当表格的排序条件发生变化的时候会触发该事件
 */
function handleSortChange(column) {
  sortableData.value.sort = column.prop
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
function handleSelectChange(selection, row) {
  currentSelected.value = selection
}
/**
 * 当用户手动勾选全选checkbox事件
 */
function handleSelectAllChange(selection) {
  currentSelected.value = selection
}
/**
 * 选择每页显示数量
 */
function handleSizeChange(val) {
  pagination.value.pagesize = val
  pagination.value.currentPage = 1
  loadTableData()
}
/**
 * 选择当页面
 */
function handleCurrentChange(val) {
  pagination.value.currentPage = val
  loadTableData()
}

loadDbsData()
//loadTableData()
</script>
