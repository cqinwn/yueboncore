<template>
  <div class="app-container">
    <el-card>
      <el-row :gutter="20">
        <el-col :span="7">
          <div class="grid-content bg-purple">
            <div class="grid-content bg-purple">
              <div class="list-btn-container">
                <el-form ref="searchmenuform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
                  <el-form-item>
                    <el-button-group>
                      <el-button type="default" icon="el-icon-refresh" size="mini" @click="loadTableData()">刷新</el-button>
                      <slot v-for="itemf in loadItemsBtnFunc">
                        <el-button v-if="itemf.FullName==='新增'" type="primary" icon="el-icon-plus" size="mini" @click="ShowItemsEditOrViewDialog()">新增</el-button>
                        <el-button v-if="itemf.FullName==='修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="mini" @click="ShowItemsEditOrViewDialog('edit')">修改</el-button>
                        <el-button v-if="itemf.FullName=='禁用'" type="info" icon="el-icon-video-pause" size="mini" @click="setItemsEnable('0')">禁用</el-button>
                        <el-button v-if="itemf.FullName=='启用'" type="success" icon="el-icon-video-play" size="mini" @click="setItemsEnable('1')">启用</el-button>
                        <el-button v-if="itemf.FullName==='删除'" type="danger" icon="el-icon-delete" size="mini" @click="deleteItemsPhysics()">删除</el-button>
                      </slot>
                    </el-button-group>
                  </el-form-item>
                </el-form>
              </div>
              <el-table
                :data="tableDataItemss"
                style="width: 100%;margin-bottom: 20px;"
                row-key="Id"
                border
                size="mini"
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
                  <template slot-scope="scope">
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
        <el-col :span="17">
          <div class="grid-content bg-purple">
            <div class="list-btn-container">
              <el-form ref="searchform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
                <el-form-item>
                  <el-button-group>
                    <el-button type="default" icon="el-icon-refresh" size="mini" @click="loadItemsDetailTableData()">刷新</el-button>
                    <slot v-for="itemf in loadItemsDetailBtnFunc">
                      <el-button v-if="itemf.FullName==='新增'" type="primary" icon="el-icon-plus" size="mini" @click="ShowItemsDetailEditOrViewDialog()">新增</el-button>
                      <el-button v-if="itemf.FullName==='修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="mini" @click="ShowItemsDetailEditOrViewDialog('edit')">修改</el-button>
                      <el-button v-if="itemf.FullName=='禁用'" type="info" icon="el-icon-video-pause" size="mini" @click="setItemsDetailEnable('0')">禁用</el-button>
                      <el-button v-if="itemf.FullName=='启用'" type="success" icon="el-icon-video-play" size="mini" @click="setItemsDetailEnable('1')">启用</el-button>
                      <el-button v-if="itemf.FullName==='删除'" type="danger" icon="el-icon-delete" size="mini" @click="deleteItemsDetailPhysics()">删除</el-button>
                    </slot>
                  </el-button-group>
                </el-form-item>
              </el-form>
            </div>
          </div>

          <el-table
            ref="gridtable"
            v-loading="tableloading"
            :data="tableData"
            style="width: 100%;margin-bottom: 20px;"
            row-key="Id"
            border
            size="mini"
            max-height="850"
            default-expand-all
            highlight-current-row
            :tree-props="{children: 'Children'}"
            @select="handleSelectChange"
            @select-all="handleSelectAllChange"
          >
            <el-table-column
              type="selection"
              width="30"
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
              <template slot-scope="scope">
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
    <el-dialog ref="dialogEditItemsForm" :title="editItemsFormTitle+'字典'" :visible.sync="dialogItemsEditFormVisible" width="30%">
      <el-form ref="editItemsFrom" :model="editItemsFrom" :rules="rules">
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
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogItemsEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditItemsForm()">确 定</el-button>
      </div>
    </el-dialog>

    <el-dialog ref="dialogEditItemsDetailForm" :title="editItemsDetailFormTitle+'功能'" :visible.sync="dialogItemsDetailEditFormVisible" width="30%">
      <el-form ref="editItemsDetailFrom" :model="editItemsDetailFrom" :rules="rulesfun">
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
          <el-checkbox v-model="editItemsFrom.EnabledMark">启用</el-checkbox>
          <el-checkbox v-model="editItemsFrom.IsDefault">默认值</el-checkbox>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogItemsDetailEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditItemsDetailForm()">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import { getAllItemsTreeTable, getItemsDetail, saveItems, setItemsEnable, deleteSoftItems, deleteItems,
  getItemsDetailListWithPager,
  getItemsDetailDetail, saveItemsDetail, setItemsDetailEnable, deleteSoftItemsDetail,
  deleteItemsDetail,
  getAllItemsDetailTreeTable
} from '@/api/security/itemsservice'

