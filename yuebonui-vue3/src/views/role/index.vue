<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="searchform" class="demo-form-inline">
      <el-form-item label="角色名称：" prop="name">
        <el-input v-model="searchform.name" clearable placeholder="角色名称或编码" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="handleSearch">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button
          v-hasPermi="['Role/Add']"
          type="primary"
          icon="plus"
          @click="ShowEditOrViewDialog()"
        >新增</el-button>
        <el-button
          v-hasPermi="['Role/Edit']"
          type="primary"
          icon="edit"
          class="el-button-modify"
          :disabled="single"
          @click="ShowEditOrViewDialog('edit')"
        >修改</el-button>
        <el-button
          v-hasPermi="['Role/Enable']"
          type="info"
          icon="video-pause"
          :disabled="multiple"
          @click="setEnable('0')"
        >禁用</el-button>
        <el-button
          v-hasPermi="['Role/Enable']"
          type="success"
          icon="video-play"
          :disabled="multiple"
          @click="setEnable('1')"
        >启用</el-button>
        <el-button
          v-hasPermi="['Role/DeleteSoft']"
          type="warning"
          icon="delete"
          :disabled="multiple"
          @click="deleteSoft('0')"
        >软删除</el-button>
        <el-button
          v-hasPermi="['Role/Delete']"
          type="danger"
          icon="delete"
          :disabled="multiple"
          @click="deletePhysics()"
        >删除</el-button>
        <el-button
          v-hasPermi="['Role/SetAuthorize']"
          type="default"
          icon="coordinate"
          :disabled="single"
          @click="handleSetAuth"
        >分配权限</el-button>
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
      :default-sort="{ prop: 'SortCode', order: 'descending' }"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
    >
      <el-table-column type="selection" width="55" />
      <el-table-column prop="FullName" label="角色名称" sortable="custom" width="180" />
      <el-table-column prop="EnCode" label="角色编码" sortable="custom" width="180" />
      <el-table-column prop="Type" label="类型" sortable="custom" width="90" align="center">
        <template #default="scope">
          <slot v-if="scope.row.Type === '1'">系统角色</slot>
          <slot v-else-if="scope.row.Type === '2'">业务角色</slot>
          <slot v-else-if="scope.row.Type === '3'">其他角色</slot>
        </template>
      </el-table-column>
      <el-table-column prop="OrganizeName" label="所属组织" width="220"/>
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
      <el-table-column prop="CreatorTime" label="创建时间" width="160" sortable />
      <el-table-column prop="LastModifyTime" label="更新时间" width="160" sortable />
    </el-table>
    <Pagination
      v-show="pagination.pageTotal>0"
      :total="pagination.pageTotal"
      :page="pagination.currentPage"
      :limit="pagination.pageSize"
      @pagination="loadTableData"
    />
    <el-dialog ref="dialogEditForm" draggable :title="editFormTitle + '角色'" v-model="dialogEditFormVisible">
      <el-form ref="editFromRef" :inline="true" :model="editFrom" :rules="rules" class="demo-form-inline">
        <el-form-item label="角色名称" :label-width="formLabelWidth" prop="FullName">
          <el-input v-model="editFrom.FullName" placeholder="请输入角色名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="角色编码" :label-width="formLabelWidth" prop="EnCode">
          <el-input v-model="editFrom.EnCode" placeholder="请输入角色编码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="角色类型" :label-width="formLabelWidth" prop="RoleType">
          <el-select v-model="editFrom.RoleType" clearable placeholder="请选角色类型">
            <el-option v-for="item in selectRoleType" :key="item.Id" :label="item.ItemName" :value="item.ItemCode" />
          </el-select>
        </el-form-item>
        <el-form-item label="归属组织" :label-width="formLabelWidth" prop="OrganizeId">
          <el-cascader
            :key="cascaderKey"
            v-model="selectedOrganizeOptions"
            :options="selectOrganize"
            filterable
            :props="{
              label: 'FullName',
              value: 'Id',
              children: 'Children',
              emitPath: false,
              checkStrictly: true,
              expandTrigger: 'hover',
            }"
            clearable
            @change="handleSelectOrganizeChange"
          />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
          <el-input v-model.number="editFrom.SortCode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="描述" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="是否启用" :label-width="formLabelWidth" prop="EnabledMark">
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

    <el-dialog ref="dialogSetAuthForm" draggable title="分配权限" v-model="dialogSetAuthFormVisible" width="70%">
      <el-tabs v-model="ActionName" type="border-card">
        <el-tab-pane label="可用系统" name="treeSystem">
          <el-card class="box-card">
            <el-tree ref="treeSystemRef" :data="treeSystemData" :check-strictly="true" empty-text="加载中，请稍后" show-checkbox default-expand-all node-key="Id" highlight-current :props="{ label: 'FullName', children: 'Children' }" />
          </el-card>
        </el-tab-pane>
        <el-tab-pane label="功能菜单" name="treeFunction">
          <el-card class="box-card">
            <el-tree ref="treeFunctionRef" :data="treeFuntionData" :check-strictly="true" empty-text="加载中，请稍后" show-checkbox default-expand-all node-key="Id" highlight-current :props="{ label: 'FullName', children: 'Children',disabled:'IsShow'}" />
          </el-card>
        </el-tab-pane>
        <el-tab-pane label="数据权限" name="treeOrganize">
          <el-card class="box-card">
            <el-tree ref="treeOrganizeRef" :data="treeOrganizeData" :check-strictly="true" empty-text="加载中，请稍后" show-checkbox default-expand-all node-key="Id" highlight-current :props="{ label: 'FullName', children: 'Children' }" />
          </el-card>
        </el-tab-pane>
      </el-tabs>
      <template #footer>
        <div class="dialog-footer">
          <el-button @click="dialogSetAuthFormVisible = false">取 消</el-button>
          <el-button type="primary" @click="handleSaveRoleAuthorize()">保 存</el-button>
        </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="Role">

