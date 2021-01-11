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
          <el-form-item label="业务单据名称：">
            <el-input v-model="searchform.name" clearable placeholder="业务单据名称" />
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
            >禁用</el-button>
            <el-button
              v-if="itemf.FullName=='启用'"
              type="success"
              icon="el-icon-video-play"
              size="small"
              @click="setEnable('1')"
            >启用</el-button>
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
        :default-sort="{prop: 'SequenceName', order: 'ascending'}"
        @select="handleSelectChange"
        @select-all="handleSelectAllChange"
        @sort-change="handleSortChange"
      >
        <el-table-column type="selection" width="30" />
        <el-table-column prop="SequenceName" label="业务单据名称" sortable="custom" width="180" />
        <el-table-column prop="RuleOrder" label="排序" width="80" />
        <el-table-column prop="RuleType" label="规则类型" sortable="custom" width="140">
          <template slot-scope="scope">
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
          <template slot-scope="scope">
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
          <template slot-scope="scope">
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
          <template slot-scope="scope">
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
      :title="editFormTitle+'业务单据号规则'"
      :visible.sync="dialogEditFormVisible"
      width="640px"
    >
      <el-form ref="editFrom" :model="editFrom" :rules="rules">
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

import { getSequenceRuleListWithPager, getSequenceRuleDetail,
  saveSequenceRule, setSequenceRuleEnable, deleteSoftSequenceRule,
  deleteSequenceRule } from '@/api/security/sequencerule'
import { getAllSequenceList } from '@/api/security/sequence'

export default {
  name: 'SequenceRule',
  data () {
    return {
      searchform: {
        name: ''
      },
      loadBtnFunc: [],
      selectedSequence: '',
      tableData: [],
      tableloading: true,
      pagination: {
        currentPage: 1,
        pagesize: 20,
        pageTotal: 0
      },
      sortableData: {
        order: 'asc',
        sort: 'SequenceName'
      },
      dialogEditFormVisible: false,
      editFormTitle: '',
      editFrom: {
        SequenceName: '',
        RuleOrder: 1,
        RuleType: 'date',
        RuleValue: '',
        PaddingSide: 'None',
        PaddingWidth: 0,
        PaddingChar: '',
        Description: '',
        EnabledMark: 'true'
      },
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
      formLabelWidth: '80px',
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: [],
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
      getAllSequenceList().then(res => {
        this.selectedSequence = res.ResData
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
      getSequenceRuleListWithPager(seachdata).then(res => {
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
      getSequenceRuleDetail(this.currentId).then(res => {
        this.editFrom.SequenceName = res.ResData.SequenceName
        this.editFrom.RuleOrder = res.ResData.RuleOrder
        this.editFrom.RuleType = res.ResData.RuleType
        this.editFrom.RuleValue = res.ResData.RuleValue
        this.editFrom.PaddingSide = res.ResData.PaddingSide
        this.editFrom.PaddingWidth = res.ResData.PaddingWidth
        this.editFrom.PaddingChar = res.ResData.PaddingChar
        this.editFrom.EnabledMark = res.ResData.EnabledMark + ''
        this.editFrom.Description = res.ResData.Description
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm () {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = {
            'SequenceName': this.editFrom.SequenceName,
            'RuleOrder': this.editFrom.RuleOrder,
            'RuleType': this.editFrom.RuleType,
            'RuleValue': this.editFrom.RuleValue,
            'PaddingSide': this.editFrom.PaddingSide,
            'PaddingWidth': this.editFrom.PaddingWidth,
            'PaddingChar': this.editFrom.PaddingChar,
            'EnabledMark': this.editFrom.EnabledMark,
            'Description': this.editFrom.Description,
            'Id': this.currentId
          }
          saveSequenceRule(data).then(res => {
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
        setSequenceRuleEnable(data).then(res => {
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
        deleteSoftSequenceRule(data).then(res => {
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
          return deleteSequenceRule(data)
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
