<template>
  <div class="app-container">
    <el-card>
      <el-row :gutter="24">
        <el-col :span="10">
          <div class="grid-content bg-purple">
            <div class="grid-content bg-purple">
              <div class="list-btn-container">
                <el-form ref="searchmenuform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
                  <el-form-item>
                    <el-button-group>
                      <el-button type="default" icon="el-icon-refresh" size="small" @click="loadTableData()">刷新</el-button>
                      <el-button
                        v-hasPermi="['Items/Add']"
                        type="primary"
                        icon="el-icon-plus"
                        size="small"
                        @click="ShowItemsEditOrViewDialog()"
                      >新增</el-button>
                      <el-button
                        v-hasPermi="['Items/Edit']"
                        type="primary"
                        icon="el-icon-edit"
                        class="el-button-modify"
                        size="small"
                        @click="ShowItemsEditOrViewDialog('edit')"
                      >修改</el-button>
                      <el-button
                        v-hasPermi="['Items/Enable']"
                        type="info"
                        icon="el-icon-video-pause"
                        size="small"
                        @click="handerSetItemsEnable('0')"
                      >禁用</el-button>
                      <el-button
                        v-hasPermi="['Items/Enable']"
                        type="success"
                        icon="el-icon-video-play"
                        size="small"
                        @click="handerSetItemsEnable('1')"
                      >启用</el-button>
                      <el-button
                        v-hasPermi="['Items/Delete']"
                        type="danger"
                        icon="el-icon-delete"
                        size="small"
                        @click="deleteItemsPhysics()"
                      >删除</el-button>
                    </el-button-group>
                  </el-form-item>
                </el-form>
              </div>
              <el-table
                :data="tableDataItemss"
                style="width: 100%;margin-bottom: 20px;"
                row-key="Id"
                border
                max-height="850"
                default-expand-all
                highlight-current-row
                :tree-props="{children: 'Children'}"
                @row-click="handleClickItemsChange"
              >
                <el-table-column
                  prop="FullName"
                  label="名称"
                />
                <el-table-column
                  label="状态"
                  width="80"
                  prop="EnabledMark"
                  align="center"
                >
                  <template #default="scope">
                    <el-tag
                      :type="scope.row.EnabledMark === true ? 'success' : 'info'"
                      disable-transitions
                    >{{ scope.row.EnabledMark===true?'启用':'禁用' }}</el-tag>
                  </template>
                </el-table-column>
              </el-table>
            </div>
          </div>
        </el-col>
        <el-col :span="14">
          <div class="grid-content bg-purple">
            <div class="list-btn-container">
              <el-form ref="searchformRef" :inline="true" :model="searchform" class="demo-form-inline" size="small">
                <el-form-item>
                  <el-button-group>
                    <el-button type="default" icon="el-icon-refresh" size="small" @click="loadItemsDetailTableData()">刷新</el-button>
                    <el-button
                      v-hasPermi="['ItemsDetail/Add']"
                      type="primary"
                      icon="el-icon-plus"
                      size="small"
                      @click="ShowItemsDetailEditOrViewDialog()"
                    >新增</el-button>
                    <el-button
                      v-hasPermi="['ItemsDetail/Edit']"
                      type="primary"
                      icon="el-icon-edit"
                      class="el-button-modify"
                      size="small"
                      @click="ShowItemsDetailEditOrViewDialog('edit')"
                    >修改</el-button>
                    <el-button
                      v-hasPermi="['ItemsDetail/Enable']"
                      type="info"
                      icon="el-icon-video-pause"
                      size="small"
                      @click="HanderSetItemsDetailEnable('0')"
                    >禁用</el-button>
                    <el-button
                      v-hasPermi="['ItemsDetail/Enable']"
                      type="success"
                      icon="el-icon-video-play"
                      size="small"
                      @click="HanderSetItemsDetailEnable('1')"
                    >启用</el-button>
                    <el-button v-hasPermi="['ItemsDetail/Delete']" type="danger" icon="el-icon-delete" size="small" @click="deleteItemsDetailPhysics()">删除</el-button>
                  </el-button-group>
                </el-form-item>
              </el-form>
            </div>
          </div>

          <el-table
            ref="gridtable"
            :data="tableData"
            style="width: 100%;margin-bottom: 20px;"
            row-key="Id"
            size="mini"
            max-height="850"
            default-expand-all
            highlight-current-row
            :tree-props="{children: 'Children'}"
            @selection-change="handleSelectChange"
          >
            <el-table-column
              type="selection"
              width="55"
            />
            <el-table-column
              prop="ItemName"
              label="名称"
              sortable="custom"
            />
            <el-table-column
              prop="ItemCode"
              label="值"
              sortable="custom"
            />
            <el-table-column
              prop="SortCode"
              label="排序"
              sortable="custom"
              width="80"
              align="center"
            />
            <el-table-column
              label="状态"
              sortable="custom"
              width="80"
              prop="EnabledMark"
              align="center"
            >
              <template #default="scope">
                <el-tag
                  :type="scope.row.EnabledMark === true ? 'success' : 'info'"
                  disable-transitions
                >{{ scope.row.EnabledMark===true?'启用':'禁用' }}</el-tag>
              </template>
            </el-table-column>
          </el-table>
        </el-col>
      </el-row>
    </el-card>
    <el-dialog ref="dialogEditItemsForm" :title="editItemsFormTitle+'字典'" v-model="dialogItemsEditFormVisible" width="30%">
      <el-form ref="editItemsFromRef" :model="editItemsFrom" :rules="rules">
        <el-form-item label="字典名称" :label-width="formLabelWidth" prop="FullName">
          <el-input v-model="editItemsFrom.FullName" placeholder="请输入字典名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="字典编码" :label-width="formLabelWidth" prop="EnCode">
          <el-input v-model="editItemsFrom.EnCode" placeholder="请输入字典编码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="父级" :label-width="formLabelWidth" prop="ParentId">
          <el-cascader
            v-model="selectedItemsOptions"
            :options="selectItemss"
            filterable
            :props="{label:'FullName',value:'Id',children:'Children',emitPath:false, checkStrictly: true,expandTrigger: 'hover' }"
            clearable
            @change="handleItemsChange"
          />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
          <el-input v-model.number="editItemsFrom.SortCode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="属性" :label-width="formLabelWidth" prop="">
          <el-checkbox v-model="editItemsFrom.EnabledMark">启用</el-checkbox>
          <el-checkbox v-model="editItemsFrom.IsTree">是否是树</el-checkbox>
        </el-form-item>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button @click="dialogItemsEditFormVisible = false">取 消</el-button>
          <el-button type="primary" @click="saveEditItemsForm()">确 定</el-button>
        </div>
      </template>
    </el-dialog>

    <el-dialog ref="dialogEditItemsDetailForm" :title="editItemsDetailFormTitle+'功能'" v-model="dialogItemsDetailEditFormVisible" width="30%">
      <el-form ref="editItemsDetailFromRef" :model="editItemsDetailFrom" :rules="rulesfun">
        <el-form-item label="名称" :label-width="formLabelWidth" prop="ItemName">
          <el-input v-model="editItemsDetailFrom.ItemName" placeholder="请输入名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="值" :label-width="formLabelWidth" prop="ItemCode">
          <el-input v-model="editItemsDetailFrom.ItemCode" placeholder="请输入值" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="分类" :label-width="formLabelWidth" prop="ItemId">
          <el-cascader
            v-model="selectedItemsOptions"
            :options="selectItemss"
            filterable
            :props="{label:'FullName',value:'Id',children:'Children',emitPath:false, checkStrictly: true,expandTrigger: 'hover' }"
            clearable
            @change="handleAddItemsDetailChange"
          />
        </el-form-item>
        <el-form-item label="上级功能" :label-width="formLabelWidth" prop="ParentId">
          <el-cascader
            v-model="selectedItemsDetailOptions"
            :options="selectItemsDetails"
            filterable
            :props="{label:'ItemName',value:'Id',children:'Children',emitPath:false, checkStrictly: true,expandTrigger: 'hover' }"
            clearable
            @change="handleAddItemsDetailItemsChange"
          />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
          <el-input v-model.number="editItemsDetailFrom.SortCode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="属性" :label-width="formLabelWidth" prop="">
          <el-checkbox v-model="editItemsDetailFrom.EnabledMark">启用</el-checkbox>
          <el-checkbox v-model="editItemsDetailFrom.IsDefault">默认值</el-checkbox>
        </el-form-item>
      </el-form>
      <template #footer>
      <div class="dialog-footer">
        <el-button @click="dialogItemsDetailEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditItemsDetailForm()">确 定</el-button>
      </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="Items">