import { getListMeunFuntionBymeunCode } from '@/api/basebasic'
export default {
  data () {
    return {
      searchform: {
        keywords: '',
        code: ''
      },
      searchmenuform: {
        systemTypeId: ''
      },
      selectSystemType: [],
      loadItemsBtnFunc: [],
      loadItemsDetailBtnFunc: [],
      tableData: [],
      tableloading: true,
      pagination: {
        currentPage: 1,
        pagesize: 20,
        pageTotal: 0
      },
      sortableData: {
        order: '',
        sort: ''
      },
      selectItemsId: '',
      dialogItemsEditFormVisible: false,
      editItemsFormTitle: '',
      selectedItemsOptions: [],
      selectItemss: [],
      editItemsFrom: {
        FullName: '',
        EnCode: '',
        ParentId: '',
        IsTree: true,
        EnabledMark: true,
        SortCode: 99
      },
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
      formLabelWidth: '80px',
      currentItemsId: '',

      dialogItemsDetailEditFormVisible: false,
      editItemsDetailFormTitle: '',
      selectedItemsDetailOptions: [],
      selectItemsDetails: [],
      editItemsDetailFrom: {
        ItemName: '',
        ItemCode: '',
        ParentId: '',
        ItemId: '',
        IsDefault: true,
        EnabledMark: true,
        SortCode: 99
      },
      rulesfun: {
        ItemName: [
          { required: true, message: '请输入名称', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        ItemCode: [
          { required: true, message: '请输入值', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        ItemId: [
          { required: true, message: '请选择所属分类', trigger: 'blur' }
        ]
      },
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: [],
      tableDataItemss: []
    }
  },
  created () {
    this.pagination.currentPage = 1
    this.InitDictItem()
    this.loadTableData()
    this.loadItemsBtnFunc = JSON.parse(localStorage.getItem('yueboncurrentfuns'))
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem () {
      getListMeunFuntionBymeunCode('ItemsDetail/List').then(res => {
        this.loadItemsDetailBtnFunc = res.ResData
      })
    },
    /**
     * 加载页面左侧菜单table数据
     */
    loadTableData: function () {
      getAllItemsTreeTable().then(res => {
        this.selectItemss = this.tableDataItemss = res.ResData
      })
    },
    /**
     * 点击查询菜单
     */
    handleSearch: function () {
      this.loadTableData()
    },
    /**
     * 点击查询
     */
    handleSearchItemsDetail: function () {
      this.pagination.currentPage = 1
      this.loadItemsDetailTableData()
    },

    loadItemsDetailTree () {
      var data = {
        itemId: this.selectItemsId
      }
      getAllItemsDetailTreeTable(data).then(res => {
        this.selectItemsDetails = res.ResData
      })
    },
    /**
     * 添加添加分类是选择父级分类
     */
    handleItemsChange: function () {
      console.log(this.selectedItemsOptions)
      if (this.currentItemsId === this.selectedItemsOptions) {
        this.$alert('不能选择自己作为父级', '提示')
        this.selectedItemsOptions = ''
        return
      }
      this.editItemsFrom.ParentId = this.selectedItemsOptions
    },
    /**
     * 添加分类值是选择分类
     */
    handleAddItemsDetailChange: function () {
      console.log(this.selectedItemsOptions)
      this.selectItemsId = this.selectedItemsOptions
      this.loadItemsDetailTree()
      this.editItemsDetailFrom.ItemId = this.selectedItemsOptions
    },
    /**
     * 添加分类值时选择父级
     */
    handleAddItemsDetailItemsChange: function () {
      console.log(this.selectedItemsDetailOptions)
      if (this.currentId === this.selectedItemsDetailOptions) {
        this.$alert('不能选择自己作为父级', '提示')
        this.selectedItemsDetailOptions = ''
        return
      }
      console.log('selectedItemsDetailOptions:' + this.selectedItemsDetailOptions)
      this.editItemsDetailFrom.ParentId = this.selectedItemsDetailOptions
    },
    /**
     * 新增、修改或查看明细信息（绑定显示数据）*
     */
    ShowItemsEditOrViewDialog: function (view) {
      if (view !== undefined) {
        if (this.currentItemsId === '') {
          this.$alert('请选择一条数据进行编辑/修改', '提示')
        } else {
          this.editItemsFormTitle = '编辑'
          this.dialogItemsEditFormVisible = true
          this.bindItemsEditInfo()
        }
      } else {
        this.editItemsFormTitle = '新增'
        this.currentItemsId = ''
        this.dialogItemsEditFormVisible = true
      }
    },
    bindItemsEditInfo: function () {
      getItemsDetail(this.currentItemsId).then(res => {
        this.editItemsFrom.FullName = res.ResData.FullName
        this.editItemsFrom.EnCode = res.ResData.EnCode
        this.editItemsFrom.EnabledMark = res.ResData.EnabledMark
        this.editItemsFrom.SortCode = parseInt(res.ResData.SortCode)
        this.editItemsFrom.IsTree = res.ResData.IsTree
        this.editItemsFrom.ParentId = res.ResData.ParentId
        this.selectedItemsOptions = res.ResData.ParentId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditItemsForm () {
      this.$refs['editItemsFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'FullName': this.editItemsFrom.FullName,
            'EnCode': this.editItemsFrom.EnCode,
            'ParentId': this.editItemsFrom.ParentId,
            'IsTree': this.editItemsFrom.IsTree,
            'EnabledMark': this.editItemsFrom.EnabledMark,
            'SortCode': this.editItemsFrom.SortCode,
            'Id': this.currentItemsId
          }
          var url = 'Items/Insert'
          if (this.currentItemsId !== '') {
            url = 'Items/Update?id=' + this.currentItemsId
          }
          saveItems(data, url).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogItemsEditFormVisible = false
              this.currentItemsId = ''
              this.selectedItemsOptions = []
              this.$refs['editItemsFrom'].resetFields()
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
    setItemsEnable: function (val) {
      if (this.currentItemsId === '') {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        const data = {
          ids: this.currentItemsId,
          bltag: val
        }
        setItemsEnable(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentItemsId = ''
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
    deleteItemsSoft: function (val) {
      if (this.currentItemsId === '') {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        const data = {
          ids: this.currentItemsId,
          bltag: val
        }
        deleteSoftItems(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentItemsId = ''
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
    deleteItemsPhysics: function () {
      if (this.currentItemsId === '') {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        const data = {
          ids: this.currentItemsId
        }
        deleteItems(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentItemsId = ''
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
     * 新增、修改或查看明细信息（绑定显示数据）*
     */
    ShowItemsDetailEditOrViewDialog: function (view) {
      if (view !== undefined) {
        if (this.currentSelected.length === 0) {
          this.$alert('请选择一条数据进行编辑/修改', '提示')
        } else {
          this.editItemsDetailFormTitle = '编辑'
          this.dialogItemsDetailEditFormVisible = true
          this.currentId = this.currentSelected[0].Id
          this.bindItemsDetailEditInfo()
        }
      } else {
        this.editItemsDetailFormTitle = '新增'
        this.currentId = ''
        this.dialogItemsDetailEditFormVisible = true
      }
    },
    bindItemsDetailEditInfo: function () {
      getItemsDetailDetail(this.currentId).then(res => {
        this.editItemsDetailFrom.ItemName = res.ResData.ItemName
        this.editItemsDetailFrom.ItemCode = res.ResData.ItemCode
        this.editItemsDetailFrom.IsDefault = res.ResData.IsDefault
        this.editItemsDetailFrom.EnabledMark = res.ResData.EnabledMark
        this.editItemsDetailFrom.SortCode = parseInt(res.ResData.SortCode)
        this.editItemsDetailFrom.ParentId = res.ResData.ParentId
        this.selectItemsId = res.ResData.ItemId
        this.selectedItemsDetailOptions = res.ResData.ParentId
        this.loadItemsDetailTree()
        this.editItemsDetailFrom.ItemId = res.ResData.ItemId
        this.selectedItemsOptions = res.ResData.ItemId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditItemsDetailForm () {
      this.$refs['editItemsDetailFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'ItemName': this.editItemsDetailFrom.ItemName,
            'ItemCode': this.editItemsDetailFrom.ItemCode,
            'ItemId': this.editItemsDetailFrom.ItemId,
            'ParentId': this.editItemsDetailFrom.ParentId,
            'IsDefault': this.editItemsDetailFrom.IsDefault,
            'EnabledMark': this.editItemsDetailFrom.EnabledMark,
            'SortCode': this.editItemsDetailFrom.SortCode,
            'Id': this.currentId
          }

          var url = 'ItemsDetail/Insert'
          if (this.currentId !== '') {
            url = 'ItemsDetail/Update?id=' + this.currentId
          }
          saveItemsDetail(data, url).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogItemsDetailEditFormVisible = false
              this.currentSelected = ''
              this.$refs['editItemsDetailFrom'].resetFields()
              this.loadItemsDetailTableData()
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
    setItemsDetailEnable: function (val) {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = ''
        this.currentSelected.forEach(element => {
          currentIds += element.Id + ','
        })
        const data = {
          ids: currentIds,
          bltag: val
        }
        setItemsDetailEnable(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadItemsDetailTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    deleteItemsDetailSoft: function (val) {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = ''
        this.currentSelected.forEach(element => {
          currentIds += element.Id + ','
        })
        const data = {
          ids: currentIds,
          bltag: val
        }
        deleteSoftItemsDetail(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadItemsDetailTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    deleteItemsDetailPhysics: function () {
      if (this.currentSelected.length === 0) {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = ''
        this.currentSelected.forEach(element => {
          currentIds += element.Id + ','
        })
        const data = {
          ids: currentIds
        }
        deleteItemsDetail(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadItemsDetailTableData()
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
      this.loadItemsDetailTableData()
    },
    //
    handleClickItemsChange: function (row, column, event) {
      this.searchform.code = row.EnCode
      this.currentItemsId = row.Id
      this.loadItemsDetailTableData()
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
     * 加载页面table数据
     */
    loadItemsDetailTableData: function () {
      this.tableloading = true
      var seachdata = {
        itemId: this.currentItemsId
      }
      getItemsDetailListWithPager(seachdata).then(res => {
        this.tableData = res.ResData
        this.tableloading = false
      })
    }

  }
}
</script>
<style>
.el-cascader{
  width: 100%;
}
</style>
