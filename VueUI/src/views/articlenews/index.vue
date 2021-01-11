<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form
          ref="searchform"
          :inline="true"
          :model="searchform"
          class="demo-form-inline"
          size="small"
        >
          <el-form-item label="名称：">
            <el-input v-model="searchform.keywords" clearable placeholder="名称" />
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
          <slot v-for="itemf in loadBtnFunc">
            <el-button
              v-if="itemf.FullName==='新增'"
              type="primary"
              icon="el-icon-plus"
              size="small"
              @click="ShowEditOrViewDialog()"
            >新增</el-button>
            <el-button
              v-if="itemf.FullName==='修改'"
              type="primary"
              icon="el-icon-edit"
              class="el-button-modify"
              size="small"
              @click="ShowEditOrViewDialog('edit')"
            >修改</el-button>
            <el-button
              v-if="itemf.FullName=='禁用'"
              type="info"
              icon="el-icon-video-pause"
              size="small"
              @click="setEnable('0')"
            >设为未发布</el-button>
            <el-button
              v-if="itemf.FullName=='启用'"
              type="success"
              icon="el-icon-video-play"
              size="small"
              @click="setEnable('1')"
            >设为发布</el-button>
            <el-button
              v-if="itemf.FullName==='软删除'"
              type="warning"
              icon="el-icon-delete"
              size="small"
              @click="deleteSoft('0')"
            >软删除</el-button>
            <el-button
              v-if="itemf.FullName==='删除'"
              type="danger"
              icon="el-icon-delete"
              size="small"
              @click="deletePhysics()"
            >删除</el-button>
          </slot>
          <el-button type="default" icon="el-icon-refresh" size="small" @click="loadTableData()">刷新</el-button>
        </el-button-group>
      </div>
      <el-table
        ref="gridtable"
        v-loading="tableloading"
        :data="tableData"
        border
        stripe
        highlight-current-row
        style="width: 100%"
        :default-sort="{prop: 'SortCode', order: 'ascending'}"
        @select="handleSelectChange"
        @select-all="handleSelectAllChange"
        @sort-change="handleSortChange"
      >
        <el-table-column type="selection" width="30" />
        <el-table-column prop="Title" label="文章标题" sortable="custom" />
        <el-table-column prop="CategoryName" label="所属分类" sortable="custom" width="120" />
        <el-table-column prop="SortCode" label="排序" sortable="custom" width="120" />
        <el-table-column label="属性" sortable="custom" width="230" prop="" align="center">
          <template slot-scope="scope">
            <el-tag v-if="scope.row.IsTop === true" disable-transitions>置顶</el-tag>
            <el-tag v-if="scope.row.IsRed === true" type="success" disable-transitions>推荐</el-tag>
            <el-tag v-if="scope.row.IsHot === true" type="danger" disable-transitions>热门</el-tag>
            <el-tag v-if="scope.row.IsNew === true" type="warning" disable-transitions>最新</el-tag>
          </template>
        </el-table-column>
        <el-table-column label="是否发布" sortable="custom" width="120" prop="EnabledMark" align="center">
          <template slot-scope="scope">
            <el-tag :type="scope.row.EnabledMark === true ? 'success' : 'info'" disable-transitions>{{ scope.row.EnabledMark === true ? "已发布" : "未发布" }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column prop="CreatorTime" label="创建时间" sortable="custom" width="160" />

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
    </el-card>
    <el-dialog
      ref="dialogEditForm"
      v-el-drag-dialog
      :title="editFormTitle+'文章'"
      :visible.sync="dialogEditFormVisible"
      width="960px"
    >
      <el-form ref="editFrom" :model="editFrom" :rules="rules">
        <el-row>
          <el-col :span="12">
            <el-form-item label="文章标题" :label-width="formLabelWidth" prop="Title">
              <el-input v-model="editFrom.Title" placeholder="请输入文章标题" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="副标题" :label-width="formLabelWidth" prop="SubTitle">
              <el-input v-model="editFrom.SubTitle" placeholder="请输入文章副标题" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="文章分类" :label-width="formLabelWidth" prop="CategoryId">
              <el-cascader
                v-model="selectedCategoryOptions"
                style="width: 380px"
                :options="selectCategory"
                filterable
                :props="{label: 'Title',
                         value: 'Id',
                         children: 'Children',
                         emitPath: false,
                         checkStrictly: true,
                         expandTrigger: 'hover',
                }"
                clearable
                @change="handleSelectCategoryChange"
              />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="外链" :label-width="formLabelWidth" prop="LinkUrl">
              <el-input v-model="editFrom.LinkUrl" placeholder="请输入外部链接" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item label="详情" :label-width="formLabelWidth" prop="Description">
              <editor v-model="editFrom.Description" :min-height="192" :height="300" />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
              <el-input v-model="editFrom.SortCode" placeholder="请输入排序" autocomplete="off" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="属性" :label-width="formLabelWidth" prop="">
              <el-checkbox v-model="editFrom.IsTop">置顶</el-checkbox>
              <el-checkbox v-model="editFrom.IsHot">热门</el-checkbox>
              <el-checkbox v-model="editFrom.IsRed">推荐</el-checkbox>
              <el-checkbox v-model="editFrom.IsNew">最新</el-checkbox>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="是否发布" :label-width="formLabelWidth" prop="EnabledMark">
              <el-radio-group v-model="editFrom.EnabledMark">
                <el-radio :label="true">是</el-radio>
                <el-radio :label="false">否</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="cancel">取 消</el-button>
        <el-button type="primary" @click="saveEditForm()">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>

