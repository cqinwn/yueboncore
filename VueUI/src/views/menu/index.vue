<template>
  <div class="app-container">
    <el-card>
      <el-row :gutter="20">
        <el-col :span="24">
          <div class="grid-content bg-purple">
            <div class="grid-content bg-purple">
              <div class="list-btn-container">
                <el-form ref="searchmenuform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
                  <el-form-item>
                    <el-button-group>
                      <el-button type="default" icon="el-icon-refresh" size="mini" @click="loadTableData()">刷新</el-button>
                      <slot v-for="itemf in loadBtnFunc">
                        <el-button v-if="itemf.EnCode==='Menu/Add'" type="primary" icon="el-icon-plus" size="mini" @click="ShowMenuEditOrViewDialog()">新增</el-button>
                        <el-button v-if="itemf.EnCode==='Menu/Edit'" type="primary" icon="el-icon-edit" class="el-button-modify" size="mini" @click="ShowMenuEditOrViewDialog('edit')">修改</el-button>
                        <el-button v-if="itemf.FullName=='禁用'" type="info" icon="el-icon-video-pause" size="mini" @click="setMenuEnable('0')">禁用</el-button>
                        <el-button v-if="itemf.FullName=='启用'" type="success" icon="el-icon-video-play" size="mini" @click="setMenuEnable('1')">启用</el-button>
                        <el-button v-if="itemf.EnCode==='Menu/Delete'" type="danger" icon="el-icon-delete" size="mini" @click="deleteMenuPhysics()">删除</el-button>
                      </slot>
                    </el-button-group>
                  </el-form-item>
                  <el-form-item label="系统名称：">
                    <el-select v-model="searchmenuform.systemTypeId" style="width:150px" clearable placeholder="请选择">
                      <el-option
                        v-for="item in selectSystemType"
                        :key="item.Id"
                        :label="item.FullName"
                        :value="item.Id"
                      />
                    </el-select>
                  </el-form-item>
                  <el-form-item>
                    <el-button type="primary" size="mini" @click="handleSearch()">查询</el-button>
                  </el-form-item>
                </el-form>
              </div>
              <el-table
                :data="tableDataMenus"
                style="width: 100%;margin-bottom: 20px;"
                row-key="Id"
                border
                size="mini"
                max-height="850"
                default-expand-all
                highlight-current-row
                :tree-props="{children: 'Children'}"
                @row-click="handleClickMenuChange"
              >
                <el-table-column
                  prop="FullName"
                  label="菜单/模块名称"
                  width="220"
                >
                  <template slot-scope="scope">
                    <i
                      :class="['iconfont ',scope.row.Icon]"
                    />{{ scope.row.FullName }}
                  </template>
                </el-table-column>
                <el-table-column
                  prop="EnCode"
                  label="功能编码"
                  width="180"
                />
                <el-table-column
                  prop="UrlAddress"
                  label="路由地址"
                  width="180"
                />
                <el-table-column
                  prop="Component"
                  label="组件地址"
                  width="180"
                />
                <el-table-column
                  label="类型"
                  width="80"
                  prop="MenuType"
                  align="center"
                >
                  <template slot-scope="scope">
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
                  <template slot-scope="scope">
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
      </el-row>
    </el-card>
    <el-dialog ref="dialogEditMenuForm" :title="editMenuFormTitle+'模块/菜单'" :visible.sync="dialogMenuEditFormVisible" width="40%">
      <el-form ref="editMenuFrom" :model="editMenuFrom" :rules="rules">
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
                <el-radio label="true">是</el-radio>
                <el-radio label="false">否</el-radio>
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

          <el-col :span="12">
            <el-form-item label="图标" :label-width="formLabelWidth" prop="Icon">
              <el-input v-model="editMenuFrom.Icon" placeholder="请填写icon图标值" autocomplete="off" clearable />
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
                <el-radio label="true">显示</el-radio>
                <el-radio label="false">隐藏</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="状态" :label-width="formLabelWidth" prop="EnabledMark">
              <el-radio-group v-model="editMenuFrom.EnabledMark">
                <el-radio label="true">可用</el-radio>
                <el-radio label="false">停用</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col v-if="editMenuFrom.MenuType == 'F'" :span="12">
            <el-form-item label="是否缓存" :label-width="formLabelWidth" prop="IsCache">
              <el-radio-group v-model="editMenuFrom.IsCache">
                <el-radio label="true">是</el-radio>
                <el-radio label="false">否</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="是否公共" :label-width="formLabelWidth" prop="IsPublic">
              <el-radio-group v-model="editMenuFrom.IsPublic">
                <el-radio label="true">是</el-radio>
                <el-radio label="false">否</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col v-if="editMenuFrom.MenuType == 'F'" :span="12">
            <el-form-item label="批量新增" :label-width="formLabelWidth" prop="IsBatch">
              <el-radio-group v-model="editMenuFrom.IsBatch">
                <el-radio label="true">是</el-radio>
                <el-radio label="false">否</el-radio>
              </el-radio-group>
              <el-link disabled>批量添加菜单下的功能按钮</el-link>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogMenuEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditMenuForm()">确 定</el-button>
      </div>
    </el-dialog>

  </div>
