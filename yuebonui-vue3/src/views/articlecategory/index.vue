<template>
  <div class="app-container">
    <el-form
      ref="searchformRef" v-show="showSearch"
      :inline="true"
      :model="searchform"
      class="demo-form-inline"
    >
      <el-form-item label="名称：" prop="keywords">
        <el-input v-model="searchform.keywords" clearable placeholder="名称" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['Articlecategory/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
        <el-button v-hasPermi="['Articlecategory/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify" @click="ShowEditOrViewDialog('edit')">修改</el-button>
        <el-button v-hasPermi="['Articlecategory/Enable']" type="info" icon="video-pause" :disabled="multiple" @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['Articlecategory/Enable']" type="success" icon="video-play" :disabled="multiple" @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['Articlecategory/DeleteSoft']" type="warning" icon="delete" :disabled="multiple" @click="deleteSoft('0')">软删除</el-button>
        <el-button v-hasPermi="['Articlecategory/Delete']" type="danger" icon="delete" :disabled="multiple" @click="deletePhysics()">删除</el-button>
      
      </el-button-group>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="loadTableData"></right-toolbar>
    </el-row>
    <el-table
      ref="gridtable"
      v-loading="tableloading"
      :data="tableData"
      row-key="Id"
      stripe
      highlight-current-row
      style="width: 100%"
      default-expand-all
      :tree-props="{ children: 'Children' }"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
    >
      <el-table-column type="selection" width="50" />
      <el-table-column prop="Title" label="标题" sortable="custom" />
      <el-table-column prop="SortCode" label="排序" sortable="custom" width="120" />
      <el-table-column label="是否启用" sortable="custom" width="120" prop="EnabledMark" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{ scope.row.EnabledMark === true ? "启用" : "禁用" }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="是否删除" sortable="custom" width="120" prop="DeleteMark" align="center">
        <template #default="scope">
          <el-tag :type="scope.row.DeleteMark === true ? 'danger' : 'success'" disable-transitions>{{ scope.row.DeleteMark === true ? "已删除" : "否" }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="CreatorTime" label="创建时间" sortable="custom" width="180" />
    </el-table>
    <el-dialog
      ref="dialogEditForm"
      draggable
      :title="editFormTitle+'分类'"
      v-model="dialogEditFormVisible"
      width="660px"
    >
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="标题" :label-width="formLabelWidth" prop="Title">
          <el-input v-model="editFrom.Title" placeholder="请输入标题" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="上级分类" :label-width="formLabelWidth" prop="ParentId">
          <el-cascader
            v-model="selectedCategoryOptions"
            style="width: 500px"
            :options="selectCategory"
            filterable
            :props="{
              label: 'Title',
              value: 'Id',
              children: 'Children',
              emitPath: false,
              checkStrictly: true,
              expandTrigger: 'hover',
            }"
            clearable
            @change="handleSelectCategoryChange"
          />
        </el-form-item>
        <el-form-item label="外链地址" :label-width="formLabelWidth" prop="LinkUrl">
          <el-input v-model="editFrom.LinkUrl" placeholder="请输入外链地址" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
          <el-input v-model.number="editFrom.SortCode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="描述" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="是否启用" :label-width="formLabelWidth" prop="EnabledMark">
          <el-radio-group v-model="editFrom.EnabledMark">
            <el-radio label="true">是</el-radio>
            <el-radio label="false">否</el-radio>
          </el-radio-group>
        </el-form-item>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button @click="dialogEditFormVisible = false">取 消</el-button>
          <el-button type="primary" @click="saveEditForm()">确 定</el-button>
        </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="Articlecategory">

import { GetAllCategoryTreeTable, getArticlecategoryDetail,
  saveArticlecategory, setArticlecategoryEnable, deleteSoftArticlecategory,
  deleteArticlecategory } from '@/api/cms/articlecategory'


const { proxy } = getCurrentInstance()
const tableData=ref([])
const tableloading=ref(true)
const dialogEditFormVisible=ref(false)
const editFormTitle=ref("")
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);

const formLabelWidth=ref("120px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])
const selectedCategoryOptions=ref('')
const selectCategory=ref([])

const data = reactive({
  searchform: {
    keywords: ''
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
  editFrom:{},
  rules: {
    Title: [
      { required: true, message: '请输入名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ]
  }
})
const { searchform, editFrom, rules ,pagination,sortableData} = toRefs(data);

/**
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  var seachdata = {
    keyword: searchform.value.keywords
  }
  GetAllCategoryTreeTable(seachdata).then(res => {
    tableData.value = res.ResData
    selectCategory.value = res.ResData
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
/**
 * 选择分类
 */
function handleSelectCategoryChange() {
  editFrom.value.ParentId = selectedCategoryOptions.value
}
/**
 * 新增、修改或查看明细信息（绑定显示数据）     *
 */
function ShowEditOrViewDialog(view) {
  if (view !== undefined) {
    if (ids.value.length > 1 || ids.value.length === 0) {
      proxy.$modal.alert('请选择一条数据进行编辑/修改')
    } else {
      currentId.value = ids.value[0]
      editFormTitle.value = '编辑'
      dialogEditFormVisible.value = true
      bindEditInfo()
    }
  } else {
    editFormTitle.value = '新增'
    currentId.value = ''
    dialogEditFormVisible.value = true
    selectedCategoryOptions.value = ''
  }
}
function bindEditInfo() {
  getArticlecategoryDetail(currentId.value).then(res => {
    editFrom.value=res.ResData
    selectedCategoryOptions.value = res.ResData.ParentId
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      var url = 'Articlecategory/Insert'
      if (currentId.value !== '') {
        url = 'Articlecategory/Update'
      }
      saveArticlecategory(editFrom.value, url).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          dialogEditFormVisible.value = false
          loadTableData()
        } else {
          proxy.$modal.msgError(res.ErrMsg)
        }
      })
    } else {
      return false
    }
  })
}
function setEnable(val) {
  if (ids.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    setArticlecategoryEnable(data).then(res => {
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
  if (ids.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    deleteSoftArticlecategory(data).then(res => {
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
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value
      }
      return deleteArticlecategory(data)
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
function handleSelectChange(selection, row) {
  ids.value = selection.map(item => item.Id);
  single.value = selection.length != 1;
  multiple.value = !selection.length;
}
loadTableData()
</script>

<style>
</style>
