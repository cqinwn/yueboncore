<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="searchform" class="demo-form-inline">
      <el-form-item label="账号：" prop="name">
        <el-input v-model="searchform.name" clearable placeholder="账号" />
      </el-form-item>
      <el-form-item label="IP地址：" prop="IpAddres">
        <el-input v-model="searchform.IpAddres" clearable placeholder="IP地址" />
      </el-form-item>
      <el-form-item label="日志日期：" prop="CreateTime">
        <el-date-picker
          v-model="searchform.CreateTime"
          type="datetimerange"
          align="right"
          :default-time="['00:00:00', '23:59:59']"
          format="YYYY-MM-DD HH:mm:ss"
          value-format="YYYY-MM-DD HH:mm:ss"
          unlink-panels
          range-separator="至"
          start-placeholder="开始日期"
          end-placeholder="结束日期"
          :shortcuts="shortcuts"
        />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['Log/Delete']" type="danger" icon="delete" :disabled="multiple" @click="deletePhysics()">删除</el-button>
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
      :default-sort="{ prop: 'CreatorTime', order: 'descending' }"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
    >
      <el-table-column type="selection" width="40" />
      <el-table-column prop="CreatorTime" label="操作时间" sortable="custom" width="180" />
      <el-table-column prop="Description" label="详情" sortable="custom" />
      
    </el-table>
    <Pagination
      v-show="pagination.pageTotal>0"
      :total="pagination.pageTotal"
      :page="pagination.currentPage"
      :limit="pagination.pageSize"
      @pagination="loadTableData"
    />
  </div>
</template>

<script setup name="LogLogin">
import { getLogListWithPager, deleteLog } from '@/api/security/logservice'

const { proxy } = getCurrentInstance()

const tableData=ref([])
const tableloading=ref(true)
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);

const data = reactive({
  searchform: {
    name: '',
    IpAddres: '',
    CreateTime: ''
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
  shortcuts:[{
    text: '今天',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime())
      return [start, end]
    }
  }, {
    text: '昨天',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 1)
      return [start, end]
    }
  }, {
    text: '最近两天',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 2)
      return [start, end]
    }
  }, {
    text: '最近三天',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 3)
      return [start, end]
    }
  }, {
    text: '最近一周',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 7)
      return [start, end]
    }
  }, {
    text: '最近一个月',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 30)
      return [start, end]
    }
  }, {
    text: '最近两个月',
    value: () =>  {
      const end = new Date()
      const start = new Date()
      start.setTime(start.getTime() - 3600 * 1000 * 24 * 60)
      return [start, end]
    }
  }]
})

const { searchform, pagination,sortableData,shortcuts} = toRefs(data)

/**
 * 初始化数据
 */
function InitDictItem() {
  const end = new Date()
  const start = new Date()
  start.setTime(start.getTime() - 3600 * 1000 * 24 * 15)
  searchform.value.CreateTime = [start, end]
}  
/**
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  var seachdata = {
    CurrenetPageIndex: pagination.value.currentPage,
    PageSize: pagination.value.pageSize,
    Filter: {
      IPAddress: searchform.value.IpAddres,
      Account: searchform.value.name,
      Type: 'SQL'
    },
    Keywords: searchform.value.name,
    CreatorTime1: searchform.value.CreateTime[0],
    CreatorTime2: searchform.value.CreateTime[1],
    Order: sortableData.value.order,
    Sort: sortableData.value.sort
  }
  getLogListWithPager(seachdata).then((res) => {
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

function  deletePhysics() {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value
      }
      deleteLog(data).then((res) => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          loadTableData()
        } else {
          proxy.$modal.msgError(res.ErrMsg)
        }
      })
    })
  }
}
/**
 * 当表格的排序条件发生变化的时候会触发该事件
 */
function  handleSortChange(column) {
  if(column.prop!=null){
    sortableData.value.sort = column.prop
  }
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
function  handleSelectChange(selection) {
  ids.value = selection.map(item => item.Id);
  single.value = selection.length != 1;
  multiple.value = !selection.length;
}
loadTableData()
</script>