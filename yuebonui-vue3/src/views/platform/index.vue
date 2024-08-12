<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="queryParams" class="demo-form-inline">
      <el-form-item label="月台名称：" prop="Keywords">
        <el-input v-model="queryParams.Keywords" clearable placeholder="月台名称关键字" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['PlatForm/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
        <el-button v-hasPermi="['PlatForm/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify"
          @click="ShowEditOrViewDialog('edit')">修改</el-button>
        <el-button v-hasPermi="['PlatForm/Enable']" type="info" icon="video-pause" :disabled="multiple"
          @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['PlatForm/Enable']" type="success" icon="video-play" :disabled="multiple"
          @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['PlatForm/DeleteSoft']" type="warning" icon="delete" :disabled="multiple"
          @click="deleteSoft('0')" v-if="false">软删除</el-button>
        <el-button v-hasPermi="['PlatForm/Delete']" type="danger" icon="delete" :disabled="multiple"
          @click="deletePhysics()">删除</el-button>
        <el-button type="default" icon="refresh" @click="loadTableData()">刷新</el-button>
      </el-button-group>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="loadTableData"></right-toolbar>
    </el-row>
    <el-table ref="gridtable" v-loading="tableloading" :data="tableData" stripe highlight-current-row style="width: 100%"
      :default-sort="{ prop: 'Id', order: 'ascending' }" @selection-change="handleSelectChange"
      @sort-change="handleSortChange">
      <el-table-column type="selection" width="50" />
      <el-table-column prop="PlatFormNo" label="月台号" sortable="custom" width="120" />
      <el-table-column prop="PlatFormShowName" label="月台显示名称" sortable="custom" width="150" />
      <el-table-column prop="WareHouseName" label="绑定仓库" sortable="custom" width="150" />
      <el-table-column prop="PlatFormTypeName" label="使用性质" sortable="custom" width="150" />
      <el-table-column prop="EnabledMark" label="是否可用" sortable="custom" width="120" :formatter="formatEnabled" />
    </el-table>
    <Pagination v-show="queryParams.pageTotal > 0" :total="queryParams.pageTotal"
      v-model:page="queryParams.CurrenetPageIndex" v-model:limit="queryParams.PageSize" @pagination="loadTableData" />
    <el-dialog ref="dialogEditForm" draggable :title="editFormTitle + '月台管理'" v-model="dialogEditFormVisible" width="350px"
      append-to-body>
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="月台编号" :label-width="formLabelWidth" prop="PlatFormNo">
          <el-input v-model="editFrom.PlatFormNo" placeholder="请输入月台编号" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="显示名称" :label-width="formLabelWidth" prop="PlatFormShowName">
          <el-input v-model="editFrom.PlatFormShowName" placeholder="请输入月台显示名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="绑定仓库" :label-width="formLabelWidth" prop="WareHouseID">
          <el-select ref="warehouseRef" v-model="editFrom.WareHouseID" placeholder="请选择仓库">
            <el-option v-for="item in warehouseOptions" :key="item.ItemCode" :label="item.ItemName"
              :value="item.ItemCode">
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="使用类型" :label-width="formLabelWidth" prop="PlatFormType">
          <el-select ref="platformTypeRef" v-model="editFrom.PlatFormType" placeholder="请选择类型">
            <el-option v-for="item in platformTypeOptions" :key="item.ItemCode" :label="item.ItemName"
              :value="item.ItemCode">
            </el-option>
          </el-select>
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

<script setup name="Platform">
import { getListItemDetailsByCode } from '@/api/basebasic'
import {
  getPlatformListWithPager, getPlatformDetail,
  savePlatform, setPlatformEnable, deleteSoftPlatform,
  deletePlatform, checkPlatFormRepeatAsync
} from '@/api/tms/platform'

const { proxy } = getCurrentInstance()
const tableData = ref([])
const tableloading = ref(true)
const dialogEditFormVisible = ref(false)
const editFormTitle = ref("")
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);