import { getListItemDetailsByCode } from '@/api/basebasic'
import {
  getRoleListWithPager, getRoleDetail, saveRole,
  setRoleEnable, deleteSoftRole, deleteRole, getRoleAuthorizeFunction,
  getAllFunctionTree, getAllRoleDataByRoleId, saveRoleAuthorize
} from '@/api/security/roleservice'

import { getAllOrganizeTreeTable } from '@/api/security/organizeservice'
import { getAllSystemTypeList } from '@/api/developers/systemtypeservice'
import { ElLoading} from 'element-plus'
import { nextTick } from '@vue/runtime-core'

const { proxy } = getCurrentInstance()

const tableData=ref([])
const tableloading=ref(true)
const dialogEditFormVisible=ref(false)
const editFormTitle=ref("")
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);
      
const formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])


const selectRoleType=ref([])
const selectedOrganizeOptions=ref("")
const selectOrganize=ref([])

const pageLoading=ref("")
const dialogSetAuthFormVisible=ref(false) 
const treeFuntionData=ref([])
const default_select=ref([])
const defaultOrganize_select=ref([])
const treeOrganizeData=ref([])
const defaultSystem_select=ref([])
const treeSystemData=ref([])
const cascaderKey=ref(0)
const ActionName=ref("treeSystem")
const treeSystemRef=ref(null)
const treeFunctionRef=ref(null)
const treeOrganizeRef=ref(null)

