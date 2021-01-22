<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form ref="searchform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
          <el-form-item label="角色名称：">
            <el-input v-model="searchform.name" clearable placeholder="角色名称或编码" />
          </el-form-item>
          <el-form-item>
            <el-button type="primary" @click="handleSearch()">查询</el-button>
          </el-form-item>
        </el-form>
      </el-card>
    </div>
    <el-card>
      <div class="list-btn-container">
        <el-button-group>
          <el-button
            v-hasPermi="['Role/Add']"
            type="primary"
            icon="el-icon-plus"
            size="small"
            @click="ShowEditOrViewDialog()"
          >新增</el-button>
          <el-button
            v-hasPermi="['Role/Edit']"
            type="primary"
            icon="el-icon-edit"
            class="el-button-modify"
            size="small"
            @click="ShowEditOrViewDialog('edit')"
          >修改</el-button>
          <el-button
            v-hasPermi="['Role/Enable']"
            type="info"
            icon="el-icon-video-pause"
            size="small"
            @click="setEnable('0')"
          >禁用</el-button>
          <el-button
            v-hasPermi="['Role/Enable']"
            type="success"
            icon="el-icon-video-play"
            size="small"
            @click="setEnable('1')"
          >启用</el-button>
          <el-button
            v-hasPermi="['Role/DeleteSoft']"
            type="warning"
            icon="el-icon-delete"
            size="small"
            @click="deleteSoft('0')"
          >软删除</el-button>
          <el-button
            v-hasPermi="['Role/Delete']"
            type="danger"
            icon="el-icon-delete"
            size="small"
            @click="deletePhysics()"
          >删除</el-button>
          <el-button
            v-hasPermi="['Role/SetAuthorize']"
            type="default"
            icon="el-icon-s-custom"
            size="small"
            @click="handleSetAuth()"
          >分配权限</el-button>
          <el-button type="default" icon="el-icon-refresh" size="small" @click="loadTableData()">刷新</el-button>
        </el-button-group>
      </div>
      <el-table ref="gridtable" v-loading="tableloading" :data="tableData" border stripe highlight-current-row style="width: 100%" :default-sort="{ prop: 'SortCode', order: 'descending' }" @select="handleSelectChange" @select-all="handleSelectAllChange" @sort-change="handleSortChange">
        <el-table-column type="selection" width="30" />
        <el-table-column prop="FullName" label="角色名称" sortable="custom" width="180" />
        <el-table-column prop="EnCode" label="角色编码" sortable="custom" width="180" />
        <el-table-column prop="Type" label="类型" sortable="custom" width="90" align="center">
          <template slot-scope="scope">
            <slot v-if="scope.row.Type === '1'">系统角色</slot>
            <slot v-else-if="scope.row.Type === '2'">业务角色</slot>
            <slot v-else-if="scope.row.Type === '3'">其他角色</slot>
          </template>
        </el-table-column>
        <el-table-column prop="OrganizeName" label="所属组织" sortable="custom" />
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
      <div class="pagination-container">
        <el-pagination background :current-page="pagination.currentPage" :page-sizes="[5, 10, 20, 50, 100, 200, 300, 400]" :page-size="pagination.pagesize" layout="total, sizes, prev, pager, next, jumper" :total="pagination.pageTotal" @size-change="handleSizeChange" @current-change="handleCurrentChange" />
      </div>
    </el-card>
    <el-dialog ref="dialogEditForm" v-el-drag-dialog :title="editFormTitle + '角色'" :visible.sync="dialogEditFormVisible" width="640px">
      <el-form ref="editFrom" :inline="true" :model="editFrom" :rules="rules" class="demo-form-inline">
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
            <el-radio label="true">是</el-radio>
            <el-radio label="false">否</el-radio>
          </el-radio-group>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditForm()">确 定</el-button>
      </div>
    </el-dialog>

    <el-dialog ref="dialogSetAuthForm" v-el-drag-dialog title="分配权限" :visible.sync="dialogSetAuthFormVisible" width="70%">
      <el-tabs v-model="ActionName" type="border-card" @tab-click="handleClick">
        <el-tab-pane label="可用系统" name="treeSystem">
          <el-card class="box-card">
            <el-tree ref="treeSystem" :data="treeSystemData" :check-strictly="true" empty-text="加载中，请稍后" show-checkbox default-expand-all node-key="Id" highlight-current :props="{ label: 'FullName', children: 'Children' }" />
          </el-card>
        </el-tab-pane>
        <el-tab-pane label="功能菜单" name="treeFunction">
          <el-card class="box-card">
            <el-tree ref="treeFunction" :data="treeFuntionData" :check-strictly="true" empty-text="加载中，请稍后" show-checkbox default-expand-all node-key="Id" highlight-current :props="{ label: 'FullName', children: 'Children',disabled:'IsShow'}" />
          </el-card>
        </el-tab-pane>
        <el-tab-pane label="数据权限" name="treeOrganize">
          <el-card class="box-card">
            <el-tree ref="treeOrganize" :data="treeOrganizeData" :check-strictly="true" empty-text="加载中，请稍后" show-checkbox default-expand-all node-key="Id" highlight-current :props="{ label: 'FullName', children: 'Children' }" />
          </el-card>
        </el-tab-pane>
      </el-tabs>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogSetAuthFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveRoleAuthorize()">保 存</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>

