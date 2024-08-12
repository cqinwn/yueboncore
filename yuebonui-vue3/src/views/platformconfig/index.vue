<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="queryParams" class="demo-form-inline">
        <el-form-item label="月台号：" prop="Keywords">
        <el-input v-model="queryParams.Keywords" clearable placeholder="月台号/客户编号/客户名称" />
        </el-form-item>
        <el-form-item>
        <el-button type="primary" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
        </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
        <el-button-group>
          <el-button v-hasPermi="['PlatFormConfig/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
          <el-button v-hasPermi="['PlatFormConfig/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify" @click="ShowEditOrViewDialog('edit')">修改</el-button>
          <el-button v-hasPermi="['PlatFormConfig/Enable']" type="info" icon="video-pause" :disabled="multiple" @click="setEnable('0')" v-if="false">禁用</el-button>
          <el-button v-hasPermi="['PlatFormConfig/Enable']" type="success" icon="video-play" :disabled="multiple" @click="setEnable('1')" v-if="false">启用</el-button>
          <el-button v-hasPermi="['PlatFormConfig/DeleteSoft']" type="warning" icon="delete" :disabled="multiple" @click="deleteSoft('0')" v-if="false">软删除</el-button>
          <el-button v-hasPermi="['PlatFormConfig/Delete']" type="danger" icon="delete" :disabled="multiple" @click="deletePhysics()">删除</el-button>
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
        <el-table-column prop="PlatFormID" label="月台号" swidth="1" v-if="false"/>
        <el-table-column prop="PlatFormNo" label="月台号" sortable="custom" width="100" />   
        <el-table-column prop="CustomerID" label="客户号" sortable="custom" width="100" />        
        <el-table-column prop="CustomerName" label="绑定客户名称" sortable="custom"/> 
        <el-table-column prop="EnabledMark" label="是否可用" sortable="custom" width="120" >
             <template #default="scope">
              <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{ scope.row.EnabledMark === true ? "启用" : "禁用" }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column prop="DeleteMark" label="删除标记" sortable="custom" width="120" >
              <template #default="scope">
              <el-tag :type="scope.row.DeleteMark === true ? 'danger' : 'success'" disable-transitions>{{ scope.row.DeleteMark === true ? "已删除" : "否" }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column prop="CreatorTime" label="创建时间" sortable="custom" width="180" />
          <el-table-column prop="LastModifyTime" label="上一次修改时间" sortable="custom" width="180" />
      </el-table>
      <Pagination
        v-show="queryParams.pageTotal>0"
        :total="queryParams.pageTotal"
        v-model:page="queryParams.CurrenetPageIndex"
        v-model:limit="queryParams.PageSize"
        @pagination="loadTableData"
    />
    <el-dialog ref="dialogEditForm" draggable :title="editFormTitle+'月台配置'" v-model="dialogEditFormVisible"  width="350px" append-to-body>
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="月台编号" :label-width="formLabelWidth" prop="PlatFormID">
          <el-select  v-model="editFrom.PlatFormID" placeholder="请选择月台" :disabled="platformShowStatus">
                <el-option 
                v-for="item in platFormOptions" :key="item.Id" :label="item.PlatFormNo" :value="item.Id">
                </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="绑定客户" :label-width="formLabelWidth" prop="CustomerID">
          <el-select multiple v-model="editFrom.CustomerList" filterable clearable placeholder="请选择客户">
              <el-option 
              v-for="item in customerOptions" 
              :key="item.Id" 
              :label="item.CustomerName" 
              :value="item.CustomerID">
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

<script setup name="PlatformConfig">

import { getPlatformConfigListWithPager, getPlatformConfigDetail,
  savePlatformConfig, setPlatformConfigEnable, deleteSoftPlatformConfig,
  deletePlatformConfig } from '@/api/tms/platformconfig'

import {getAllCustomerInfoList } from '@/api/tms/customerinfo'
import {getAllPlatformList } from '@/api/tms/platform'
import { ref } from 'vue';

const { proxy } = getCurrentInstance()
const tableData=ref([])
const tableloading=ref(true)
const dialogEditFormVisible=ref(false)
const editFormTitle=ref("")
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);

const platformShowStatus = ref(false)
const customerOptions = ref([])
const platFormOptions = ref([])

const formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids = ref([])

const data = reactive({
    queryParams:{
        CurrenetPageIndex: 1,
        PageSize: 20,
        pageTotal: 0,
        Order: 'desc',
        Sort: 'PlatFormID',
        Keywords: ''
    },
    editFrom: {},
    rules: {
      PlatFormID: [
      { required: true, message: "月台不能为空", trigger: "blur" }
      ],
      CustomerList: [
      { required: true, message: "绑定客户不能为空", trigger: "blur" }
      ],
    },
})
    
const { queryParams, editFrom, rules} = toRefs(data);
/**
    * 初始化数据
    */
function InitDictItem() {
  getAllCustomerInfoList().then(res => {
    customerOptions.value = res.ResData    
  })
  getAllPlatformList().then(res => {
    platFormOptions.value = res.ResData    
  })
}
    
// 取消按钮
function cancel () {
    dialogEditFormVisible.value = false
    reset()
}
// 表单重置
function reset () {
    editFrom.value = {
        PlatFormID: '',
        CustomerList:[]
        
    //需个性化处理内容
    }
    proxy.resetForm('editFromRef')
}
/**
    * 加载页面table数据
    */
function loadTableData() {
    tableloading.value = true
    getPlatformConfigListWithPager(queryParams.value).then(res => {
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
          platformShowStatus.value = true
          bindEditInfo()
      }
    } else {
    editFormTitle.value = '新增'
    currentId.value = ''
    dialogEditFormVisible.value = true    
    platformShowStatus.value = false
    
    }
}
function bindEditInfo() {    
  var rows = proxy.$refs.gridtable.getSelectionRows();
  if(rows.length>0)
  {
    editFrom.value.PlatFormID = rows[0].PlatFormID;
    var arr = []
    editFrom.value.CustomerList = arr.concat(rows[0].CustomerID);
  }
}
/**
    * 新增/修改保存
    */
function saveEditForm() {
    console.log(JSON.stringify( editFrom.value))
    proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
        var url = 'PlatformConfig/SavePlatFormConfig'
        if (currentId.value !== '') {
        url = 'PlatformConfig/UpdatePlatformConfig'
        }
        savePlatformConfig(editFrom.value,url).then(res => {
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
    setPlatformConfigEnable(data).then(res => {
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
        return  deleteSoftPlatformConfig(data)
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
        return  deletePlatformConfig(data)
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
InitDictItem()
loadTableData()
</script>

<style>
</style>
