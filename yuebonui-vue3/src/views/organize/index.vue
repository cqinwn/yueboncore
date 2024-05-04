<template>
  <div class="app-container">
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button
          v-hasPermi="['Organize/Add']"
          type="primary"
          icon="plus"
          @click="ShowEditOrViewDialog()"
        >新增</el-button>
        <el-button
          v-hasPermi="['Organize/Edit']"
          type="primary"
          icon="edit"
          class="el-button-modify"
          :disabled="single"
          @click="ShowEditOrViewDialog('edit')"
        >修改</el-button>
        <el-button
          v-hasPermi="['Organize/Enable']"
          type="info"
          icon="video-pause"
          :disabled="multiple"
          @click="setEnable('0')"
        >禁用</el-button>
        <el-button
          v-hasPermi="['Organize/Enable']"
          type="success"
          icon="video-play"
          :disabled="multiple"
          @click="setEnable('1')"
        >启用</el-button>
        <el-button
          v-hasPermi="['Organize/DeleteSoft']"
          type="warning"
          icon="delete"
          :disabled="multiple"
          @click="deleteSoft('0')"
        >软删除</el-button>
        <el-button
          v-hasPermi="['Organize/Delete']"
          type="danger"
          icon="delete"
          :disabled="multiple"
          @click="deletePhysics()"
        >删除</el-button>
        <el-button type="default" icon="refresh" @click="loadTableData()">刷新</el-button>
      </el-button-group>
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
      :tree-props="{ children: 'Child' }"
      @selection-change="handleSelectChange"
    >
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column prop="FullName" label="组织名称" sortable="custom" width="380" />
      <el-table-column prop="OrgType" label="组织类型" sortable="custom" width="120" align="center">
          <template v-slot= "scope">
            <slot v-if="scope.row.OrgType === 'BusinessOrg'">业务组织</slot>
            <slot v-if="scope.row.OrgType === 'SysOrg'">系统组织</slot>
            <slot v-if="scope.row.OrgType === 'ThreeOrg'">第三方组织</slot>
          </template>
        </el-table-column>
      <el-table-column prop="CategoryId" label="组织分类" sortable="custom" width="120" align="center">
        <template v-slot= "scope">
          <slot v-if="scope.row.CategoryId === 'Group'">集团</slot>
          <slot v-if="scope.row.CategoryId === 'Area'">区域</slot>
          <slot v-if="scope.row.CategoryId === 'Company'">公司</slot>
          <slot v-else-if="scope.row.CategoryId === 'SubCompany'">子公司</slot>
          <slot v-else-if="scope.row.CategoryId === 'Department'">部门</slot>
          <slot v-else-if="scope.row.CategoryId === 'SubDepartment'">子部门</slot>
          <slot v-else-if="scope.row.CategoryId === 'WorkGroup'">工作组</slot>
        </template>
      </el-table-column>
      <el-table-column prop="ManagerId" label="负责人" sortable="custom" width="90" />
      <el-table-column prop="TelePhone" label="电话" sortable="custom" width="130" />
      <el-table-column prop="MobilePhone" label="手机" sortable="custom" width="130" />
      <el-table-column label="是否启用" sortable="custom" width="120" prop="EnabledMark" align="center">
        <template v-slot="scope">
          <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{ scope.row.EnabledMark === true ? "启用" : "禁用" }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="是否删除" sortable="custom" width="120" prop="DeleteMark" align="center">
        <template v-slot="scope">
          <el-tag :type="scope.row.DeleteMark === true ? 'danger' : 'success'" disable-transitions>{{ scope.row.DeleteMark === true ? "已删除" : "否" }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="CreatorTime" label="创建时间" sortable width="170"/>
      <el-table-column prop="LastModifyTime" label="更新时间" sortable width="170"/>
    </el-table>
    <el-dialog ref="dialogEditForm" draggable :title="editFormTitle + '组织'" v-model="dialogEditFormVisible">
      <el-form ref="editFromRef" :inline="true" :model="editFrom" :rules="rules"  class="demo-form-inline">
        <el-form-item label="上级组织" :label-width="formLabelWidth" prop="ParentId">
          <el-cascader
            v-model="selectedOrganizeOptions"
            style="width: 500px"
            :options="selectOrganize"
            filterable
            :props="{
              label: 'FullName',
              value: 'Id',
              children: 'Child',
              emitPath: false,
              checkStrictly: true,
              expandTrigger: 'hover',
            }"
            clearable
            @change="handleSelectOrganizeChange"
          />
        </el-form-item>
        <el-form-item label="名称" :label-width="formLabelWidth" prop="FullName">
          <el-input v-model="editFrom.FullName" style="width: 500px" placeholder="请输入机构名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="分类" :label-width="formLabelWidth" prop="OrgType">
          <el-select v-model="editFrom.OrgType" clearable placeholder="请选类型">
            <el-option v-for="item in selectOrganizeType" :key="item.Id" :label="item.ItemName" :value="item.ItemCode" />
          </el-select>
        </el-form-item>
        <el-form-item label="类型" :label-width="formLabelWidth" prop="CategoryId">
          <el-select v-model="editFrom.CategoryId" clearable placeholder="请选分类">
            <el-option v-for="item in selectOrganizeCategorize" :key="item.Id" :label="item.ItemName" :value="item.ItemCode" />
          </el-select>
        </el-form-item>
        <el-form-item label="简称" :label-width="formLabelWidth" prop="ShortName">
          <el-input v-model="editFrom.ShortName" placeholder="请输入简称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="负责人" :label-width="formLabelWidth" prop="ManagerId">
          <el-input v-model="editFrom.ManagerId" placeholder="请输入负责人" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="手机" :label-width="formLabelWidth" prop="MobilePhone">
          <el-input v-model="editFrom.MobilePhone" placeholder="请输入手机" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="座机电话" :label-width="formLabelWidth" prop="TelePhone">
          <el-input v-model="editFrom.TelePhone" placeholder="请输入电话" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="微信号" :label-width="formLabelWidth" prop="WeChat">
          <el-input v-model="editFrom.WeChat" placeholder="请输入微信" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="Email" :label-width="formLabelWidth" prop="Email">
          <el-input v-model="editFrom.Email" placeholder="请输入Email" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="传真" :label-width="formLabelWidth" prop="Fax">
          <el-input v-model="editFrom.Fax" placeholder="请输入传真" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
          <el-input v-model.number="editFrom.SortCode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="选项" :label-width="formLabelWidth" prop="">
          <el-checkbox v-model="editFrom.EnabledMark">启用</el-checkbox>
          <el-checkbox v-model="editFrom.DeleteMark">删除</el-checkbox>
        </el-form-item>
        <el-form-item label="地址" :label-width="formLabelWidth" prop="Address">
          <el-input v-model="editFrom.Address" style="width: 500px" placeholder="请输入地址" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="描述" :label-width="formLabelWidth" prop="Description">
          <el-input v-model="editFrom.Description" style="width: 500px" autocomplete="off" clearable />
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

