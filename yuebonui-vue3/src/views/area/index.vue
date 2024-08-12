<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="queryParams" class="demo-form-inline">
        <el-form-item label="名称：" prop="Keywords">
        <el-input v-model="queryParams.Keywords" clearable placeholder="名称/区号/编码" />
        </el-form-item>
        <el-form-item>
        <el-button type="primary" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
        </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
        <el-button-group>
          <el-button v-hasPermi="['Area/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
          <el-button v-hasPermi="['Area/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify" @click="ShowEditOrViewDialog('edit')">修改</el-button>
          <el-button v-hasPermi="['Area/Enable']" type="info" icon="video-pause" :disabled="multiple" @click="setEnable('0')">禁用</el-button>
          <el-button v-hasPermi="['Area/Enable']" type="success" icon="video-play" :disabled="multiple" @click="setEnable('1')">启用</el-button>
          <el-button v-hasPermi="['Area/DeleteSoft']" type="warning" icon="delete" :disabled="multiple" @click="deleteSoft('0')">软删除</el-button>
          <el-button v-hasPermi="['Area/Delete']" type="danger" icon="delete" :disabled="multiple" @click="deletePhysics()">删除</el-button>
          <el-button v-hasPermi="['Area/CollectData']" type="primary" icon="location" @click="handleCollectGaodeData(1)">采集高德</el-button>
          <el-button type="default" icon="refresh" @click="loadTableData()">刷新</el-button>
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
        :default-sort="{prop: 'Id', order: 'ascending'}"
        @selection-change="handleSelectChange"
        @sort-change="handleSortChange"
      >
          <el-table-column type="selection" width="50" />
          <el-table-column prop="EnCode" label="编码" sortable="custom" width="120" />
          <el-table-column prop="FullName" label="地区名称" sortable="custom" width="150" />
          <el-table-column prop="FullIdPath" label="父级路径" sortable="custom" width="270" />
          <el-table-column prop="AreaCode" label="区号" sortable="custom" width="120" />
          <el-table-column prop="ZipCode" label="邮编" sortable="custom" width="120" />
          <el-table-column prop="Province" label="省份" sortable="custom" width="160" />
          <el-table-column prop="City" label="城市" sortable="custom" width="120" />
          <el-table-column prop="District" label="县区" sortable="custom" width="120" />
          <el-table-column prop="Town" label="乡镇" sortable="custom" width="120" />
          <el-table-column prop="SortCode" label="排序码" sortable="custom" width="120" />
          <el-table-column prop="EnabledMark" label="有效标志" sortable="custom" width="120" >
             <template #default="scope">
              <el-tag
                :type="scope.row.EnabledMark === true ? 'success' : 'info'"
                disable-transitions
              >{{ scope.row.EnabledMark === true ? '启用' : '禁用' }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column prop="DeleteMark" label="删除标志" sortable="custom" width="120" > 
            <template #default="scope">
              <el-tag
                :type="scope.row.DeleteMark === true ? 'danger' : 'success'"
                disable-transitions
              >{{ scope.row.DeleteMark === true ? '已删除' : '否' }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column prop="CreatorTime" label="创建日期" sortable="custom" width="160" />
          <el-table-column prop="LastModifyTime" label="最后修改时间" sortable="custom" width="160" />
      </el-table>
      <Pagination
        v-show="queryParams.pageTotal>0"
        :total="queryParams.pageTotal"
        v-model:page="queryParams.CurrenetPageIndex"
        v-model:limit="queryParams.PageSize"
        @pagination="loadTableData"
    />
    <el-dialog ref="dialogEditForm" draggable :title="editFormTitle+'地区信息'" v-model="dialogEditFormVisible"  width="660px" append-to-body>
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="父级" :label-width="formLabelWidth" prop="ParentId">
          <el-cascader
              v-model="selectedAreaOptions"
              style="width: 500px"
              :options="selectArea"
              filterable
              :props="props"
              clearable
              @change="handleSelectAreaChange"
            />
        </el-form-item>
        <el-form-item label="编码" :label-width="formLabelWidth" prop="EnCode">
          <el-input v-model="editFrom.EnCode" placeholder="请输入编码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="名称" :label-width="formLabelWidth" prop="FullName">
          <el-input v-model="editFrom.FullName" placeholder="请输入名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="拼音" :label-width="formLabelWidth" prop="Pinyin">
          <el-input v-model="editFrom.Pinyin" placeholder="请输入拼音" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="简拼" :label-width="formLabelWidth" prop="SimpleSpelling">
          <el-input v-model="editFrom.SimpleSpelling" placeholder="请输入简拼" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="区号" :label-width="formLabelWidth" prop="AreaCode">
          <el-input v-model="editFrom.AreaCode" placeholder="请输入区号" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="邮编" :label-width="formLabelWidth" prop="ZipCode">
          <el-input v-model="editFrom.ZipCode" placeholder="请输入邮编" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="排序码" :label-width="formLabelWidth" prop="SortCode">
          <el-input v-model="editFrom.SortCode" placeholder="请输入排序码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="有效标志" :label-width="formLabelWidth" prop="EnabledMark">
            <el-radio-group v-model="editFrom.EnabledMark">
              <el-radio :label="true">是</el-radio>
              <el-radio :label="false">否</el-radio>
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

<script setup name="Area">
import { getAreaListWithPager, getAreaDetail,
  saveArea, setAreaEnable, deleteSoftArea,
  deleteArea, collectGaodeData, getAllSubAreaByParentId } from '@/api/security/area'
import { ref } from 'vue'

const { proxy } = getCurrentInstance()
const tableData=ref([])
const tableloading=ref(true)
const dialogEditFormVisible=ref(false)
const editFormTitle=ref("")
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);
const selectedAreaOptions=ref("")
const formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])
let selectArea = ref([])
const data = reactive({
    queryParams:{
        CurrenetPageIndex: 1,
        PageSize: 20,
        pageTotal: 0,
        Order: 'asc',
        Sort: 'EnCode',
        Keywords: ''
    },
    editFrom: {},
  rules: {
    ParentId: [
      { required: true, message: "请输入父级", trigger: "blur" },
      { min: 2, max: 50, message: "长度在 2 到 50 个字符", trigger: "blur" }
    ],
  },
})

