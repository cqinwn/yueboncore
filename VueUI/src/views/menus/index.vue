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
                    <el-button type="default" icon="el-icon-refresh" size="small" @click="loadTableData()">刷新</el-button>
                    <slot v-for="itemf in loadBtnFunc">
                      <el-button v-if="itemf.FullName==='新增'" type="primary" icon="el-icon-plus" size="small" @click="ShowEditOrViewDialog()">新增</el-button>
                      <el-button v-if="itemf.FullName==='修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="small" @click="ShowEditOrViewDialog('edit')">修改</el-button>
                      <el-button v-if="itemf.FullName=='禁用'" type="info" icon="el-icon-video-pause" size="small" @click="setEnable('0')">禁用</el-button>
                      <el-button v-if="itemf.FullName=='启用'" type="success" icon="el-icon-video-play" size="small" @click="setEnable('1')">启用</el-button>
                      <el-button v-if="itemf.FullName==='删除'" type="danger" icon="el-icon-delete" size="small" @click="deletePhysics()">删除</el-button>
                    </slot>
                  </el-form-item>
                  <el-form-item label="系统名称：">
                    <el-select v-model="searchmenuform.systemTypeId" clearable placeholder="请选择">
                      <el-option
                        v-for="item in selectSystemType"
                        :key="item.Id"
                        :label="item.FullName"
                        :value="item.Id"
                      />
                    </el-select>
                  </el-form-item>
                  <el-form-item>
                    <el-button type="primary" @click="handleSearch()">查询</el-button>
                  </el-form-item>
                </el-form>
              </div>
              <el-table
                :data="tableDataMenus"
                style="width: 100%;margin-bottom: 20px;"
                row-key="Id"
                border
                default-expand-all
                :tree-props="{children: 'Children'}"
                @row-click="handleClickMenuChange"
              >
                <el-table-column
                  prop="FullName"
                  label="菜单名称"
                  width="220"
                />
                <el-table-column
                  prop="EnCode"
                  label="功能编码"
                  width="220"
                />
                <el-table-column
                  prop="UrlAddress"
                  label="访问地址"
                />
                <el-table-column
                  label="是否启用"
                  sortable="custom"
                  width="120"
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
                  <el-button type="default" icon="el-icon-refresh" size="small" @click="loadFunctionTableData()">刷新</el-button>
                  <slot v-for="itemf in loadBtnFunc">
                    <el-button v-if="itemf.FullName==='新增'" type="primary" icon="el-icon-plus" size="small" @click="ShowEditOrViewDialog()">新增</el-button>
                    <el-button v-if="itemf.FullName==='修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="small" @click="ShowEditOrViewDialog('edit')">修改</el-button>
                    <el-button v-if="itemf.FullName=='禁用'" type="info" icon="el-icon-video-pause" size="small" @click="setEnable('0')">禁用</el-button>
                    <el-button v-if="itemf.FullName=='启用'" type="success" icon="el-icon-video-play" size="small" @click="setEnable('1')">启用</el-button>
                    <el-button v-if="itemf.FullName==='删除'" type="danger" icon="el-icon-delete" size="small" @click="deletePhysics()">删除</el-button>
                  </slot>
                </el-form-item>
                <el-form-item label="功能名称：">
                  <el-input v-model="searchform.keywords" clearable placeholder="功能名称或编码" />
                </el-form-item>
                <el-form-item>
                  <el-button type="primary" @click="handleSearchFunction()">查询</el-button>
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
            style="width: 100%"
            :default-sort="{prop: 'SortCode', order: 'descending'}"
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
              width="180"
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
              width="100"
            />
            <el-table-column
              prop="Icon"
              label="图标"
              sortable="custom"
              width="120"
            />
            <el-table-column
              label="是否启用"
              sortable="custom"
              width="120"
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
    <el-dialog ref="dialogEditForm" :title="editFormTitle+'仓库'" :visible.sync="dialogEditFormVisible" width="30%">
      <el-form ref="editFrom" :model="editFrom" :rules="rules">

        <el-form-item label="仓库编码" :label-width="formLabelWidth" prop="code">
          <el-input v-model="editFrom.code" placeholder="请输入仓库编码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="仓库名称" :label-width="formLabelWidth" prop="name">
          <el-input v-model="editFrom.name" placeholder="请输入仓库名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="sortcode">
          <el-input v-model.number="editFrom.sortcode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="是否启用" :label-width="formLabelWidth" prop="enable">
          <el-radio-group v-model="editFrom.enable">
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
  </div>
</template>

<script>
import { getSubSystemList } from '@/api/basebasic'
import { getAllMenuTreeTable, getMenuDetail, saveMenu, setMenuEnable, deleteSoftMenu, deleteMenu,
  getFunctionListWithPager
} from '@/api/menu/menufunction'

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
      loadBtnFunc: [],
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
      dialogEditFormVisible: false,
      editFormTitle: '',
      editFrom: {
        name: '',
        code: '',
        enable: 'true',
        parentId: '',
        sortcode: 99
      },
      rules: {
        name: [
          { required: true, message: '请输入仓库名称', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        code: [
          { required: true, message: '请输入仓库编码', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ]
      },
      formLabelWidth: '80px',
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
    this.loadBtnFunc = JSON.parse(localStorage.getItem('yueboncurrentfuns'))
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem() {
      getSubSystemList().then(res => {
        this.selectSystemType = res.ResData
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
     * 点击查询
     */
    handleSearch: function() {
      this.pagination.currentPage = 1
      this.loadTableData()
    },
    handleSearchFunction: function() {
      this.pagination.currentPage = 1
      this.loadFunctionTableData()
    },
    /**
     * 新增、修改或查看明细信息（绑定显示数据）     *
     */
    ShowEditOrViewDialog: function(view) {
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
        this.$refs['editFrom'].resetFields()
      }
    },
    bindEditInfo: function() {
      getMenuDetail(this.currentId).then(res => {
        this.editFrom.name = res.ResData.Title
        this.editFrom.code = res.ResData.EnCode
        this.editFrom.enable = res.ResData.EnabledMark + ''
        this.editFrom.sortcode = parseInt(res.ResData.SortCode)
        this.editFrom.parentId = res.ResData.ParentId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm() {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'Title': this.editFrom.name,
            'EnCode': this.editFrom.code,
            'EnabledMark': this.editFrom.enable,
            'SortCode': this.editFrom.sortcode,
            'Id': this.currentId
          }
          saveMenu(data).then(res => {
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
        var currentIds = ''
        this.currentSelected.forEach(element => {
          currentIds += element.Id + ','
        })
        const data = {
          ids: currentIds,
          bltag: val
        }
        setMenuEnable(data).then(res => {
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
        var currentIds = ''
        this.currentSelected.forEach(element => {
          currentIds += element.Id + ','
        })
        const data = {
          ids: currentIds,
          bltag: val
        }
        deleteSoftMenu(data).then(res => {
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
        var currentIds = ''
        this.currentSelected.forEach(element => {
          currentIds += element.Id + ','
        })
        const data = {
          ids: currentIds
        }
        deleteMenu(data).then(res => {
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
