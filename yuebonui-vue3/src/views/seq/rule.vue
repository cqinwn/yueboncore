<template>
  <div class="app-container">
    <el-form
        ref="searchformRef" v-show="showSearch"
      :inline="true"
      :model="queryParams"
      class="demo-form-inline"
    >
      <el-form-item label="业务单据名称：" prop="Keywords">
        <el-input v-model="queryParams.Keywords" clearable placeholder="业务单据名称" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleSearch()">查询</el-button>
        <el-button icon="Refresh" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>
    <el-row :gutter="10" class="mb8">
      <el-button-group>
        <el-button v-hasPermi="['SequenceRule/Add']" type="primary" icon="plus" @click="ShowEditOrViewDialog()">新增</el-button>
        <el-button v-hasPermi="['SequenceRule/Edit']" type="primary" icon="edit" :disabled="single" class="el-button-modify" @click="ShowEditOrViewDialog('edit')">修改</el-button>
        <el-button v-hasPermi="['SequenceRule/Enable']" type="info" icon="video-pause" :disabled="multiple" @click="setEnable('0')">禁用</el-button>
        <el-button v-hasPermi="['SequenceRule/Enable']" type="success" icon="video-play" :disabled="multiple" @click="setEnable('1')">启用</el-button>
        <el-button v-hasPermi="['SequenceRule/DeleteSoft']" type="warning" icon="delete" :disabled="multiple" @click="deleteSoft('0')">软删除</el-button>
        <el-button v-hasPermi="['SequenceRule/Delete']" type="danger" icon="delete" :disabled="multiple" @click="deletePhysics()">删除</el-button>
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
      :default-sort="{prop: 'SequenceName', order: 'ascending'}"
      @selection-change="handleSelectChange"
      @sort-change="handleSortChange"
    >
      <el-table-column type="selection" width="50" />
      <el-table-column prop="SequenceName" label="业务单据名称" sortable="custom" width="180" />
      <el-table-column prop="RuleOrder" label="排序" width="80" />
      <el-table-column prop="RuleType" label="规则类型" sortable="custom" width="160">
        <template #default="scope">
          <slot v-if="scope.row.RuleType==='const'">常量</slot>
          <slot v-else-if="scope.row.RuleType==='number'">计数</slot>
          <slot v-else-if="scope.row.RuleType==='date'">日期型(yyyyMMdd)</slot>
          <slot v-else-if="scope.row.RuleType==='shortdate'">日期型(yyMMdd)</slot>
          <slot v-else-if="scope.row.RuleType==='ydate'">年月(yyyyMM)</slot>
          <slot v-else-if="scope.row.RuleType==='sydate'">年月(yyMM)</slot>
          <slot v-else-if="scope.row.RuleType==='timestamp'">时间戳</slot>
          <slot v-else-if="scope.row.RuleType==='guid'">Guid</slot>
          <slot v-else-if="scope.row.RuleType==='random'">随机数</slot>
        </template>
      </el-table-column>
      <el-table-column prop="RuleValue" label="规则参数" sortable="custom" width="120" />
      <el-table-column prop="PaddingSide" label="补齐方向" sortable="custom" width="120">
        <template #default="scope">
          <slot v-if="scope.row.PaddingSide==='Left'">向左补齐</slot>
          <slot v-else-if="scope.row.PaddingSide==='Right'">向右补齐</slot>
          <slot v-else>无</slot>
        </template>
      </el-table-column>
      <el-table-column prop="PaddingWidth" label="补齐宽度" sortable="custom" width="120" />
      <el-table-column prop="PaddingChar" label="填充字符" sortable="custom" width="120" />
      <el-table-column prop="Description" label="描述" sortable="custom" width="280" />
      <el-table-column
        label="是否启用"
        sortable="custom"
        width="120"
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
      <el-table-column
        label="是否删除"
        sortable="custom"
        width="120"
        prop="DeleteMark"
        align="center"
      >
        <template #default="scope">
          <el-tag
            :type="scope.row.DeleteMark === true ? 'danger' : 'success'"
            disable-transitions
          >{{ scope.row.DeleteMark===true?'已删除':'否' }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column
        prop="CreatorTime"
        label="创建时间"
        sortable
        width="160"
      />
      <el-table-column
        prop="LastModifyTime"
        label="更新时间"
        sortable
        width="160"
      />
    </el-table>
    <Pagination
          v-show="queryParams.pageTotal>0"
          :total="queryParams.pageTotal"
          v-model:page="queryParams.CurrenetPageIndex"
          v-model:limit="queryParams.PageSize"
        @pagination="loadTableData"
    />
    <el-dialog
      ref="dialogEditForm"
      :title="editFormTitle+'业务单据号规则'"
      v-model="dialogEditFormVisible"
      width="640px"
    >
      <el-form ref="editFromRef" :model="editFrom" :rules="rules">
        <el-form-item label="填写说明" :label-width="formLabelWidth">
          <slot>规则参数值填写规则：规则类型为“常量”时填写一个固定字符串；为“计数”时填计数起始值；为“随机数”时是填最小值的随机数，最大随机数为同位数的“*9”</slot>
        </el-form-item>
        <el-form-item label="单据名称" :label-width="formLabelWidth" prop="SequenceName">
          <el-select v-model="editFrom.SequenceName" clearable placeholder="请输入业务单据名称">
            <el-option
              v-for="item in selectedSequence"
              :key="item.Id"
              :label="item.SequenceName"
              :value="item.SequenceName"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="RuleOrder">
          <el-input v-model="editFrom.RuleOrder" placeholder="请输入排序号" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="规则类型" :label-width="formLabelWidth" prop="RuleType">
          <el-select v-model="editFrom.RuleType" clearable placeholder="请选规则类型">
            <el-option
              v-for="item in selectRuleType"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            />
          </el-select>
        </el-form-item>
        <el-form-item v-if="editFrom.RuleType==='const'||editFrom.RuleType==='number'||editFrom.RuleType==='random'" label="规则参数" :label-width="formLabelWidth" prop="RuleValue">
          <el-input v-model="editFrom.RuleValue" placeholder="请输入规则参数" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item v-if="editFrom.RuleType==='number'" label="补齐方向" :label-width="formLabelWidth" prop="PaddingSide">
          <el-select v-model="editFrom.PaddingSide" clearable placeholder="请选补齐方向">
            <el-option
              v-for="item in selectPaddingSide"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            />
          </el-select>
        </el-form-item>
        <el-form-item v-if="editFrom.RuleType==='number'" label="补齐宽度" :label-width="formLabelWidth" prop="PaddingWidth">
          <el-input v-model="editFrom.PaddingWidth" placeholder="请输入补齐宽度" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item v-if="editFrom.RuleType==='number'" label="填充字符" :label-width="formLabelWidth" prop="PaddingChar">
          <el-input v-model="editFrom.PaddingChar" placeholder="请输入填充字符" maxlength="1" autocomplete="off" clearable />
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
  </div>
</template>

<script setup name="SequenceRule">

import { getSequenceRuleListWithPager, getSequenceRuleDetail,
  saveSequenceRule, setSequenceRuleEnable, deleteSoftSequenceRule,
  deleteSequenceRule } from '@/api/security/sequencerule'
import { getAllSequenceList } from '@/api/security/sequence'

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
const selectedSequence=ref("")

const data = reactive({
  queryParams:{
    CurrenetPageIndex: 1,
    PageSize: 20,
    pageTotal: 0,
    Order: 'desc',
    Sort: 'SequenceName',
    Keywords: ''
  },
  editFrom:{},
  rules: {
    SequenceName: [
      { required: true, message: '请选择业务单据名称', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    RuleType: [
      { required: true, message: '请选择规则类型', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ]
  },
  selectRuleType: [{
    value: 'const',
    label: '常量'
  }, {
    value: 'number',
    label: '计数'
  }, {
    value: 'date',
    label: '日期型(yyyyMMdd)'
  }, {
    value: 'shortdate',
    label: '日期型(yyMMdd)'
  }, {
    value: 'ydate',
    label: '年月(yyyyMM)'
  }, {
    value: 'sydate',
    label: '年月(yyMM)'
  }, {
    value: 'timestamp',
    label: '时间戳'
  }, {
    value: 'guid',
    label: 'Guid'
  }, {
    value: 'random',
    label: '随机数'
  }
  ],
  selectPaddingSide: [{
    value: 'Left',
    label: '向左补齐'
  }, {
    value: 'Right',
    label: '向右补齐'
  }, {
    value: 'None',
    label: '无'
  }
  ]
})
const { queryParams, editFrom, rules ,selectRuleType,selectPaddingSide} = toRefs(data);

/**
 * 初始化数据
 */
function InitDictItem() {
  getAllSequenceList().then(res => {
    selectedSequence.value = res.ResData
  })
}
/**
 * 加载页面table数据
 */
function loadTableData(){
  tableloading.value = true
  getSequenceRuleListWithPager(queryParams.value).then(res => {
    tableData.value = res.ResData.Items
    queryParams.value.pageTotal = res.ResData.TotalItems
    tableloading.value = false
  })
}
/**
 * 点击查询
 */
function handleSearch(){
  queryParams.value.CurrenetPageIndex = 1
  loadTableData()
}
/** 重置查询操作 */
function resetQuery() {
  proxy.resetForm("searchformRef");
  handleSearch();
}
// 表单重置
function reset(){
  editFrom.value= {
    SequenceName: '',
    RuleOrder: 1,
    RuleType: 'date',
    RuleValue: '',
    PaddingSide: 'None',
    PaddingWidth: 0,
    PaddingChar: '',
    Description: '',
    EnabledMark: true
  }
  proxy.resetForm('editFrom')
}
/**
 * 新增、修改或查看明细信息（绑定显示数据）     *
 */
function ShowEditOrViewDialog(view) {
  reset()
  if (view !== undefined) {
    if (ids.value.length > 1 || ids.value.length === 0) {
      $alert('请选择一条数据进行编辑/修改', '提示')
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
  getSequenceRuleDetail(currentId.value).then(res => {
    editFrom.value = res.ResData
  })
}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      saveSequenceRule(editFrom.value).then(res => {
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
  if (ids.value.length === 0) {
    proxy.$modal.alert('请先选择要操作的数据')
    return false
  } else {
    const data = {
      Ids: ids.value,
      Flag: val
    }
    setSequenceRuleEnable(data).then(res => {
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
    deleteSoftSequenceRule(data).then(res => {
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
      return deleteSequenceRule(data)
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
    queryParams.Order = 'asc'
  } else {
    queryParams.Order = 'desc'
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
InitDictItem()
loadTableData()
</script>

<style>
</style>