const data = reactive({
  searchform: {
    name: ''
  },
  pagination: {
    currentPage: 1,
    pageSize: 20,
    pageTotal: 0
  },
  sortableData: {
    order: 'desc',
    sort: 'SortCode'
  },
  editFrom:{},
  rules: {
    FullName: [
      { required: true, message: '请输入角色名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    EnCode: [
      { required: true, message: '请输入角色编码', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    RoleType: [
      { required: true, message: '请角色类型', trigger: 'blur' }
    ],
    OrganizeId: [
      { required: true, message: '请选择所属部门', trigger: 'blur' }
    ]
  }
})

const { searchform, editFrom, rules ,pagination,sortableData,shortcuts} = toRefs(data);


/**
 * 初始化数据
 */
function InitDictItem() {
  getListItemDetailsByCode('RoleType').then(res => {
    selectRoleType.value = res.ResData
  })

  getAllOrganizeTreeTable().then(res => {
    ++cascaderKey.value
    selectOrganize.value = res.ResData
  })

  getAllFunctionTree().then(res => {
    treeFuntionData.value = res.ResData
  })
  getAllOrganizeTreeTable().then(res => {
    treeOrganizeData.value = res.ResData
  })
  getAllSystemTypeList().then(res => {
    treeSystemData.value = res.ResData
  })
}
/**
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  var seachdata = {
    CurrenetPageIndex: pagination.value.currentPage,
    PageSize: pagination.value.pageSize,
    Keywords: searchform.value.name,
    Order: sortableData.value.order,
    Sort: sortableData.value.sort
  }
  getRoleListWithPager(seachdata).then(res => {
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

/**
 *选择组织
  */
function handleSelectOrganizeChange() {
  editFrom.value.OrganizeId = selectedOrganizeOptions.value
}
// 表单重置
function reset() {
  editFrom.value = {
    FullName: '',
    EnCode: '',
    RoleType: '',
    OrganizeId: '',
    SortCode: 99,
    EnabledMark: true,
    Description: ''
  }
  selectedOrganizeOptions.value = ''
  proxy.resetForm('editFromRef')
}
/**
 * 新增、修改或查看明细信息（绑定显示数据）     *
 */
function ShowEditOrViewDialog(view) {
  reset()
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
  }
}
function bindEditInfo() {
  getRoleDetail(currentId.value).then(res => {
    editFrom.value = res.ResData
    selectedOrganizeOptions.value= res.ResData.OrganizeId
    editFrom.value.RoleType=res.ResData.Type
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      const data = {
        'OrganizeId': editFrom.value.OrganizeId,
        'EnCode': editFrom.value.EnCode,
        'FullName': editFrom.value.FullName,
        'Type': editFrom.value.RoleType,
        'SortCode': editFrom.value.SortCode,
        'EnabledMark': editFrom.value.EnabledMark,
        'Description': editFrom.value.Description,
        'Id': currentId.value
      }
      var url = 'Role/Insert'
      if (currentId.value !== '') {
        url = 'Role/Update'
      }
      saveRole(data, url).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          dialogEditFormVisible.value = false
          loadTableData()
          InitDictItem()
        } else {
          proxy.$modal.msgError(res.ErrMsg)
        }
      })
      // pageLoading.close()
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
    setRoleEnable(data).then(res => {
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
    deleteSoftRole(data).then(res => {
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
      return deleteRole(data)
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
function handleSelectChange(selection) {
  ids.value = selection.map(item => item.Id);
  single.value = selection.length != 1;
  multiple.value = !selection.length;
}
/**
 * 设置权限
 */
function handleSetAuth() {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要设置权限的角色')
    return false
  } else {
    currentId.value = ids.value[0]
    dialogSetAuthFormVisible.value = true
    ActionName.value = 'treeSystem'
    treeOrganizeRef.value.setCheckedKeys([]);
    treeFunctionRef.value.setCheckedKeys([]);
    treeSystemRef.value.setCheckedKeys([]);
    const datar = {
      roleId: currentId.value
    }
    getAllRoleDataByRoleId(datar).then(res => {
      let checkedKeys=res.ResData
      checkedKeys.forEach((v) => {
        nextTick(() => {
          treeOrganizeRef.value.setChecked(v, true, false);
        });
      });
    })

    const data = {
      roleId: currentId.value,
      itemType: '1,2'
    }
    getRoleAuthorizeFunction(data).then(res => {
      let checkedKeys=res.ResData
      checkedKeys.forEach((v) => {
        nextTick(() => {
          treeFunctionRef.value.setChecked(v, true, false);
        });
      });
    })
    const datas = {
      roleId: currentId.value,
      itemType: '0'
    }
    getRoleAuthorizeFunction(datas).then(res => {
      let checkedKeys=res.ResData
      checkedKeys.forEach((v) => {
        nextTick(() => {
          treeSystemRef.value.setChecked(v, true, false);
        });
      });
    })
  }
}

/**
 * 保存权限
 */
function handleSaveRoleAuthorize() {
  // var loadop = {
  //   lock: true,
  //   text: '正在保存数据，请耐心等待...',
  //   spinner: 'loading',
  //   background: 'rgba(0, 0, 0, 0.7)'
  // }
  // pageLoading = ElLoading.service(loadop)
  // 目前被选中的菜单节点
  const checkedKeysTreeFunction = treeFunctionRef.value.getCheckedKeys()
  // 半选中的菜单节点
  const halfCheckedKeysTreeFunction =treeFunctionRef.value.getHalfCheckedKeys()
  checkedKeysTreeFunction.unshift.apply(checkedKeysTreeFunction, halfCheckedKeysTreeFunction)

  const checkedKeysTreeOrganize = treeOrganizeRef.value.getCheckedKeys()
  const halfCheckedKeysTreeOrganize = treeOrganizeRef.value.getHalfCheckedKeys()
  checkedKeysTreeOrganize.unshift.apply(checkedKeysTreeOrganize, halfCheckedKeysTreeOrganize)

  const checkedKeysTreeSystem = treeSystemRef.value.getCheckedKeys()
  const halfCheckedKeysTreeSystem = treeSystemRef.value.getHalfCheckedKeys()
  checkedKeysTreeSystem.unshift.apply(checkedKeysTreeSystem, halfCheckedKeysTreeSystem)

  var data = {
    'RoleFunctios': checkedKeysTreeFunction,
    'RoleData': checkedKeysTreeOrganize,
    'RoleSystem': checkedKeysTreeSystem,
    'RoleId': currentId.value
  }
  saveRoleAuthorize(data).then(res => {
    if (res.Success) {
      proxy.$modal.msgSuccess('恭喜你，操作成功')
      // default_select = []
      // defaultOrganize_select = []
      // defaultSystem_select = []
      dialogSetAuthFormVisible.value = false
    } else {
      proxy.$modal.msgError(res.ErrMsg)
    }
    //pageLoading.close()
  })
}


  InitDictItem()
  loadTableData()
</script>

<style>
.el-cascader {
  width: 100%;
}
.box-card {
  max-height: 600px;
  overflow-y: scroll;
}
</style>
