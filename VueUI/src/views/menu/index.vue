<template>
  <div class="app-container">
    <el-card>
      <el-row :gutter="20">
        <el-col :span="12">
          <div class="grid-content bg-purple">
            <div class="grid-content bg-purple">
              <div class="list-btn-container">
                <el-form ref="searchmenuform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
                  <el-form-item>
                    <el-button-group>
                      <el-button type="default" icon="el-icon-refresh" size="mini" @click="loadTableData()">刷新</el-button>
                      <slot v-for="itemf in loadMenuBtnFunc">
                        <el-button v-if="itemf.FullName==='新增'" type="primary" icon="el-icon-plus" size="mini" @click="ShowMenuEditOrViewDialog()">新增</el-button>
                        <el-button v-if="itemf.FullName==='修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="mini" @click="ShowMenuEditOrViewDialog('edit')">修改</el-button>
                        <el-button v-if="itemf.FullName=='禁用'" type="info" icon="el-icon-video-pause" size="mini" @click="setMenuEnable('0')">禁用</el-button>
                        <el-button v-if="itemf.FullName=='启用'" type="success" icon="el-icon-video-play" size="mini" @click="setMenuEnable('1')">启用</el-button>
                        <el-button v-if="itemf.FullName==='删除'" type="danger" icon="el-icon-delete" size="mini" @click="deleteMenuPhysics()">删除</el-button>
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
                  label="模块名称"
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
                  label="访问地址"
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
        <el-col :span="12">
          <div class="grid-content bg-purple">
            <div class="list-btn-container">
              <el-form ref="searchform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
                <el-form-item>
                  <el-button-group>
                    <el-button type="default" icon="el-icon-refresh" size="mini" @click="loadFunctionTableData()">刷新</el-button>
                    <slot v-for="itemf in loadFunctionBtnFunc">
                      <el-button v-if="itemf.FullName==='新增'" type="primary" icon="el-icon-plus" size="mini" @click="ShowFunctionEditOrViewDialog()">新增</el-button>
                      <el-button v-if="itemf.FullName==='修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="mini" @click="ShowFunctionEditOrViewDialog('edit')">修改</el-button>
                      <el-button v-if="itemf.FullName=='禁用'" type="info" icon="el-icon-video-pause" size="mini" @click="setFunctionEnable('0')">禁用</el-button>
                      <el-button v-if="itemf.FullName=='启用'" type="success" icon="el-icon-video-play" size="mini" @click="setFunctionEnable('1')">启用</el-button>
                      <el-button v-if="itemf.FullName==='删除'" type="danger" icon="el-icon-delete" size="mini" @click="deleteFunctionPhysics()">删除</el-button>
                    </slot>
                  </el-button-group>
                </el-form-item>
                <el-form-item label="功能名称：">
                  <el-input v-model="searchform.keywords" style="width:150px" clearable placeholder="功能名称或编码" />
                </el-form-item>
                <el-form-item>
                  <el-button type="primary" size="mini" @click="handleSearchFunction()">查询</el-button>
                </el-form-item>
              </el-form>
            </div>
          </div>

          <el-table
            ref="gridtable"
            v-loading="tableloading"
            :data="tableData"
            border
            stripe
            highlight-current-row
            size="mini"
            style="width: 100%"
            :default-sort="{prop: 'SortCode', order: 'ascending'}"
            @select="handleSelectChange"
            @select-all="handleSelectAllChange"
            @sort-change="handleSortChange"
          >
            <el-table-column
              type="selection"
              width="30"
            />
            <el-table-column
              prop="FullName"
              label="功能名称"
              sortable="custom"
            />
            <el-table-column
              prop="EnCode"
              label="功能编码"
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
              prop="Icon"
              label="图标"
              sortable="custom"
              width="80"
              align="center"
            >
              <template slot-scope="scope">
                <i
                  :class="scope.row.Icon"
                />
              </template>
            </el-table-column>
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
          <div class="pagination-container">
            <el-pagination
              background
              :current-page="pagination.currentPage"
              :page-sizes="[5,10,20,50,100, 200, 300, 400]"
              :page-size="pagination.pagesize"
              layout="total, sizes, prev, pager, next, jumper"
              :total="pagination.pageTotal"
              @size-change="handleSizeChange"
              @current-change="handleCurrentChange"
            />
          </div>
        </el-col>
      </el-row>
    </el-card>
    <el-dialog ref="dialogEditMenuForm" :title="editMenuFormTitle+'模块'" :visible.sync="dialogMenuEditFormVisible" width="30%">
      <el-form ref="editMenuFrom" :model="editMenuFrom" :rules="rules">
        <el-form-item label="模块名称" :label-width="formLabelWidth" prop="FullName">
          <el-input v-model="editMenuFrom.FullName" placeholder="请输入模块名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="模块编码" :label-width="formLabelWidth" prop="EnCode">
          <el-input v-model="editMenuFrom.EnCode" placeholder="请输入模块编码" autocomplete="off" clearable />
        </el-form-item>
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
        <el-form-item label="Url" :label-width="formLabelWidth" prop="UrlAddress">
          <el-input v-model="editMenuFrom.UrlAddress" placeholder="请输入连接地址" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="图标" :label-width="formLabelWidth" prop="Icon">
          <el-input v-model="editMenuFrom.Icon" placeholder="请填写icon图标值" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
          <el-input v-model.number="editMenuFrom.SortCode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="属性" :label-width="formLabelWidth" prop="">
          <el-checkbox v-model="editMenuFrom.EnabledMark">启用</el-checkbox>
          <el-checkbox v-model="editMenuFrom.IsMenu">菜单</el-checkbox>
          <el-checkbox v-model="editMenuFrom.IsPublic">公共</el-checkbox>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogMenuEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditMenuForm()">确 定</el-button>
      </div>
    </el-dialog>

    <el-dialog ref="dialogEditFunctionForm" :title="editFunctionFormTitle+'功能'" :visible.sync="dialogFunctionEditFormVisible" width="30%">
      <el-form ref="editFunctionFrom" :model="editFunctionFrom" :rules="rulesfun">
        <el-form-item label="功能名称" :label-width="formLabelWidth" prop="FullName">
          <el-input v-model="editFunctionFrom.FullName" placeholder="请输入功能名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="功能编码" :label-width="formLabelWidth" prop="EnCode">
          <el-input v-model="editFunctionFrom.EnCode" placeholder="请输入功能编码，批量添加时仅填写控制器名称即可" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="所属系统" :label-width="formLabelWidth" prop="SystemTypeId">
          <el-select v-model="selectSystemTypeId" clearable placeholder="请选择" @change="handleFunSystemTypeChange">
            <el-option
              v-for="item in selectSystemType"
              :key="item.Id"
              :label="item.FullName"
              :value="item.Id"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="上级功能" :label-width="formLabelWidth" prop="ParentId">
          <el-cascader
            v-model="selectedFunctionOptions"
            :options="selectFunctions"
            filterable
            :props="{label:'FullName',value:'Id',children:'Children',emitPath:false, checkStrictly: true,expandTrigger: 'hover' }"
            clearable
            @change="handleAddFunctionMenuChange"
          />
        </el-form-item>
        <el-form-item label="图标" :label-width="formLabelWidth" prop="Icon">
          <el-input v-model="editFunctionFrom.Icon" placeholder="请填写icon图标值" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
          <el-input v-model.number="editFunctionFrom.SortCode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="批量新增" :label-width="formLabelWidth" prop="IsBatch">
          <el-radio-group v-model="editFunctionFrom.IsBatch">
            <el-radio label="true">是</el-radio>
            <el-radio label="false">否</el-radio>
          </el-radio-group>
          <el-link disabled>批量添加时，功能编码填写控制器名称即可</el-link>
        </el-form-item>
        <el-form-item label="是否启用" :label-width="formLabelWidth" prop="enable">
          <el-radio-group v-model="editFunctionFrom.EnabledMark">
            <el-radio label="true">是</el-radio>
            <el-radio label="false">否</el-radio>
          </el-radio-group>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFunctionEditFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="saveEditFunctionForm()">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import { getSubSystemList, getListMeunFuntionBymeunCode } from '@/api/basebasic'