const props={
  label: 'FullName',
  value: 'Id',
  children: 'Child',
  emitPath: false,
  checkStrictly: true,
  expandTrigger: 'hover',
  lazy: true,
  lazyLoad: handleGetSubArea,
}
const { queryParams, editFrom, rules } = toRefs(data);

function handleGetSubArea (node, resolve) {
  const { level, data } = node;//等同于const data = node.data
  getAllSubAreaByParentId(data.Id).then(res => {
    const nodes = res.ResData
    nodes.forEach(item => {
      item.leaf = level >= 3
    });
    resolve(nodes)
  })
}
/**
    * 初始化数据
    */
function InitDictItem () {
  getAllSubAreaByParentId('1000000').then(res => {
    selectArea.value = res.ResData
  })
}
    
// 取消按钮
function cancel () {
    dialogEditFormVisible.value = false
    reset()
}

/**
 *选择组织
  */
function handleSelectAreaChange () {
  if (currentId.value === selectedAreaOptions.value) {
    proxy.$modal.alert('不能选择自己作为父级')
    selectedAreaOptions.value = ''
    return
  }
  editFrom.value.ParentId = selectedAreaOptions.value
}
// 表单重置
function reset () {
  editFrom.value = {
    ParentId: '',
    EnCode: '',
    FullName: '',
    Pinyin: '',
    SimpleSpelling: '',
    FullIdPath: '',
    AreaCode: '',
    ZipCode: '',
    SortCode: '99',
    EnabledMark: ''
    //需个性化处理内容
  }
  proxy.resetForm('editFromRef')
}
/**
    * 加载页面table数据
    */
function loadTableData() {
    tableloading.value = true
    getAreaListWithPager(queryParams.value).then(res => {
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

/**
    * 新增、修改或查看明细信息（绑定显示数据）     *
    */
function ShowEditOrViewDialog(view) {
    reset()
    if (view !== undefined) {
    if (ids.value.length > 1 || ids.value.length === 0) {
        proxy.$modal.alert('请选择一条数据进行编辑/修改', '提示')
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
    }
}
function bindEditInfo() {
    getAreaDetail(currentId.value).then(res => {
    editFrom.value = res.ResData
    //需个性化处理内容

    })
}
/**
    * 新增/修改保存
    */
function saveEditForm() {
    proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
        var url = 'Area/Insert'
        if (currentId.value !== '') {
        url = 'Area/Update'
        }
        saveArea(editFrom.value,url).then(res => {
        if (res.Success) {
            proxy.$modal.msgSuccess('恭喜你，操作成功')
            dialogEditFormVisible.value = false
            loadTableData()
            InitDictItem()
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
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    setAreaEnable(data).then(res => {
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
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value,
        Flag: val
      }
        return  deleteSoftArea(data)
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
function deletePhysics() {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
    } else {
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value
      }
        return  deleteArea(data)
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
/**
 * 采集高德地图地区数据
 */
function handleCollectGaodeData () {
   proxy.$modal.confirm('是否确认重新采集高德地图地区数据，会删除历史数据，建议系统初始化时采集?').then(function () {
    return collectGaodeData()
  }).then(res => {
    if (res.Success) {
      proxy.$modal.msgSuccess('恭喜你，操作成功')
      loadTableData()
    } else {
      proxy.$modal.msgError(res.ErrMsg)
    }
  })
}
InitDictItem()
loadTableData()
</script>

<style>
</style>