</template>

<script>
import { getSubSystemList } from '@/api/basebasic'
import { getAllMenuTreeTable, getMenuDetail, saveMenu, setMenuEnable, deleteSoftMenu, deleteMenu } from '@/api/developers/menufunction'

export default {
  name: 'Menu',
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
      loadBtnFunc: [],
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
      selectSystemTypeId: '',
      dialogMenuEditFormVisible: false,
      editMenuFormTitle: '',
      selectedMenuOptions: [],
      selectMenus: [],
      editMenuFrom: {
        FullName: '',
        EnCode: '',
        ParentId: '',
        SystemTypeId: '',
        Icon: '',
        UrlAddress: '',
        Component: '',
        EnabledMark: 'true',
        MenuType: 'C',
        IsPublic: 'false',
        IsShow: 'true',
        IsFrame: 'false',
        SortCode: 99,
        IsBatch: 'false',
        IsCache: 'false'
      },
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
      },
      formLabelWidth: '80px',
      currentMenuId: '',
      formShowTitle: '模块',
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: [],
      tableDataMenus: []
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
      getSubSystemList().then(res => {
        this.selectSystemType = res.ResData
      })
    },
    menuTypeChange: function () {
      var mty = this.editMenuFrom.MenuType
      if (mty === 'M') {
        this.formShowTitle = '菜单'
      } else if (mty === 'F') {
        this.formShowTitle = '功能'
      } else if (mty === 'C') {
        this.formShowTitle = '模块'
      }
    },
    /**
     * 加载页面左侧菜单table数据
     */
    loadTableData: function () {
      var data = {
        systemTypeId: this.searchmenuform.systemTypeId
      }
      getAllMenuTreeTable(data).then(res => {
        this.tableDataMenus = res.ResData
      })
    },
    /**
     * 点击查询菜单
     */
    handleSearch: function () {
      this.loadTableData()
    },
    //
    handleClickMenuChange: function (row, column, event) {
      this.searchform.code = row.EnCode
      this.currentMenuId = row.Id
    },

    /**
     * 菜单选择子系统
     */
    handleSystemTypeChange: function () {
      this.editMenuFrom.ParentId = ''
      console.log(this.selectSystemTypeId)
      this.editMenuFrom.SystemTypeId = this.selectSystemTypeId
      var data = {
        systemTypeId: this.selectSystemTypeId
      }
      getAllMenuTreeTable(data).then(res => {
        this.selectMenus = res.ResData
      })
    },
    /**
     * 功能模块选择子系统
     */
    handleFunSystemTypeChange: function () {
      this.editFunctionFrom.ParentId = ''
      console.log(this.selectSystemTypeId)
      this.editFunctionFrom.SystemTypeId = this.selectSystemTypeId
      this.loadFunctionTree()
    },
    /**
     * 添加模块式选择菜单
     */
    handleMenuChange: function () {
      if (this.currentMenuId === this.selectedMenuOptions) {
        this.$alert('不能选择自己作为父级', '提示')
        this.selectedMenuOptions = ''
        return
      }
      this.editMenuFrom.ParentId = this.selectedMenuOptions
    },
    /**
     * 添加功能时选择菜单
     */
    handleAddFunctionMenuChange: function () {
      console.log(this.selectedFunctionOptions)
      if (this.currentId === this.selectedFunctionOptions) {
        this.$alert('不能选择自己作为父级', '提示')
        this.selectedFunctionOptions = ''
        return
      }
      console.log('selectedFunctionOptions:' + this.selectedFunctionOptions)
      this.editFunctionFrom.ParentId = this.selectedFunctionOptions
    },
    /**
     * 新增、修改或查看明细信息（绑定显示数据）*
     */
    ShowMenuEditOrViewDialog: function (view) {
      if (view !== undefined) {
        if (this.currentMenuId === '') {
          this.$alert('请选择一条数据进行编辑/修改', '提示')
        } else {
          this.editMenuFormTitle = '编辑'
          this.dialogMenuEditFormVisible = true
          this.bindMenuEditInfo()
        }
      } else {
        this.editMenuFormTitle = '新增'
        this.currentMenuId = ''
        this.dialogMenuEditFormVisible = true
      }
    },
    bindMenuEditInfo: function () {
      getMenuDetail(this.currentMenuId).then(res => {
        this.editMenuFrom.FullName = res.ResData.FullName
        this.editMenuFrom.EnCode = res.ResData.EnCode
        this.editMenuFrom.EnabledMark = res.ResData.EnabledMark + ''
        this.editMenuFrom.SortCode = parseInt(res.ResData.SortCode)
        this.editMenuFrom.UrlAddress = res.ResData.UrlAddress
        this.editMenuFrom.Icon = res.ResData.Icon
        this.editMenuFrom.MenuType = res.ResData.MenuType
        this.editMenuFrom.Component = res.ResData.Component
        this.editMenuFrom.IsShow = res.ResData.IsShow + ''
        this.editMenuFrom.IsFrame = res.ResData.IsFrame + ''
        this.editMenuFrom.IsPublic = res.ResData.IsPublic + ''
        this.editMenuFrom.IsCache = res.ResData.IsCache + ''
        this.selectSystemTypeId = res.ResData.SystemTypeId
        this.selectedMenuOptions = res.ResData.ParentId
        this.handleSystemTypeChange()
        this.editMenuFrom.ParentId = res.ResData.ParentId
        this.editMenuFrom.IsBatch = 'false'
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditMenuForm () {
      this.$refs['editMenuFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'FullName': this.editMenuFrom.FullName,
            'EnCode': this.editMenuFrom.EnCode,
            'SystemTypeId': this.selectSystemTypeId,
            'ParentId': this.editMenuFrom.ParentId,
            'Icon': this.editMenuFrom.Icon,
            'UrlAddress': this.editMenuFrom.UrlAddress,
            'EnabledMark': this.editMenuFrom.EnabledMark,
            'MenuType': this.editMenuFrom.MenuType,
            'Component': this.editMenuFrom.Component,
            'SortCode': this.editMenuFrom.SortCode,
            'IsPublic': this.editMenuFrom.IsPublic,
            'IsShow': this.editMenuFrom.IsShow,
            'IsFrame': this.editMenuFrom.IsFrame,
            'IsBatch': this.editMenuFrom.IsBatch,
            'IsCache': this.editMenuFrom.IsCache,
            'Id': this.currentMenuId
          }
          var url = 'Menu/Insert'
          if (this.currentMenuId !== '') {
            url = 'Menu/Update?id=' + this.currentMenuId
          }
          saveMenu(data, url).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogMenuEditFormVisible = false
              this.currentMenuId = ''
              this.selectedMenuOptions = []
              this.$refs['editMenuFrom'].resetFields()
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
    setMenuEnable: function (val) {
      if (this.currentMenuId === '') {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = [this.currentMenuId]
        const data = {
          Ids: currentIds,
          Flag: val
        }
        setMenuEnable(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentMenuId = ''
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
    deleteMenuSoft: function (val) {
      if (this.currentMenuId === '') {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = [this.currentMenuId]
        const data = {
          Ids: currentIds,
          Flag: val
        }
        deleteSoftMenu(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentMenuId = ''
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
    deleteMenuPhysics: function () {
      if (this.currentMenuId === '') {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        var currentIds = [this.currentMenuId]
        const data = {
          Ids: currentIds
        }
        deleteMenu(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentMenuId = ''
            this.loadTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    }
  }
}
</script>
<style>
.el-cascader{
  width: 100%;
}
</style>