import { getAllMenuTreeTable, getMenuDetail, saveMenu, setMenuEnable, deleteSoftMenu, deleteMenu,
  getFunctionListWithPager,
  getFunctionDetail, saveFunction, setFunctionEnable, deleteSoftFunction,
  deleteFunction,
  getAllFunctionTreeTable
} from '@/api/developers/menufunction'

export default {
  data() {
    return {
      searchform: {
        keywords: '',
        code: ''
      },
      searchmenuform: {
        systemTypeId: ''
      },
      selectSystemType: [],
      loadMenuBtnFunc: [],
      loadFunctionBtnFunc: [],
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
        EnabledMark: true,
        IsMenu: false,
        IsPublic: true,
        SortCode: 99
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
        ]
      },
      formLabelWidth: '80px',
      currentMenuId: '',

      dialogFunctionEditFormVisible: false,
      editFunctionFormTitle: '',
      selectedFunctionOptions: [],
      selectFunctions: [],
      editFunctionFrom: {
        FullName: '',
        EnCode: '',
        ParentId: '',
        SystemTypeId: '',
        Icon: '',
        UrlAddress: '',
        EnabledMark: 'true',
        IsBatch: 'false',
        SortCode: 99
      },
      rulesfun: {
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
        ]
      },
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: [],
      tableDataMenus: []
    }
  },
  created() {
    this.pagination.currentPage = 1
    this.InitDictItem()
    this.loadTableData()
    this.loadFunctionTableData()
    this.loadMenuBtnFunc = JSON.parse(localStorage.getItem('yueboncurrentfuns'))
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem() {
      getSubSystemList().then(res => {
        this.selectSystemType = res.ResData
      })
      getListMeunFuntionBymeunCode('Menu/List').then(res => {
        this.loadMenuBtnFunc = res.ResData
      })
      getListMeunFuntionBymeunCode('Function/List').then(res => {
        this.loadFunctionBtnFunc = res.ResData
      })
    },
    /**
     * 加载页面左侧菜单table数据
     */
    loadTableData: function() {
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
    handleSearch: function() {
      this.loadTableData()
    },
    /**
     * 点击查询
     */
    handleSearchFunction: function() {
      this.pagination.currentPage = 1
      this.loadFunctionTableData()
    },

    /**
     * 菜单选择子系统
     */
    handleSystemTypeChange: function() {
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
    handleFunSystemTypeChange: function() {
      this.editFunctionFrom.ParentId = ''
      console.log(this.selectSystemTypeId)
      this.editFunctionFrom.SystemTypeId = this.selectSystemTypeId
      this.loadFunctionTree()
    },
    loadFunctionTree() {
      var data = {
        systemTypeId: this.selectSystemTypeId
      }
      getAllFunctionTreeTable(data).then(res => {
        this.selectFunctions = res.ResData
      })
    },
    /**
     * 添加模块式选择菜单
     */
    handleMenuChange: function() {
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
    handleAddFunctionMenuChange: function() {
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
    ShowMenuEditOrViewDialog: function(view) {
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
        this.$refs['editMenuFrom'].resetFields()
      }
    },
    bindMenuEditInfo: function() {
      getMenuDetail(this.currentMenuId).then(res => {
        this.editMenuFrom.FullName = res.ResData.FullName
        this.editMenuFrom.EnCode = res.ResData.EnCode
        this.editMenuFrom.EnabledMark = res.ResData.EnabledMark
        this.editMenuFrom.SortCode = parseInt(res.ResData.SortCode)
        this.editMenuFrom.UrlAddress = res.ResData.UrlAddress
        this.editMenuFrom.Icon = res.ResData.Icon
        this.editMenuFrom.IsMenu = res.ResData.IsMenu
        this.editMenuFrom.IsPublic = res.ResData.IsPublic
        this.selectSystemTypeId = res.ResData.SystemTypeId
        this.selectedMenuOptions = res.ResData.ParentId
        this.handleSystemTypeChange()
        this.editMenuFrom.ParentId = res.ResData.ParentId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditMenuForm() {
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
            'IsMenu': this.editMenuFrom.IsMenu,
            'SortCode': this.editMenuFrom.SortCode,
            'IsPublic': this.editMenuFrom.IsPublic,
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
    setMenuEnable: function(val) {
      if (this.currentMenuId === '') {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        const data = {
          ids: this.currentMenuId,
          bltag: val
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
    deleteMenuSoft: function(val) {
      if (this.currentMenuId === '') {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        const data = {
          ids: this.currentMenuId,
          bltag: val
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
    deleteMenuPhysics: function() {
      if (this.currentMenuId === '') {
        this.$alert('请先选择要操作的数据', '提示')
        return false
      } else {
        const data = {
          ids: this.currentMenuId
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
    },
    /**
     * 新增、修改或查看明细信息（绑定显示数据）*
     */
    ShowFunctionEditOrViewDialog: function(view) {
      if (view !== undefined) {
        if (this.currentSelected.length === 0) {
          this.$alert('请选择一条数据进行编辑/修改', '提示')
        } else {
          this.editFunctionFormTitle = '编辑'
          this.dialogFunctionEditFormVisible = true
          this.currentId = this.currentSelected[0].Id
          this.bindFunctionEditInfo()
        }
      } else {
        this.editFunctionFormTitle = '新增'
        this.currentId = ''
        this.dialogFunctionEditFormVisible = true
        this.$refs['editFunctionFrom'].resetFields()
      }
    },
    bindFunctionEditInfo: function() {
      getFunctionDetail(this.currentId).then(res => {
        this.editFunctionFrom.FullName = res.ResData.FullName
        this.editFunctionFrom.EnCode = res.ResData.EnCode
        this.editFunctionFrom.EnabledMark = res.ResData.EnabledMark + ''
        this.editFunctionFrom.SortCode = parseInt(res.ResData.SortCode)
        this.editFunctionFrom.ParentCode = res.ResData.EnCode
        this.editFunctionFrom.UrlAddress = res.ResData.UrlAddress
        this.editFunctionFrom.Icon = res.ResData.Icon
        this.editFunctionFrom.SystemTypeId = res.ResData.SystemTypeId
        this.selectSystemTypeId = res.ResData.SystemTypeId
        this.handleSystemTypeChange()
        this.selectedFunctionOptions = res.ResData.ParentId
        this.loadFunctionTree()
        this.editFunctionFrom.ParentId = res.ResData.ParentId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditFunctionForm() {
      this.$refs['editFunctionFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'FullName': this.editFunctionFrom.FullName,
            'EnCode': this.editFunctionFrom.EnCode,
            'SystemTypeId': this.selectSystemTypeId,
            'ParentId': this.editFunctionFrom.ParentId,
            'Icon': this.editFunctionFrom.Icon,
            'UrlAddress': this.editFunctionFrom.UrlAddress,
            'IsBatch': this.editFunctionFrom.IsBatch,
            'EnabledMark': this.editFunctionFrom.EnabledMark,
            'SortCode': this.editFunctionFrom.SortCode,
            'Id': this.currentId
          }

          var url = 'Function/Insert'
          if (this.currentId !== '') {
            url = 'Function/Update?id=' + this.currentId
          }
          saveFunction(data, url).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogFunctionEditFormVisible = false
              this.currentSelected = ''
              this.$refs['editFunctionFrom'].resetFields()
              this.loadFunctionTableData()
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
    setFunctionEnable: function(val) {
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
        setFunctionEnable(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadFunctionTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    deleteFunctionSoft: function(val) {
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
        deleteSoftFunction(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadFunctionTableData()
          } else {
            this.$message({
              message: res.ErrMsg,
              type: 'error'
            })
          }
        })
      }
    },
    deleteFunctionPhysics: function() {
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
        deleteFunction(data).then(res => {
          if (res.Success) {
            this.$message({
              message: '恭喜你，操作成功',
              type: 'success'
            })
            this.currentSelected = ''
            this.loadFunctionTableData()
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
      this.loadFunctionTableData()
    },
    //
    handleClickMenuChange: function(row, column, event) {
      this.searchform.code = row.EnCode
      this.currentMenuId = row.Id
      this.loadFunctionTableData()
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
    },
    /**
     * 选择每页显示数量
     */
    handleSizeChange(val) {
      this.pagination.pagesize = val
      this.pagination.currentPage = 1
      this.loadFunctionTableData()
    },
    /**
     * 选择当页面
     */
    handleCurrentChange(val) {
      this.pagination.currentPage = val
      this.loadFunctionTableData()
    },

    /**
     * 加载页面table数据
     */
    loadFunctionTableData: function() {
      this.tableloading = true
      var seachdata = {
        'CurrentPage': this.pagination.currentPage,
        'length': this.pagination.pagesize,
        'Keywords': this.searchform.keywords,
        'EnCode': this.searchform.code,
        'Order': this.sortableData.order,
        'Sort': this.sortableData.sort
      }
      getFunctionListWithPager(seachdata).then(res => {
        this.tableData = res.ResData.Items
        this.pagination.pageTotal = res.ResData.TotalItems
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
