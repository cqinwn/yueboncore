<template>
  <div class="app-container">
    <el-card>
      <div class="list-btn-container">
        <el-button-group>
          <el-button
            v-hasPermi="['Organize/Add']"
            type="primary"
            icon="el-icon-plus"
            size="small"
            @click="ShowEditOrViewDialog()"
          >新增</el-button>
          <el-button
            v-hasPermi="['Organize/Edit']"
            type="primary"
            icon="el-icon-edit"
            class="el-button-modify"
            size="small"
            @click="ShowEditOrViewDialog('edit')"
          >修改</el-button>
          <el-button
            v-hasPermi="['Organize/Enable']"
            type="info"
            icon="el-icon-video-pause"
            size="small"
            @click="setEnable('0')"
          >禁用</el-button>
          <el-button
            v-hasPermi="['Organize/Enable']"
            type="success"
            icon="el-icon-video-play"
            size="small"
            @click="setEnable('1')"
          >启用</el-button>
          <el-button
            v-hasPermi="['Organize/DeleteSoft']"
            type="warning"
            icon="el-icon-delete"
            size="small"
            @click="deleteSoft('0')"
          >软删除</el-button>
          <el-button
            v-hasPermi="['Organize/Delete']"
            type="danger"
            icon="el-icon-delete"
            size="small"
            @click="deletePhysics()"
          >删除</el-button>
          <el-button type="default" icon="el-icon-refresh" size="small" @click="loadTableData()">刷新</el-button>
        </el-button-group>
      </div>
      <el-table
        ref="gridtable"
        v-loading="tableloading"
        :data="tableData"
        row-key="Id"
        border
        stripe
        highlight-current-row
        style="width: 100%"
        default-expand-all
        :tree-props="{ children: 'Children' }"
        @select="handleSelectChange"
        @select-all="handleSelectAllChange"
        @sort-change="handleSortChange"
      >
        <el-table-column type="selection" width="30" />
        <el-table-column prop="FullName" label="组织名称" sortable="custom" width="380" />
        <el-table-column prop="EnCode" label="编码" sortable="custom" width="180" />
        <el-table-column prop="CategoryId" label="类型" sortable="custom" width="90" align="center">
          <template slot-scope="scope">
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
        <el-table-column prop="TelePhone" label="电话" sortable="custom" width="120" />
        <el-table-column prop="MobilePhone" label="手机" sortable="custom" width="120" />
        <el-table-column label="是否启用" sortable="custom" width="120" prop="EnabledMark" align="center">
          <template slot-scope="scope">
            <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{ scope.row.EnabledMark === true ? "启用" : "禁用" }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column label="是否删除" sortable="custom" width="120" prop="DeleteMark" align="center">
          <template slot-scope="scope">
            <el-tag :type="scope.row.DeleteMark === true ? 'danger' : 'success'" disable-transitions>{{ scope.row.DeleteMark === true ? "已删除" : "否" }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column prop="CreatorTime" label="创建时间" sortable />
        <el-table-column prop="LastModifyTime" label="更新时间" sortable />
      </el-table>
    </el-card>
    <el-dialog ref="dialogEditForm" v-el-drag-dialog :title="editFormTitle + '组织'" :visible.sync="dialogEditFormVisible" width="660px">
      <el-form ref="editFrom" :inline="true" :model="editFrom" :rules="rules" class="demo-form-inline">
        <el-form-item label="上级组织" :label-width="formLabelWidth" prop="ParentId">
          <el-cascader
            v-model="selectedOrganizeOptions"
            style="width: 500px"
            :options="selectOrganize"
            filterable
            :props="{label: 'FullName',
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
        <el-form-item label="名称" :label-width="formLabelWidth" prop="FullName">
          <el-input v-model="editFrom.FullName" style="width: 500px" placeholder="请输入机构名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="编码" :label-width="formLabelWidth" prop="EnCode">
          <el-input v-model="editFrom.EnCode" placeholder="请输入机构编码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="类型" :label-width="formLabelWidth" prop="CategoryId">
          <el-select v-model="editFrom.CategoryId" clearable placeholder="请选类型">
            <el-option v-for="item in selectOrganizeType" :key="item.Id" :label="item.ItemName" :value="item.ItemCode" />
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
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditForm()">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>

import { getListItemDetailsByCode } from '@/api/basebasic'
import {
  getAllOrganizeTreeTable, getOrganizeDetail, saveOrganize,
  setOrganizeEnable, deleteSoftOrganize, deleteOrganize
} from '@/api/security/organizeservice'

import elDragDialog from '@/directive/el-drag-dialog' // base on element-ui
export default {
  name: 'Organize',
  directives: { elDragDialog },
  data() {
    return {
      loadBtnFunc: [],
      selectedOrganizeOptions: '',
      selectOrganize: [],
      selectOrganizeType: [],
      tableData: [],
      tableloading: true,
      dialogEditFormVisible: false,
      editFormTitle: '',
      editFrom: {},
      rules: {
        FullName: [
          { required: true, message: '请输入名称', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        CategoryId: [
          { required: true, message: '请选择类型', trigger: 'blur' }
        ]
      },
      formLabelWidth: '80px',
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: []
    }
  },
  created() {
    this.InitDictItem()
    this.loadTableData()
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem() {
      getListItemDetailsByCode('OrganizeCategory').then(res => {
        this.selectOrganizeType = res.ResData
      })
    },
    /**
     * 加载页面table数据
     */
    loadTableData: function() {
      this.tableloading = true
      getAllOrganizeTreeTable().then(res => {
        this.tableData = res.ResData
        this.selectOrganize = res.ResData
        this.tableloading = false
      })
    },

    /**
     *选择组织
     */
    handleSelectOrganizeChange: function() {
      this.editFrom.ParentId = this.selectedOrganizeOptions
    },
    // 表单重置
    reset() {
      this.editFrom = {
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
      this.selectedOrganizeOptions = ''
      this.resetForm('editFrom')
    },
    /**
     * 新增、修改或查看明细信息（绑定显示数据）     *
     */
    ShowEditOrViewDialog: function(view) {
      this.reset()
      if (view !== undefined) {
        if (this.currentSelected.length > 1 || this.currentSelected.length === 0) {
          this.$alert('请选择一条数据进行编辑/修改', '提示')
        } else {
          this.currentId = this.currentSelected[0].Id
          this.editFormTitle = '编辑'
          this.dialogEditFormVisible = true
          this.bindEditInfo()
        }
      } else {
        this.editFormTitle = '新增'
        this.currentId = ''
        this.dialogEditFormVisible = true
      }
    },
    bindEditInfo: function() {
      getOrganizeDetail(this.currentId).then(res => {
        this.editFrom = res.ResData
        this.selectedOrganizeOptions = res.ResData.ParentId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm() {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'ParentId': this.editFrom.ParentId,
            'EnCode': this.editFrom.EnCode,
            'FullName': this.editFrom.FullName,
            'ShortName': this.editFrom.ShortName,
            'CategoryId': this.editFrom.CategoryId,
            'ManagerId': this.editFrom.ManagerId,
            'TelePhone': this.editFrom.TelePhone,
            'MobilePhone': this.editFrom.MobilePhone,
            'WeChat': this.editFrom.WeChat,
            'Fax': this.editFrom.Fax,
            'Email': this.editFrom.Email,
            'Address': this.editFrom.Address,
            'AllowEdit': this.editFrom.AllowEdit,
            'AllowDelete': this.editFrom.AllowDelete,
            'DeleteMark': this.editFrom.DeleteMark,
            'SortCode': this.editFrom.SortCode,
            'EnabledMark': this.editFrom.EnabledMark,
            'Description': this.editFrom.Description,
            'Id': this.currentId
          }
          var url = 'Organize/Insert'
          if (this.currentId !== '') {
            url = 'Organize/Update'
          }
          saveOrganize(data, url).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogEditFormVisible = false
              this.currentSelected = ''
              this.loadTableData()
              this.InitDictItem()
            } else {
              this.$message({
                message: res.ErrMsg,
                type: 'error'
              })
            }
          })
        } else {
          return false
        }
      })
    },
    setEnable: function(val) {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = []
        this.currentSelected.forEach(element => {
          currentIds.push(element.Id)
        })
        const data = {
          Ids: currentIds,
          Flag: val
        }
        setOrganizeEnable(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    deleteSoft: function(val) {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = []
        this.currentSelected.forEach(element => {
          currentIds.push(element.Id)
        })
        const data = {
          Ids: currentIds,
          Flag: val
        }
        deleteSoftOrganize(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    deletePhysics: function() {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = []
        this.currentSelected.forEach(element => {
          currentIds.push(element.Id)
        })
        this.$confirm('是否确认删除所选的数据项?', '警告', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).then(function() {
          const data = {
            Ids: currentIds
          }
          return deleteOrganize(data)
        }).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，删除成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    /**
     * 当表格的排序条件发生变化的时候会触发该事件
     */
    handleSortChange: function(column) {
      this.sortableData.sort = column.prop
      if (column.order === 'ascending') {
        this.sortableData.order = 'asc'
      } else {
        this.sortableData.order = 'desc'
      }
      this.loadTableData()
    },
    /**
     * 当用户手动勾选checkbox数据行事件
     */
    handleSelectChange: function(selection, row) {
      this.currentSelected = selection
    },
    /**
     * 当用户手动勾选全选checkbox事件
     */
    handleSelectAllChange: function(selection) {
      this.currentSelected = selection
    }
  }
}
</script>