import { getAllItemsTreeTable, getItemsDetail, saveItems, setItemsEnable, deleteSoftItems, deleteItems,
  getItemsDetailListWithPager,
  getItemsDetailDetail, saveItemsDetail, setItemsDetailEnable, deleteSoftItemsDetail,
  deleteItemsDetail,
  getAllItemsDetailTreeTable
} from '@/api/security/itemsservice'

import { getListMeunFuntionBymeunCode } from '@/api/basebasic'
const { proxy } = getCurrentInstance()

const tableData=ref([])
const taleloading=ref(true)
const dialogItemsEditFormVisible=ref(false)
const editItemsFormTitle=ref("")
const showSearch = ref(true);
const single = ref(true);
const multiple = ref(true);

const formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])
const selectSystemType=ref([])
const loadItemsBtnFunc=ref([])
const loadItemsDetailBtnFunc=ref([])
const selectItemsId=ref('')
const selectedItemsOptions=ref([])
const selectItemss=ref([])
const currentItemsId=ref('')

const dialogItemsDetailEditFormVisible=ref(false)
const editItemsDetailFormTitle=ref('')
const selectedItemsDetailOptions=ref([])
const selectItemsDetails=ref([])
const tableDataItemss=ref([])
const data = reactive({
  searchform: {
    keywords: '',
    code: ''
  },
  searchmenuform: {
    systemTypeId: ''
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
  editItemsFrom:{},
  rules: {
    FullName: [
      { required: true, message: '请输入名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    EnCode: [
      { required: true, message: '请输入编码', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ]
  },
  editItemsDetailFrom: {},
  rulesfun: {
    ItemName: [
      { required: true, message: '请输入名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    ItemCode: [
      { required: true, message: '请输入值', trigger: 'blur' },
      { min: 1, max: 50, message: '长度在 1 到 50 个字符', trigger: 'blur' }
    ],
    ItemId: [
      { required: true, message: '请选择所属分类', trigger: 'blur' }
    ]
  }
})
const { searchform, searchmenuform,editItemsFrom, rules ,editItemsDetailFrom,rulesfun,pagination,sortableData} = toRefs(data);

/**
 * 初始化数据
 */
function InitDictItem() {
  getListMeunFuntionBymeunCode('ItemsDetail').then(res => {
    loadItemsDetailBtnFunc.value = res.ResData
  })
}
/**
 * 加载页面左侧菜单table数据
 */
function loadTableData() {
  getAllItemsTreeTable().then(res => {
    selectItemss.value = tableDataItemss.value = res.ResData
  })
}
/**
 * 点击查询菜单
 */
function handleSearch() {
  loadTableData()
}
/**
 * 点击查询
 */
function handleSearchItemsDetail() {
  pagination.value.currentPage = 1
  loadItemsDetailTableData()
}

function loadItemsDetailTree() {
  var data = {
    itemId: selectItemsId.value
  }
  getAllItemsDetailTreeTable(data).then(res => {
    selectItemsDetails.value = res.ResData
  })
}
/**
 * 添加添加分类是选择父级分类
 */
function handleItemsChange() {
  if (currentItemsId === selectedItemsOptions) {
    proxy.$modal.alert('不能选择自己作为父级')
    selectedItemsOptions.value = ''
    return
  }
  editItemsFrom.value.ParentId = selectedItemsOptions
}
/**
 * 添加分类值是选择分类
 */
function handleAddItemsDetailChange() {
  selectItemsId.value = selectedItemsOptions.value
  loadItemsDetailTree()
  editItemsDetailFrom.value.ItemId = selectedItemsOptions.value
}
/**
 * 添加分类值时选择父级
 */
function handleAddItemsDetailItemsChange() {
  if (currentId.value === selectedItemsDetailOptions.value) {
    proxy.$modal.alert('不能选择自己作为父级')
    selectedItemsDetailOptions.value = ''
    return
  }
  editItemsDetailFrom.value.ParentId = selectedItemsDetailOptions.value
}
// 表单重置
function reset() {
  editItemsFrom.value = {
    FullName: '',
    EnCode: '',
    ParentId: '',
    IsTree: false,
    EnabledMark: true,
    SortCode: 99
  }
  selectedItemsOptions.value = ''
  proxy.resetForm('editItemsFromRef')
}
/**
 * 新增、修改或查看明细信息（绑定显示数据）*
 */
function ShowItemsEditOrViewDialog(view) {
  reset()
  if (view !== undefined) {
    if (currentItemsId.value === '') {
      proxy.$modal.alert('请选择一条数据进行编辑/修改')
    } else {
      editItemsFormTitle.value = '编辑'
      dialogItemsEditFormVisible.value = true
      bindItemsEditInfo()
    }
  } else {
    editItemsFormTitle.value = '新增'
    currentItemsId.value = ''
    dialogItemsEditFormVisible.value = true
  }
}
function bindItemsEditInfo() {
  getItemsDetail(currentItemsId.value).then(res => {
    editItemsFrom.value = res.ResData
    selectedItemsOptions.value = res.ResData.ParentId
  })
}
/**
 * 新增/修改保存
 */
function saveEditItemsForm() {
  proxy.$refs['editItemsFromRef'].validate((valid) => {
    if (valid) {
      const data = {
        'FullName': editItemsFrom.value.FullName,
        'EnCode': editItemsFrom.value.EnCode,
        'ParentId': editItemsFrom.value.ParentId,
        'IsTree': editItemsFrom.value.IsTree,
        'EnabledMark': editItemsFrom.value.EnabledMark,
        'SortCode': editItemsFrom.value.SortCode,
        'Id': currentItemsId.value
      }
      var url = 'Items/Insert'
      if (currentItemsId.value !== '') {
        url = 'Items/Update'
      }
      saveItems(data, url).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          dialogItemsEditFormVisible.value = false
          currentItemsId.value = ''
          selectedItemsOptions.value = ''
          proxy.$refs['editItemsFromRef'].resetFields()
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
function handerSetItemsEnable(val) {
  if (currentItemsId.value === '') {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    var currentIds = [currentItemsId.value]
    const data = {
      Ids: currentIds,
      Flag: val
    }
    setItemsEnable(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        currentItemsId.value = ''
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function deleteItemsSoft(val) {
  if (currentItemsId.value === '') {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    var currentIds = [currentItemsId.value]
    const data = {
      Ids: currentIds,
      Flag: val
    }
    deleteSoftItems(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        currentItemsId.value = ''
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function deleteItemsPhysics() {
  if (currentItemsId.value === '') {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    var currentIds = [currentItemsId.value]
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: currentIds
      }
      return deleteItems(data)
    }).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        ids.value = ''
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}

// 表单重置
function resetDetails() {
  editItemsDetailFrom.value = {
    ItemName: '',
    ItemCode: '',
    ParentId: '',
    ItemId: '',
    IsDefault: false,
    EnabledMark: true,
    SortCode: 99
  }
  selectedItemsOptions.value = ''
  proxy.resetForm('editItemsDetailFrom')
}
/**
 * 新增、修改或查看明细信息（绑定显示数据）*
 */
function ShowItemsDetailEditOrViewDialog(view) {
  resetDetails()
  if (view !== undefined) {
    if (ids.value.length === 0) {
      proxy.$modal.alert('请选择一条数据进行编辑/修改')
    } else {
      editItemsDetailFormTitle.value = '编辑'
      dialogItemsDetailEditFormVisible.value = true
      currentId.value = ids.value[0]
      bindItemsDetailEditInfo()
    }
  } else {
    editItemsDetailFormTitle.value = '新增'
    currentId.value = ''
    dialogItemsDetailEditFormVisible.value = true
  }
}
function  bindItemsDetailEditInfo() {
  getItemsDetailDetail(currentId.value).then(res => {
    editItemsDetailFrom.value = res.ResData
    editItemsDetailFrom.value.ItemId = res.ResData.ItemId
    selectedItemsOptions.value = res.ResData.ItemId
    selectItemsId.value = res.ResData.ItemId
    loadItemsDetailTree()
  })
}
/**
 * 新增/修改保存
 */
function saveEditItemsDetailForm() {
  proxy.$refs['editItemsDetailFromRef'].validate((valid) => {
    if (valid) {
      const data = {
        'ItemName': editItemsDetailFrom.value.ItemName,
        'ItemCode': editItemsDetailFrom.value.ItemCode,
        'ItemId': editItemsDetailFrom.value.ItemId,
        'ParentId': editItemsDetailFrom.value.ParentId,
        'IsDefault': editItemsDetailFrom.value.IsDefault,
        'EnabledMark': editItemsDetailFrom.value.EnabledMark,
        'SortCode': editItemsDetailFrom.value.SortCode,
        'Id': currentId.value
      }

      var url = 'ItemsDetail/Insert'
      if (currentId.value !== '') {
        url = 'ItemsDetail/Update'
      }
      saveItemsDetail(data, url).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          dialogItemsDetailEditFormVisible.value = false
          selectedItemsOptions.value = ''
          loadItemsDetailTableData()
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
function HanderSetItemsDetailEnable(val) {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    setItemsDetailEnable(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        loadItemsDetailTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function deleteItemsDetailSoft(val) {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    deleteSoftItemsDetail(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        loadItemsDetailTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function deleteItemsDetailPhysics() {
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      const data = {
        Ids: ids.value
      }
      return deleteItemsDetail(data)
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
  loadItemsDetailTableData()
}
//
function handleClickItemsChange(row, column, event) {
  searchform.value.code = row.EnCode
  currentItemsId.value = row.Id
  loadItemsDetailTableData()
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
 * 加载数据字典值列表数据
 */
function loadItemsDetailTableData() {
  taleloading.value = true
  var seachdata = {
    itemId: currentItemsId.value
  }
  getItemsDetailListWithPager(seachdata).then(res => {
    tableData.value = res.ResData
    taleloading.value = false
  })
}
InitDictItem()
loadTableData()
</script>
<style>
.el-cascader{
  width: 100%;
}
</style>