<script setup name="Organize">
import { getListItemDetailsByCode } from '@/api/basebasic'
import { getAllOrganizeTreeTable, getOrganizeDetail, saveOrganize, setOrganizeEnable, deleteSoftOrganize, deleteOrganize
} from '@/api/security/organizeservice'

const { proxy } = getCurrentInstance()

const tableData=ref([])
const tableloading=ref(true)
const dialogEditFormVisible=ref(false)
const editFormTitle=ref("")
const single = ref(true)
const multiple = ref(true)
      
let formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const ids=ref([])

const selectedOrganizeOptions=ref('')
let selectOrganize=ref([])
const selectOrganizeType = ref([])
const selectOrganizeCategorize = ref([])


const data = reactive({
  editFrom: {
    FullName: '',
    EnCode: '',
    ParentId: '',
    ShortName: '',
    OrgType:'',
    CategoryId: '',
    ManagerId: '',
    TelePhone: '',
    MobilePhone: '',
    WeChat: '',
    Fax: '',
    Email: '',
    Address: '',
    AllowEdit: true,
    AllowDelete: true,
    SortCode: 99,
    EnabledMark: true,
    DeleteMark: false,
    Description: ''
  },
  rules: {
    FullName: [
      { required: true, message: '请输入名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    OrgType: [
      { required: true, message: '请选择类型', trigger: 'blur' }
    ],
    CategoryId: [
      { required: true, message: '请选择分类', trigger: 'blur' }
    ]
  }
})

const { editFrom, rules} = toRefs(data);
/**
 * 初始化数据
 */
function InitDictItem() {
  getListItemDetailsByCode('OrgType').then(res => {
    selectOrganizeType.value = res.ResData
  })
  getListItemDetailsByCode('OrganizeCategory').then(res => {
    selectOrganizeCategorize.value = res.ResData
  })
}
/**
 * 加载页面table数据
 */
function loadTableData() {
  tableloading.value = true
  getAllOrganizeTreeTable().then(res => {
    tableData.value = res.ResData
    selectOrganize.value = res.ResData
    tableloading.value = false
  })
}

/**
 *选择组织
  */
function handleSelectOrganizeChange() {
  if (currentId.value === selectedOrganizeOptions.value) {
    proxy.$modal.alert('不能选择自己作为父级')
    selectedOrganizeOptions.value = ''
    return
  }
  editFrom.value.ParentId = selectedOrganizeOptions.value
}
// 表单重置
function reset() {
  editFrom.value = {
    FullName: '',
    EnCode: '',
    ParentId: '',
    ShortName: '',
    CategoryId: '',
    ManagerId: '',
    TelePhone: '',
    MobilePhone: '',
    WeChat: '',
    Fax: '',
    Email: '',
    Address: '',
    AllowEdit: true,
    AllowDelete: true,
    SortCode: 99,
    EnabledMark: true,
    DeleteMark: false,
    Description: ''
  }
  selectedOrganizeOptions.value = ''
  proxy.resetForm('editFromRef')
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
    reset()
  }
}

function bindEditInfo() {
  getOrganizeDetail(currentId.value).then(res => {
    editFrom.value = res.ResData
    selectedOrganizeOptions.value = res.ResData.ParentId
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      var url = 'Organize/Insert'
      if (currentId.value !== '') {
        url = 'Organize/Update'
      }
      saveOrganize(editFrom.value, url).then(res => {
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
    setOrganizeEnable(data).then(res => {
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
    deleteSoftOrganize(data).then(res => {
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
      return deleteOrganize(data)
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
