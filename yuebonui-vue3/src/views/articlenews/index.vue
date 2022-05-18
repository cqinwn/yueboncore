<template>
  <div class="app-container">
    <el-form
      ref="searchformRef" v-show="showSearch"
      :inline="true"
      :model="queryParams"
      class="demo-form-inline"
    >
      <el-form-item label="名称：">
        <el-input v-model="queryParams.keywords" clearable placeholder="名称" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>    
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['Articlenews/Add']" type="primary" icon="plus" @click="handleEditDataFrom()">新增</el-button>
        <el-button v-hasPermi="['Articlenews/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify" @click="handleEditDataFrom('edit')">修改</el-button>
        <el-button v-hasPermi="['Articlenews/Enable']" type="info" icon="video-pause" :disabled="multiple" @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['Articlenews/Enable']" type="success" icon="video-play" :disabled="multiple" @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['Articlenews/DeleteSoft']" type="warning" icon="delete" :disabled="multiple" @click="deleteSoft('0')">软删除</el-button>
        <el-button v-hasPermi="['Articlenews/Delete']" type="danger" icon="delete" :disabled="multiple" @click="deletePhysics()">删除</el-button>
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
      :default-sort="{prop: 'SortCode', order: 'ascending'}"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
    >
      <el-table-column type="selection" width="50" />
      <el-table-column prop="Title" label="文章标题" sortable="custom" />
      <el-table-column prop="CategoryName" label="所属分类" sortable="custom" width="120" />
      <el-table-column prop="SortCode" label="排序" sortable="custom" width="120" />
      <el-table-column label="属性" sortable="custom" width="230" prop="" align="center">
        <template #default="scope">
          <el-tag v-if="scope.row.IsTop === true" disable-transitions>置顶</el-tag>
          <el-tag v-if="scope.row.IsRed === true" type="success" disable-transitions>推荐</el-tag>
          <el-tag v-if="scope.row.IsHot === true" type="danger" disable-transitions>热门</el-tag>
          <el-tag v-if="scope.row.IsNew === true" type="warning" disable-transitions>最新</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="是否发布" sortable="custom" width="120" prop="EnabledMark" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{ scope.row.EnabledMark === true ? "已发布" : "未发布" }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="CreatorTime" label="创建时间" sortable="custom" width="160" />
    </el-table>
    <Pagination
      v-show="queryParams.pageTotal>0"
      :total="queryParams.pageTotal"
      v-model:page="queryParams.CurrenetPageIndex"
      v-model:limit="queryParams.PageSize"
      @pagination="loadTableData"
    />
  </div>
</template>

<script setup name="Articlenews">

import { getArticlenewsListWithPager, setArticlenewsEnable, deleteSoftArticlenews, deleteArticlenews } from '@/api/cms/articlenews'
import { GetAllCategoryTreeTable } from '@/api/cms/articlecategory'


const { proxy } = getCurrentInstance()
const tableData=ref([])
const tableloading=ref(true)
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);

const formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])

const selectCategory=ref([])
const data = reactive({  
  queryParams:{
    CurrenetPageIndex: 1,
    PageSize: 20,
    pageTotal: 0,
    Order: 'desc',
    Sort: 'CreatorTime',
    Keywords: ''
  },
  editFrom:{},
  rules: {
  }
})
const { queryParams, editFrom, rules} = toRefs(data)
const router = useRouter()
/**
 * 初始化数据
 */
function InitDictItem() {
  GetAllCategoryTreeTable().then(res => {
    selectCategory.value = res.ResData
  })
}
/**
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  getArticlenewsListWithPager(queryParams.value).then(res => {
    tableData.value = res.ResData.Items
    queryParams.value.pageTotal = res.ResData.TotalItems
    tableloading.value = false
  })
}
/**
 * 点击查询
 */
function handleSearch() {
  queryParams.value.CurrenetPageIndex = 1
  loadTableData()
}
/** 重置查询操作 */
function resetQuery() {
  proxy.resetForm("searchformRef");
  handleSearch();
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
    setArticlenewsEnable(data).then(res => {
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
    deleteSoftArticlenews(data).then(res => {
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
    var currentIds = []
    ids.value.forEach(element => {
      currentIds.push(element.Id)
    })
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value
      }
      return deleteArticlenews(data)
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
/**
 * 当表格的排序条件发生变化的时候会触发该事件
 */
function handleSortChange(column) {
  if(column.prop!=null){
    queryParams.value.Sort = column.prop
  }
  if (column.order === 'ascending') {
    queryParams.value.Order = 'asc'
  } else {
    queryParams.value.Order = 'desc'
  }
  loadTableData()
}

/**
 * 当用户手动勾选checkbox数据行事件
 */
function handleSelectChange(selection) {
  ids.value = selection.map(item => item.Id);
  single.value = selection.length != 1;
  multiple.value = !selection.length;
}
function handleEditDataFrom(view) {
  if (view !== undefined && view !== 'add') {
    if (ids.value.length > 1 || ids.value.length === 0) {
      proxy.$modal.alert('请选择一条数据进行编辑/修改')
    } else {
      currentId.value = ids.value[0]
      router.push({ name: 'EditArticle', params: { id: currentId.value, showtype: view }})
    }
  } else {
    router.push({ name: 'EditArticle', params: { id: 'null', showtype: 'add' }})
  }
}
InitDictItem()
loadTableData()
</script>

<style lang="scss" scoped>
</style>
