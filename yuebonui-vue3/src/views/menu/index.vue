<template>
  <div class="app-container">
    <el-form ref="searchformRef" v-show="showSearch" :inline="true" :model="searchform" class="demo-form-inline">
      <el-form-item label="系统名称：" prop="systemTypeId">
        <el-select v-model="searchform.systemTypeId" style="width:150px" clearable placeholder="请选择">
          <el-option
            v-for="item in selectSystemType"
            :key="item.Id"
            :label="item.FullName"
            :value="item.Id"
          />
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['Menu/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
        <el-button v-hasPermi="['Menu/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify" @click="ShowEditOrViewDialog('edit')">修改</el-button>
        <el-button v-hasPermi="['Menu/Enable']" type="info" icon="video-pause" :disabled="single" @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['Menu/Enable']" type="success" icon="video-play" :disabled="single" @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['Menu/DeleteSoft']" type="warning" icon="delete" :disabled="single" @click="deleteSoft('0')">软删除</el-button>
        <el-button v-hasPermi="['Menu/Delete']" type="danger" icon="delete" :disabled="single" @click="deletePhysics()">删除</el-button>
      </el-button-group>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="loadTableData"></right-toolbar>
    </el-row>
    <el-table
      :data="tableDataMenus"
      style="width: 100%;margin-bottom: 20px;"
      row-key="Id"
      max-height="850"
      default-expand-all
      highlight-current-row
      :tree-props="{children: 'Children'}"
      @selection-change="handleSelectChange"
      @row-click="handleClickMenuChange"
    >
      <el-table-column
        prop="FullName"
        label="菜单/模块名称"
        width="220"
      >
        <template #default="scope">
          <svg-icon v-if="scope.row.Icon" :icon-class="scope.row.Icon" />{{ scope.row.FullName }}
        </template>
      </el-table-column>
      <el-table-column
        prop="EnCode"
        label="功能编码"
        width="268"
      />
      <el-table-column
        prop="UrlAddress"
        label="路由地址"
        width="280"
      />
      <el-table-column
        prop="Component"
        label="组件地址"
        width="180"
      />
      <el-table-column
        label="类型"
        width="120"
        prop="MenuType"
        align="center"
      >
        <template #default="scope">
          <slot v-if="scope.row.MenuType==='C'" disable-transitions>模块/目录</slot>
          <slot v-if="scope.row.MenuType==='M'" disable-transitions>菜单</slot>
          <slot v-if="scope.row.MenuType==='F'" disable-transitions>功能/按钮</slot>
        </template>
      </el-table-column>
      <el-table-column
        prop="SortCode"
        label="排序"
        width="80"
      />
      <el-table-column
        label="显示"
        width="80"
        prop="IsShow"
        align="center"
      >
        <template #default="scope">
          <el-tag
            :type="scope.row.IsShow === true ? 'success' : 'info'"
            disable-transitions
          >{{ scope.row.IsShow===true?'显示':'隐藏' }}</el-tag>
        </template>
      </el-table-column>
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

    <!-- 添加或修改菜单对话框 -->
    <el-dialog ref="dialogEditMenuForm" draggable :title="editMenuFormTitle+'模块/菜单'" append-to-body v-model="dialogEditFormVisible" width="40%">
      <el-form ref="editMenuFromRef" :model="editMenuFrom" :rules="rules">
        <el-row>
          <el-col :span="12">
            <el-form-item label="所属系统" :label-width="formLabelWidth" prop="SystemTypeId">
              <el-select
                v-model="selectSystemTypeId"
                clearable
                placeholder="请选择"
                @change="handleSystemTypeChange"
              >
                <el-option
                  v-for="item in selectSystemType"
                  :key="item.Id"
                  :label="item.FullName"
                  :value="item.Id"
                />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="父级模块" :label-width="formLabelWidth" prop="ParentId">
              <el-cascader
                :key="cascaderKey"
                v-model="selectedMenuOptions"
                :options="selectMenus"
                filterable
                :props="{label:'FullName',value:'Id',children:'Children',emitPath:false, checkStrictly: true,expandTrigger: 'hover' }"
                clearable
                @change="handleMenuChange"
              />
            </el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item label="所属类型" :label-width="formLabelWidth" prop="MenuType">
              <el-radio-group v-model="editMenuFrom.MenuType" @change="menuTypeChange">
                <el-radio label="C">模块/目录</el-radio>
                <el-radio label="M">菜单</el-radio>
                <el-radio label="F">功能/按钮</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item :label="formShowTitle+'名称'" :label-width="formLabelWidth" prop="FullName">
              <el-input v-model="editMenuFrom.FullName" :placeholder="'请输入'+formShowTitle+'名称'" autocomplete="off" clearable />
            </el-form-item>
          </el-col>

          <el-col :span="12">
            <el-form-item :label="formShowTitle+'编码'" :label-width="formLabelWidth" prop="EnCode">
              <el-input v-model="editMenuFrom.EnCode" :placeholder="'请输入'+formShowTitle+'编码'" autocomplete="off" clearable />
            </el-form-item>
          </el-col>

          <el-col v-if="editMenuFrom.MenuType != 'F'" :span="12">
            <el-form-item label="是否外链" :label-width="formLabelWidth" prop="IsFrame">
              <el-radio-group v-model="editMenuFrom.IsFrame">
                <el-radio :label="true">是</el-radio>
                <el-radio :label="false">否</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col v-if="editMenuFrom.MenuType != 'F'" :span="12">
            <el-form-item label="路由地址" :label-width="formLabelWidth" prop="UrlAddress">
              <el-input v-model="editMenuFrom.UrlAddress" placeholder="请输入路由地址" autocomplete="off" clearable />
            </el-form-item>
          </el-col>

          <el-col v-if="editMenuFrom.MenuType == 'M'" :span="12">
            <el-form-item label="组件路径" :label-width="formLabelWidth" prop="Component">
              <el-input v-model="editMenuFrom.Component" placeholder="请输入组件路径" autocomplete="off" clearable />
            </el-form-item>
          </el-col>

          <el-col v-if="editMenuFrom.MenuType == 'M' && !editMenuFrom.IsShow" :span="12">
            <el-form-item label="选中菜单" :label-width="formLabelWidth" prop="ActiveMenu">
              <el-input v-model="editMenuFrom.ActiveMenu" placeholder="请输入选中菜单路由地址" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="图标" :label-width="formLabelWidth" prop="Icon">
              <el-popover
                placement="bottom-start"
                :width="540"
                v-model:visible="showChooseIcon"
                trigger="click"
                @show="showSelectIcon"
              >
                <template #reference>
                    <el-input v-model="editMenuFrom.Icon" placeholder="点击选择图标" @click="showSelectIcon" readonly>
                      <template #prefix>
                          <svg-icon
                            v-if="editMenuFrom.Icon"
                            :icon-class="editMenuFrom.Icon"
                            class="el-input__icon"
                            style="height: 32px;width: 16px;"
                          />
                          <el-icon v-else style="height: 32px;width: 16px;"><search /></el-icon>
                      </template>
                    </el-input>
                </template>
                <icon-select ref="iconSelectRef" @selected="selected" />
              </el-popover>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
              <el-input v-model.number="editMenuFrom.SortCode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="是否显示" :label-width="formLabelWidth" prop="IsShow">
              <el-radio-group v-model="editMenuFrom.IsShow">
                <el-radio :label="true">显示</el-radio>
                <el-radio :label="false">隐藏</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="状态" :label-width="formLabelWidth" prop="EnabledMark">
              <el-radio-group v-model="editMenuFrom.EnabledMark">
                <el-radio :label="true">可用</el-radio>
                <el-radio :label="false">停用</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col v-if="editMenuFrom.MenuType == 'F'" :span="12">
            <el-form-item label="是否缓存" :label-width="formLabelWidth" prop="IsCache">
              <el-radio-group v-model="editMenuFrom.IsCache">
                <el-radio :label="true">是</el-radio>
                <el-radio :label="false">否</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="是否公共" :label-width="formLabelWidth" prop="IsPublic">
              <el-radio-group v-model="editMenuFrom.IsPublic">
                <el-radio :label="true">是</el-radio>
                <el-radio :label="false">否</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col v-if="editMenuFrom.MenuType == 'F' && currentMenuId===''" :span="12">
            <el-form-item label="批量新增" :label-width="formLabelWidth" prop="IsBatch">
              <el-radio-group v-model="editMenuFrom.IsBatch">
                <el-radio :label="true">是</el-radio>
                <el-radio :label="false">否</el-radio>
              </el-radio-group>
              <el-link disabled>批量添加菜单下的功能按钮</el-link>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button @click="dialogEditFormVisible = false">取 消</el-button>
          <el-button type="primary" @click="saveEditMenuForm()">确 定</el-button>
        </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="Menu">
import { getSubSystemList } from '@/api/basebasic'
import { getAllMenuTreeTable, getMenuDetail, saveMenu, setMenuEnable, deleteSoftMenu, deleteMenu } from '@/api/developers/menufunction'

import IconSelect from '@/components/IconSelect'

const { proxy } = getCurrentInstance();

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

const formShowTitle=ref("模块")
const currentMenuId=ref("")
const selectSystemType=ref([])
const selectSystemTypeId=ref("")
const editMenuFormTitle=ref("")
const selectedMenuOptions=ref("")
const selectMenus=ref([])
const tableDataMenus=ref([])
const cascaderKey=ref(0)

const showChooseIcon = ref(false);
const iconSelectRef = ref(null);

const data = reactive({
  searchform: {
    keywords: '',
    code: '',
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
  editMenuFrom:{},
  rules: {
    FullName: [
      { required: true, message: '请输入模块名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    EnCode: [
      { required: true, message: '请输入模块编码', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    SystemTypeId: [
      { required: true, message: '请选择所属系统', trigger: 'blur' }
    ],
    UrlAddress: [
      { required: true, message: '请选填写路由', trigger: 'blur' }
    ]
  }
})
const { searchform, editMenuFrom, rules ,pagination,sortableData} = toRefs(data);

/**
 * 初始化数据
 */
function InitDictItem() {
  getSubSystemList().then(res => {
    selectSystemType.value = res.ResData
  })
}
function menuTypeChange() {
  let mty = editMenuFrom.value.MenuType
  if (mty === 'M') {
    formShowTitle.value = '菜单'
  } else if (mty === 'F') {
    formShowTitle.value = '功能'
    editMenuFrom.value.Component = ''
  } else if (mty === 'C') {
    formShowTitle.value = '模块'
    editMenuFrom.value.Component = ''
  }
}

/** 展示下拉图标 */
function showSelectIcon() {
  iconSelectRef.value.reset();
  showChooseIcon.value = true;
}
/** 选择图标 */
function selected(name) {
  editMenuFrom.value.Icon = name;
  showChooseIcon.value = false;
}
/** 关闭弹窗隐藏图标选择 */
function handleClose() {
  cancel();
  showChooseIcon.value = false;
}
// 取消按钮
function cancel() {
  dialogEditFormVisible.value = false
  reset()
}
// 表单重置
function reset() {
  editMenuFrom.value = {
    FullName: '',
    EnCode: '',
    ParentId: 0,
    SystemTypeId: 0,
    Icon: undefined,
    UrlAddress: '',
    Component: '',
    ActiveMenu: '',
    EnabledMark: true,
    MenuType: 'C',
    IsPublic: false,
    IsShow: true,
    IsFrame: false,
    SortCode: 99,
    IsBatch: false,
    IsCache: false
  }
  selectedMenuOptions.value = ""
  selectSystemTypeId.value = ""
  proxy.resetForm('editMenuFromRef')
}
/**
 * 加载页面左侧菜单table数据
 */
function loadTableData() {
  var sysId=searchform.value.systemTypeId==''?0:searchform.value.systemTypeId
  getAllMenuTreeTable(sysId).then(res => {
    tableDataMenus.value = res.ResData
  })
}
/**
 * 点击查询菜单
 */
function handleSearch() {
  loadTableData()
}
/** 重置查询操作 */
function resetQuery() {
  proxy.resetForm("searchformRef");
  handleSearch();
}
function handleSelectChange(selection) {
  ids.value = selection.map(item => item.Id);
  single.value = selection.length != 1;
  multiple.value = !selection.length;
}
function handleClickMenuChange(row, column, event) {
  searchform.value.code = row.EnCode
  currentMenuId.value = row.Id
  single.value=false
}

/**
 * 菜单选择子系统
 */
function handleSystemTypeChange() {
  ++cascaderKey.value
  getAllMenuTreeTable(selectSystemTypeId.value).then(res => {
    selectMenus.value = res.ResData
  })
  editMenuFrom.value.SystemTypeId = selectSystemTypeId.value
}
/**
 * 添加模块式选择菜单
 */
function handleMenuChange() {
  if (currentMenuId.value === selectedMenuOptions.value) {
    proxy.$modal.alert('不能选择自己作为父级')
    selectedMenuOptions.value = ''
    return
  }
  editMenuFrom.value.ParentId = selectedMenuOptions.value
}
/**
 * 新增、修改或查看明细信息（绑定显示数据）*
 */
function ShowEditOrViewDialog(view) {
  reset()
  if (view !== undefined) {
    if (currentMenuId.value === '') {
      proxy.$modal.alert('请选择一条数据进行编辑/修改')
    } else {
      editMenuFormTitle.value = '编辑'
      dialogEditFormVisible.value = true
      bindMenuEditInfo()
    }
  } else {
    editMenuFormTitle.value = '新增'
    currentMenuId.value = ''
    dialogEditFormVisible.value = true
  }
}
function bindMenuEditInfo() {
  getMenuDetail(currentMenuId.value).then(res => {
    editMenuFrom.value = res.ResData
    selectSystemTypeId.value = res.ResData.SystemTypeId
    selectedMenuOptions.value= res.ResData.ParentId
    handleSystemTypeChange()
    editMenuFrom.value.IsBatch = false
    let mty = editMenuFrom.value.MenuType
    if (mty === 'M') {
      formShowTitle.value = '菜单'
    } else if (mty === 'F') {
      formShowTitle.value = '功能'
    } else if (mty === 'C') {
      formShowTitle.value = '模块'
    }
  })
}
/**
 * 新增/修改保存
 */
function saveEditMenuForm() {
  proxy.$refs['editMenuFromRef'].validate((valid) => {
    if (valid) {
      var url = 'Menu/Insert'
      if (currentMenuId.value !== '') {
        url = 'Menu/Update'
      }
      saveMenu(editMenuFrom.value, url).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          dialogEditFormVisible.value = false
          currentMenuId.value = ''
          selectedMenuOptions.value = ""
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
  if (currentMenuId.value === '') {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    var currentIds = [currentMenuId.value]
    const data = {
      Ids: currentIds,
      Flag: val
    }
    setMenuEnable(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        currentMenuId.value = ''
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function deleteSoft(val) {
  if (currentMenuId.value === '') {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    var currentIds = [currentMenuId.value]
    const data = {
      Ids: currentIds,
      Flag: val
    }
    deleteSoftMenu(data).then(res => {
      if (res.Success) {
        proxy.$modal.msgSuccess('恭喜你，操作成功')
        currentMenuId.value = ''
        loadTableData()
      } else {
        proxy.$modal.msgError(res.ErrMsg)
      }
    })
  }
}
function deletePhysics() {
  if (currentMenuId.value === '') {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    proxy.$modal.confirm('是否确认删除所选的数据项?').then(function() {
      var currentIds = [currentMenuId.value]
      const data = {
        Ids: currentIds,
      }
      return deleteMenu(data)
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
InitDictItem()
loadTableData()
</script>
<style lang="scss" scoped>
.el-cascader{
  width: 100%;
}
</style>