import { getListItemDetailsByCode } from '@/api/basebasic'
import {
  getRoleListWithPager, getRoleDetail, saveRole,
  setRoleEnable, deleteSoftRole, deleteRole, getRoleAuthorizeFunction,
  getAllFunctionTree, getAllRoleDataByRoleId, saveRoleAuthorize
} from '@/api/security/roleservice'

import { getAllOrganizeTreeTable } from '@/api/security/organizeservice'
import { getAllSystemTypeList } from '@/api/developers/systemtypeservice'
import { Loading } from 'element-ui'
import elDragDialog from '@/directive/el-drag-dialog' // base on element-ui
export default {
  name: 'Role',
  directives: { elDragDialog },
  data () {
    return {
      searchform: {
        name: ''
      },
      loadBtnFunc: [],
      selectedOrganizeOptions: '',
      selectOrganize: [],
      selectRoleType: [],
      tableData: [],
      tableloading: true,
      pagination: {
        currentPage: 1,
        pagesize: 20,
        pageTotal: 0
      },
      sortableData: {
        order: 'desc',
        sort: 'SortCode'
      },
      dialogEditFormVisible: false,
      editFormTitle: '',
      editFrom: {
        FullName: '',
        EnCode: '',
        RoleType: '',
        OrganizeId: '',
        SortCode: 99,
        EnabledMark: 'true',
        Description: ''
      },
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
      },
      formLabelWidth: '80px',
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: [],
      pageLoading: '',
      dialogSetAuthFormVisible: false,
      treeFuntionData: [],
      default_select: [],
      defaultOrganize_select: [],
      treeOrganizeData: [],
      defaultSystem_select: [],
      treeSystemData: [],
      cascaderKey: 0,
      ActionName: 'treeSystem'
    }
  },
  created () {
    this.pagination.currentPage = 1
    this.InitDictItem()
    this.loadTableData()
    this.loadBtnFunc = JSON.parse(localStorage.getItem('yueboncurrentfuns'))
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem () {
      getListItemDetailsByCode('RoleType').then(res => {
        this.selectRoleType = res.ResData
      })

      getAllOrganizeTreeTable().then(res => {
        ++this.cascaderKey
        this.selectOrganize = res.ResData
      })

      getAllFunctionTree().then(res => {
        this.treeFuntionData = res.ResData
      })
      getAllOrganizeTreeTable().then(res => {
        this.treeOrganizeData = res.ResData
      })
      getAllSystemTypeList().then(res => {
        this.treeSystemData = res.ResData
      })
    },
    /**
     * 加载页面table数据
     */
    loadTableData: function () {
      this.tableloading = true
      var seachdata = {
        CurrenetPageIndex: this.pagination.currentPage,
        PageSize: this.pagination.pagesize,
        Keywords: this.searchform.name,
        Order: this.sortableData.order,
        Sort: this.sortableData.sort
      }
      getRoleListWithPager(seachdata).then(res => {
        this.tableData = res.ResData.Items
        this.pagination.pageTotal = res.ResData.TotalItems
        this.tableloading = false
      })
    },
    /**
     * 点击查询
     */
    handleSearch: function () {
      this.pagination.currentPage = 1
      this.loadTableData()
    },

    /**
     *选择组织
     */
    handleSelectOrganizeChange: function () {
      console.log(this.selectedOrganizeOptions)
      this.editFrom.OrganizeId = this.selectedOrganizeOptions
    },
    /**
     * 新增、修改或查看明细信息（绑定显示数据）     *
     */
    ShowEditOrViewDialog: function (view) {
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
    bindEditInfo: function () {
      getRoleDetail(this.currentId).then(res => {
        this.editFrom.FullName = res.ResData.FullName
        this.editFrom.EnCode = res.ResData.EnCode
        this.editFrom.OrganizeId = res.ResData.OrganizeId
        this.editFrom.SortCode = res.ResData.SortCode
        this.editFrom.EnabledMark = res.ResData.EnabledMark + ''
        this.editFrom.RoleType = res.ResData.Type
        this.editFrom.Description = res.ResData.Description
        this.selectedOrganizeOptions = res.ResData.OrganizeId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm () {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          var loadop = {
            lock: true,
            text: '正在保存数据，请耐心等待...',
            spinner: 'el-icon-loading',
            background: 'rgba(0, 0, 0, 0.7)'
          }
          this.pageLoading = Loading.service(loadop)
          const data = {
            'OrganizeId': this.editFrom.OrganizeId,
            'EnCode': this.editFrom.EnCode,
            'FullName': this.editFrom.FullName,
            'Type': this.editFrom.RoleType,
            'SortCode': this.editFrom.SortCode,
            'EnabledMark': this.editFrom.EnabledMark,
            'Description': this.editFrom.Description,
            'Id': this.currentId
          }
          var url = 'Role/Insert'
          if (this.currentId !== '') {
            url = 'Role/Update?id=' + this.currentId
          }
          saveRole(data, url).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogEditFormVisible = false
              this.currentSelected = ''
              this.$refs['editFrom'].resetFields()
              this.loadTableData()
              this.InitDictItem()
            } else {
              this.$message({
                message: res.ErrMsg,
                type: 'error'
              })
            }
            this.pageLoading.close()
          })
        } else {
          return false
        }
      })
    },
    setEnable: function (val) {
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
        setRoleEnable(data).then(res => {
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
    deleteSoft: function (val) {
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
        deleteSoftRole(data).then(res => {
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
    deletePhysics: function () {
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
        }).then(function () {
          const data = {
            Ids: currentIds
          }
          return deleteRole(data)
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
    handleSortChange: function (column) {
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
    handleSelectChange: function (selection, row) {
      this.currentSelected = selection
    },
    /**
     * 当用户手动勾选全选checkbox事件
     */
    handleSelectAllChange: function (selection) {
      this.currentSelected = selection
    },
    /**
     * 选择每页显示数量
     */
    handleSizeChange (val) {
      this.pagination.pagesize = val
      this.pagination.currentPage = 1
      this.loadTableData()
    },
    /**
     * 选择当页面
     */
    handleCurrentChange (val) {
      this.pagination.currentPage = val
      this.loadTableData()
    },
    /**
     * 设置权限
     */
    handleSetAuth: function () {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        this.currentId = this.currentSelected[0].Id
        this.dialogSetAuthFormVisible = true

        this.ActionName = 'treeSystem'
        this.default_select = []
        this.defaultOrganize_select = []
        this.defaultSystem_select = []

        const datar = {
          roleId: this.currentId
        }
        getAllRoleDataByRoleId(datar).then(res => {
          this.defaultOrganize_select = res.ResData
          setTimeout(this.restFrom(), 500)
        })

        const data = {
          roleId: this.currentId,
          itemType: '1,2'
        }
        getRoleAuthorizeFunction(data).then(res => {
          this.default_select = res.ResData
          setTimeout(this.restFrom(), 500)
        })

        const datas = {
          roleId: this.currentId,
          itemType: '0'
        }
        getRoleAuthorizeFunction(datas).then(res => {
          this.defaultSystem_select = res.ResData
          setTimeout(this.restFrom(), 500)
        })
      }
    },
    handleClick: function () {
      // this.restFrom()
    },
    // 重置
    restFrom: function () {
      var that = this
      this.$nextTick(() => {
        this.$refs.treeFunction.setCheckedKeys(that.default_select)
        this.$refs.treeSystem.setCheckedKeys(that.defaultSystem_select)
        this.$refs.treeOrganize.setCheckedKeys(that.defaultOrganize_select)
      })
    },
    /**
     * 保存权限
     */
    saveRoleAuthorize: function () {
      var loadop = {
        lock: true,
        text: '正在保存数据，请耐心等待...',
        spinner: 'el-icon-loading',
        background: 'rgba(0, 0, 0, 0.7)'
      }
      this.pageLoading = Loading.service(loadop)
      // 目前被选中的菜单节点
      const checkedKeysTreeFunction = this.$refs.treeFunction.getCheckedKeys()
      // 半选中的菜单节点
      const halfCheckedKeysTreeFunction = this.$refs.treeFunction.getHalfCheckedKeys()
      checkedKeysTreeFunction.unshift.apply(checkedKeysTreeFunction, halfCheckedKeysTreeFunction)

      const checkedKeysTreeOrganize = this.$refs.treeOrganize.getCheckedKeys()
      const halfCheckedKeysTreeOrganize = this.$refs.treeOrganize.getHalfCheckedKeys()
      checkedKeysTreeOrganize.unshift.apply(checkedKeysTreeOrganize, halfCheckedKeysTreeOrganize)

      const checkedKeysTreeSystem = this.$refs.treeSystem.getCheckedKeys()
      const halfCheckedKeysTreeSystem = this.$refs.treeSystem.getHalfCheckedKeys()
      checkedKeysTreeSystem.unshift.apply(checkedKeysTreeSystem, halfCheckedKeysTreeSystem)

      var data = {
        'RoleFunctios': checkedKeysTreeFunction,
        'RoleData': checkedKeysTreeOrganize,
        'RoleSystem': checkedKeysTreeSystem,
        'RoleId': this.currentId
      }
      saveRoleAuthorize(data).then(res => {
        if (res.Success) {
          this.$message({
            message: '恭喜你，操作成功',
            type: 'success'
          })
          this.currentSelected = ''
          // this.default_select = []
          // this.defaultOrganize_select = []
          // this.defaultSystem_select = []
          this.dialogSetAuthFormVisible = false
        } else {
          this.$message({
            message: res.ErrMsg,
            type: 'error'
          })
        }
        this.pageLoading.close()
      })
    }
  }
}
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