import { getArticlenewsListWithPager, getArticlenewsDetail,
  saveArticlenews, setArticlenewsEnable, deleteSoftArticlenews,
  deleteArticlenews } from '@/api/cms/articlenews'
import { GetAllCategoryTreeTable } from '@/api/cms/articlecategory'
import Editor from '@/components/Editor'

import elDragDialog from '@/directive/el-drag-dialog' // base on element-ui
export default {
  name: 'Articlenews',
  directives: { elDragDialog },
  components: {
    Editor
  },
  data () {
    return {
      searchform: {
        keywords: ''
      },
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
        sort: 'CreatorTime'
      },
      dialogEditFormVisible: false,
      editFormTitle: '',
      editFrom: {},
      rules: {
        CategoryId: [
          { required: true, message: '请输入文章分类', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        Title: [
          { required: true, message: '请输入文章标题', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ]
      },
      selectedCategoryOptions: '',
      selectCategory: [],
      formLabelWidth: '80px',
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: []
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
      GetAllCategoryTreeTable().then(res => {
        this.selectCategory = res.ResData
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
        Keywords: this.searchform.keywords,
        Order: this.sortableData.order,
        Sort: this.sortableData.sort
      }
      getArticlenewsListWithPager(seachdata).then(res => {
        this.tableData = res.ResData.Items
        this.pagination.pageTotal = res.ResData.TotalItems
        this.tableloading = false
      })
    },

    // 取消按钮
    cancel () {
      this.dialogEditFormVisible = false
      this.reset()
    },
    // 表单重置
    reset () {
      this.editFrom = {
        CategoryId: '',
        Title: '',
        Description: '',
        SortCode: 99,
        EnabledMark: true
      }
      this.resetForm('editFrom')
    },
    /**
     * 点击查询
     */
    handleSearch: function () {
      this.pagination.currentPage = 1
      this.loadTableData()
    },

    /**
     * 选择分类
     */
    handleSelectCategoryChange: function () {
      this.editFrom.CategoryId = this.selectedCategoryOptions
    },
    /**
     * 新增、修改或查看明细信息（绑定显示数据）     *
     */
    ShowEditOrViewDialog: function (view) {
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
        this.selectedCategoryOptions = ''
      }
    },
    bindEditInfo: function () {
      getArticlenewsDetail(this.currentId).then(res => {
        this.editFrom = res.ResData
        this.selectedCategoryOptions = res.ResData.CategoryId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm () {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          var url = 'Articlenews/Insert'
          if (this.currentId !== '') {
            url = 'Articlenews/Update?id=' + this.currentId
          }
          saveArticlenews(this.editFrom, url).then(res => {
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
        setArticlenewsEnable(data).then(res => {
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
        deleteSoftArticlenews(data).then(res => {
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
          return deleteArticlenews(data)
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
    }
  }
}
</script>

<style>
</style>