const warehouseOptions = ref([])
const platformTypeOptions = ref([])

const formLabelWidth = ref("100px")
const currentId = ref("")// 当前操作对象的ID值，主要用于修改
const ids = ref([])

const data = reactive({
  queryParams: {
    CurrenetPageIndex: 1,
    PageSize: 20,
    pageTotal: 0,
    Order: 'desc',
    Sort: 'CreatorTime',
    Keywords: ''
  },
  editFrom: {},
  rules: {
    PlatFormNo: [
      { required: true, message: "月台编号不能为空", trigger: "blur" }
    ],
    PlatFormShowName: [
      { required: true, message: "月台名称不能为空", trigger: "blur" }
    ],
    WareHouseID: [
      { required: true, message: "绑定仓库不能为空", trigger: "blur" }
    ],
    PlatFormType: [
      { required: true, message: "使用类型不能为空", trigger: "blur" }
    ],
  },
})

const { queryParams, editFrom, rules } = toRefs(data);
/**
    * 初始化数据
    */
function InitDictItem() {
  getListItemDetailsByCode('WareHouse').then(res => {
    warehouseOptions.value = res.ResData
  })
  getListItemDetailsByCode('PlatFormType').then(res => {
    platformTypeOptions.value = res.ResData
  })
}

// 取消按钮
function cancel() {
  dialogEditFormVisible.value = false
  reset()
}
// 表单重置
function reset() {
  editFrom.value = {
    PlatFormNo: '',
    PlatFormShowName: '',
    WareHouseID: '',
    WareHouseName: '',
    PlatFormType: '',
    PlatFormTypeName: '',
    Note: '',
    PrintCount: '',
    Status: '1',
    EnabledMark: true,
    DeleteMark: false,
    CreatorTime: '',
    CreatorUserId: '',
    CompanyId: '',
    DeptId: '',
    LastModifyTime: '',
    LastModifyUserId: '',
    DeleteTime: '',
    DeleteUserId: '',
    TenantId: '',

    //需个性化处理内容
  }
  proxy.resetForm('editFromRef')
}
/**
    * 加载页面table数据
    */
function loadTableData() {
  tableloading.value = true
  getPlatformListWithPager(queryParams.value).then(res => {
    tableData.value = res.ResData.Items
    queryParams.value.pageTotal = res.ResData.TotalItems
    tableloading.value = false
  })
}

function formatEnabled(row, column) {
  if (row[column.property] == '1') {
    return '是'
  } else {
    return '否'
  }
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
  getPlatformDetail(currentId.value).then(res => {
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

      checkPlatFormRepeatAsync(editFrom.value).then(res => {
        if (res.Success) {
          if (res.ErrMsg != '') {
            proxy.$modal.msgSuccess(res.ErrMsg)
            return false;
          } else {


            var warehousename = proxy.$refs['warehouseRef'].selected.currentLabel;
            var platformtypename = proxy.$refs['platformTypeRef'].selected.currentLabel
            editFrom.value.WareHouseName = warehousename
            editFrom.value.PlatFormTypeName = platformtypename

            var url = 'Platform/Insert'
            if (currentId.value !== '') {
              url = 'Platform/Update'
            }
            savePlatform(editFrom.value, url).then(res => {
              if (res.Success) {
                proxy.$modal.msgSuccess('恭喜你，操作成功')
                dialogEditFormVisible.value = false
                loadTableData()
                InitDictItem()
              } else {
                proxy.$modal.msgError(res.ErrMsg)
              }
            })


          }

        } else {
          return true;
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
    setPlatformEnable(data).then(res => {
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
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function () {
      const data = {
        Ids: ids.value,
        Flag: val
      }
      return deleteSoftPlatform(data)
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
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function () {
      const data = {
        Ids: ids.value
      }
      return deletePlatform(data)
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
  if (column.prop != null) {
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
InitDictItem()
loadTableData()

</script>

<style></style>
