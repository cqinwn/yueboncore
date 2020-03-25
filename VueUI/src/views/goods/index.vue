<template>
  <div class="app-container">
    <div class="filter-container">
      <el-card>
        <el-form ref="searchform" :inline="true" :model="searchform" class="demo-form-inline" size="small">
          <el-form-item label="商品分类" prop="categoryId">
            <el-select v-model="searchform.categoryId" clearable placeholder="请选">
              <el-option
                v-for="item in selectCategories"
                :key="item.Id"
                :label="item.Title"
                :value="item.Id"
              />
            </el-select>
          </el-form-item>
          <el-form-item label="商品名称：">
            <el-input v-model="searchform.Title" clearable placeholder="商品名称、英文名称" />
          </el-form-item>
          <el-form-item label="商品编码：">
            <el-input v-model="searchform.EnCode" clearable placeholder="商品编码" />
          </el-form-item>
          <el-form-item label="客户商品编码：">
            <el-input v-model="searchform.CustomerEnCode" clearable placeholder="客户商品编码" />
          </el-form-item>
          <el-form-item label="商品条码">
            <el-input v-model="searchform.BarCode" clearable placeholder="商品条码" />
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
            <el-button v-if="itemf.FullName==='新增'" type="primary" icon="el-icon-plus" size="small" @click="ShowEditOrViewDialog()">新增</el-button>
            <el-button v-if="itemf.FullName==='修改'" type="primary" icon="el-icon-edit" class="el-button-modify" size="small" @click="ShowEditOrViewDialog('edit')">修改</el-button>
            <el-button v-if="itemf.FullName=='禁用'" type="info" icon="el-icon-video-pause" size="small" @click="setEnable('0')">禁用</el-button>
            <el-button v-if="itemf.FullName=='启用'" type="success" icon="el-icon-video-play" size="small" @click="setEnable('1')">启用</el-button>
            <el-button v-if="itemf.FullName==='软删除'" type="warning" icon="el-icon-delete" size="small" @click="deleteSoft('0')">软删除</el-button>
            <el-button v-if="itemf.FullName==='删除'" type="danger" icon="el-icon-delete" size="small" @click="deletePhysics()">删除</el-button>
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
          prop="EnCode"
          label="商品编码"
          sortable="custom"
          width="120"
          fixed
        />
        <el-table-column
          prop="Title"
          label="商品名称"
          sortable="custom"
          width="180"
          fixed
        />
        <el-table-column
          prop="EnTitle"
          label="英文名称"
          sortable="custom"
          width="180"
          fixed
        />
        <el-table-column
          prop="CustomerEnCode"
          label="客户商品编码"
          sortable="custom"
          width="140"
          align="center"
          fixed
        />
        <el-table-column
          prop="BarCode"
          label="商品条码"
          sortable="custom"
          width="120"
          align="center"
        />
        <el-table-column
          prop="Specs"
          label="规格"
          sortable="custom"
          width="90"
          align="center"
        />
        <el-table-column
          prop="BaseUnit"
          label="单位"
          width="90"
          align="center"
        />
        <el-table-column
          prop="Price"
          label="价格(元)"
          sortable="custom"
          width="110"
          align="center"
        />
        <el-table-column
          prop="CategoryName"
          label="所属分类"
          sortable="custom"
          width="120"
          align="center"
        />
        <el-table-column
          prop="Brand"
          label="品牌"
          sortable="custom"
          width="90"
          align="center"
        />
        <el-table-column
          prop="Weight"
          label="重量(克)"
          sortable="custom"
          width="110"
          align="center"
        >
          <template slot-scope="scope">
            <el-popover trigger="hover" placement="top">
              <p>{{ scope.row.Weight/1000 }}kg</p>
              <div slot="reference" class="name-wrapper">
                <el-tag size="medium">{{ scope.row.Weight }}</el-tag>
              </div>
            </el-popover>
          </template>
        </el-table-column>
        <el-table-column
          prop="GoodsLong"
          label="长(mm)"
          sortable="custom"
          width="100"
          align="center"
        />
        <el-table-column
          prop="GoodWidth"
          label="宽(mm)"
          sortable="custom"
          width="100"
          align="center"
        />
        <el-table-column
          prop="Height"
          label="高(mm)"
          sortable="custom"
          width="100"
          align="center"
        />
        <el-table-column
          prop="Volume"
          label="体积(cm3)"
          sortable="custom"
          width="120"
          align="center"
        >
          <template slot-scope="scope">
            <el-popover trigger="hover" placement="top">
              <p>立方米: {{ scope.row.Volume/1000000 }}</p>
              <p>立方毫米: {{ scope.row.Volume*1000 }}</p>
              <div slot="reference" class="name-wrapper">
                <el-tag size="medium">{{ scope.row.Volume }}</el-tag>
              </div>
            </el-popover>
          </template>
        </el-table-column>
        <el-table-column
          prop="Period"
          label="保质期(天)"
          sortable="custom"
          width="120"
          align="center"
        />
        <el-table-column
          prop="AllowedDays"
          label="允收天数(天)"
          sortable="custom"
          width="140"
          align="center"
        />
        <el-table-column
          prop="BillingWays"
          label="计费方式"
          sortable="custom"
          width="120"
          align="center"
        />
        <el-table-column
          prop="SingleDiskNum"
          label="码盘单层数量"
          sortable="custom"
          width="140"
          align="center"
        />
        <el-table-column
          prop="EncoderHeight"
          label="码盘层高(mm)"
          sortable="custom"
          width="140"
          align="center"
        />
        <el-table-column
          prop="IsDemolitionZero"
          label="拆零控制"
          sortable="custom"
          width="120"
          align="center"
        />
        <el-table-column
          prop="DemolitionZeroUnit"
          label="拆零单位"
          sortable="custom"
          width="120"
          align="center"
        />
        <el-table-column
          prop="DemolitionZeroNum"
          label="拆零数量"
          sortable="custom"
          width="120"
          align="center"
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
          prop="LastModifyTime"
          label="更新时间"
          sortable
          width="160"
        >
          <template slot-scope="scope">
            {{ scope.row.LastModifyTime !== null?scope.row.LastModifyTime:scope.row.CreatorTime }}
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
    </el-card>
    <el-dialog ref="dialogEditForm" :title="editFormTitle+'商品'" :visible.sync="dialogEditFormVisible" width="60%">
      <el-form ref="editFrom" :inline="true" :model="editFrom" :rules="rules">
        <el-form-item label="所属客户" :label-width="formLabelWidth" prop="OwnerCustormerId">
          <el-select v-model="editFrom.OwnerCustormerId" clearable placeholder="请选客户">
            <el-option
              v-for="item in selectCategories"
              :key="item.Id"
              :label="item.Title"
              :value="item.Id"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="商品分类" :label-width="formLabelWidth" prop="CategoryId">
          <el-select v-model="editFrom.CategoryId" clearable placeholder="请选分类">
            <el-option
              v-for="item in selectCategories"
              :key="item.Id"
              :label="item.Title"
              :value="item.Id"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="存放温层" :label-width="formLabelWidth" prop="StoreTemperatureLayer">
          <el-select v-model="editFrom.StoreTemperatureLayer" clearable placeholder="请选择">
            <el-option
              v-for="item in selectStoreTemperatureLayer"
              :key="item.Id"
              :label="item.ItemName"
              :value="item.ItemCode"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="商品编码" :label-width="formLabelWidth" prop="EnCode">
          <el-input v-model="editFrom.EnCode" placeholder="请输入商品编码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="商品名称" :label-width="formLabelWidth" prop="Title">
          <el-input v-model="editFrom.Title" placeholder="请输入商品名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="英文名称" :label-width="formLabelWidth">
          <el-input v-model="editFrom.EnTitle" placeholder="请输入英文名称" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="基本单位" :label-width="formLabelWidth" prop="BaseUnit">
          <el-select v-model="editFrom.BaseUnit" clearable placeholder="请选择">
            <el-option
              v-for="item in selectUnit"
              :key="item.Id"
              :label="item.ItemName"
              :value="item.ItemCode"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="中间单位" :label-width="formLabelWidth" prop="MiddleUnit">
          <el-select v-model="editFrom.MiddleUnit" clearable placeholder="请选择">
            <el-option
              v-for="item in selectUnit"
              :key="item.Id"
              :label="item.ItemName"
              :value="item.ItemCode"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="大单位" :label-width="formLabelWidth" prop="MaxUnit">
          <el-select v-model="editFrom.MaxUnit" clearable placeholder="请选择">
            <el-option
              v-for="item in selectUnit"
              :key="item.Id"
              :label="item.ItemName"
              :value="item.ItemCode"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="重量(克)" :label-width="formLabelWidth" prop="Weight">
          <el-input v-model.number="editFrom.Weight" placeholder="请输选择" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="价格(元)" :label-width="formLabelWidth" prop="Price">
          <el-input v-model="editFrom.Price" placeholder="请输入价格" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="客户商品编码" :label-width="formLabelWidth">
          <el-input v-model="editFrom.CustomerEnCode" placeholder="请输入客户商品编码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="商品条码" :label-width="formLabelWidth">
          <el-input v-model="editFrom.BarCode" placeholder="请输入商品条码" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="商品规格" :label-width="formLabelWidth">
          <el-input v-model="editFrom.Specs" placeholder="请输入商品规格" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="商品品牌" :label-width="formLabelWidth">
          <el-input v-model="editFrom.Brand" placeholder="请输入商品品牌" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="长(mm)" :label-width="formLabelWidth">
          <el-input v-model.number="editFrom.GoodsLong" utocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="宽(mm)" :label-width="formLabelWidth">
          <el-input v-model.number="editFrom.GoodWidth" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="高(mm)" :label-width="formLabelWidth">
          <el-input v-model.number="editFrom.Height" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="保质期(天)" :label-width="formLabelWidth">
          <el-input v-model.number="editFrom.Period" placeholder="请输入保质期" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="允收天数(天)" :label-width="formLabelWidth">
          <el-input v-model.number="editFrom.AllowedDays" placeholder="请输入允收天数" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="计费方式" :label-width="formLabelWidth">
          <el-select v-model="editFrom.BillingWays" clearable placeholder="请选择">
            <el-option
              v-for="item in selectBillingWays"
              :key="item.Id"
              :label="item.ItemName"
              :value="item.ItemCode"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="码盘单层数量" :label-width="formLabelWidth">
          <el-input v-model.number="editFrom.SingleDiskNum" placeholder="请输入码盘单层数量" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="码盘层高(mm)" :label-width="formLabelWidth">
          <el-input v-model.number="editFrom.EncoderHeight" placeholder="请输入码盘层高" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="拆零控制" :label-width="formLabelWidth">
          <el-radio-group v-model="editFrom.IsDemolitionZero">
            <el-radio label="否" />
            <el-radio label="是" />
            <el-radio label="初始" />
          </el-radio-group>
        </el-form-item>
        <el-form-item label="拆零单位" :label-width="formLabelWidth">
          <el-select v-model="editFrom.DemolitionZeroUnit" clearable placeholder="请选择">
            <el-option
              v-for="item in selectUnit"
              :key="item.Id"
              :label="item.ItemName"
              :value="item.ItemCode"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="拆零数量" :label-width="formLabelWidth">
          <el-input v-model.number="editFrom.DemolitionZeroNum" placeholder="请输入拆零数量" autocomplete="off" clearable />
        </el-form-item>
        <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
          <el-input v-model.number="editFrom.SortCode" placeholder="请输入排序,默认为99" autocomplete="off" clearable />
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
import { getListItemDetailsByCode } from '@/api/basebasic'
import { getCategoriesAlldEnabledMark, getGoodsListWithPager, getGoodsDetail, saveGoods, setGoodsEnable, deleteSoftGoods, deleteGoods } from '@/api/goods'
export default {
  data() {
    return {
      searchform: {
        CategoryId: '',
        Title: '',
        EnCode: '',
        CustomerEnCode: '',
        BarCode: ''
      },
      selectCategories: [],
      selectUnit: [],
      selectStoreTemperatureLayer: [],
      selectBillingWays: [],
      tableData: [],
      loadBtnFunc: [],
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
        Title: '',
        EnTitle: '',
        OtherTitle: '',
        EnCode: '',
        CustomerEnCode: '',
        CategoryId: '',
        OwnerCustormerId: '',
        StoreTemperatureLayer: '',
        Price: '',
        BarCode: '',
        Specs: '',
        Brand: '',
        BaseUnit: '',
        Weight: 0,
        GoodsLong: 0,
        GoodWidth: 0,
        Height: 0,
        Volume: 0,
        Period: 0,
        AllowedDays: 0,
        BillingWays: '',
        SingleDiskNum: 0,
        EncoderHeight: 0,
        IsDemolitionZero: '否',
        DemolitionZeroUnit: '',
        DemolitionZeroNum: 0,
        SortCode: 99,
        EnabledMark: 'true',
        ImgUrl: '',
        Description: ''
      },
      rules: {
        OwnerCustormerId: [
          { required: true, message: '请选择所属客户', trigger: 'blur' }
        ],
        CategoryId: [
          { required: true, message: '请选择商品分类', trigger: 'blur' }
        ],
        Title: [
          { required: true, message: '请输入商品名称', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        EnCode: [
          { required: true, message: '请输入商品编码', trigger: 'blur' },
          { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
        ],
        StoreTemperatureLayer: [
          { required: true, message: '请选择存放温层', trigger: 'blur' }
        ],
        BaseUnit: [
          { required: true, message: '请选择单位', trigger: 'blur' }
        ],
        Weight: [
          { required: true, message: '请输入重量', trigger: 'blur' }
        ]
      },
      formLabelWidth: '120px',
      currentId: '', // 当前操作对象的ID值，主要用于修改
      currentSelected: []
    }
  },
  created() {
    this.pagination.currentPage = 1
    this.InitDictItem()
    this.loadTableData()
    this.loadBtnFunc = JSON.parse(localStorage.getItem('yueboncurrentfuns'))
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem() {
      getCategoriesAlldEnabledMark().then(res => {
        this.selectCategories = res.ResData
      })
      getListItemDetailsByCode('Unit').then(res => {
        this.selectUnit = res.ResData
      })

      getListItemDetailsByCode('StoreTemperatureLayer').then(res => {
        this.selectStoreTemperatureLayer = res.ResData
      })
      getListItemDetailsByCode('BillingWays').then(res => {
        this.selectBillingWays = res.ResData
      })
    },
    /**
     * 加载页面table数据
     */
    loadTableData: function() {
      this.tableloading = true
      var seachdata = {
        'CurrentPage': this.pagination.currentPage,
        'length': this.pagination.pagesize,
        'CategoryId': this.searchform.CategoryId,
        'Keywords': this.searchform.Title,
        'EnCode': this.searchform.EnCode,
        'CustomerEnCode': this.searchform.CustomerEnCode,
        'BarCode': this.searchform.BarCode,
        'Order': this.sortableData.order,
        'Sort': this.sortableData.sort
      }
      getGoodsListWithPager(seachdata).then(res => {
        this.tableData = res.ResData.Items
        this.pagination.pageTotal = res.ResData.TotalItems
        this.tableloading = false
      })
    },
    /**
     * 点击查询
     */
    handleSearch: function() {
      this.pagination.currentPage = 1
      this.loadTableData()
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
        this.editFrom.Id = ''
        this.dialogEditFormVisible = true
        this.$refs['editFrom'].resetFields()
      }
    },
    bindEditInfo: function() {
      getGoodsDetail(this.currentId).then(res => {
        this.editFrom = Object.assign({}, res.ResData)
        this.editFrom.EnabledMark = res.ResData.EnabledMark + ''
        this.editFrom.SortCode = parseInt(res.ResData.SortCode)
        // this.editFrom.code = res.ResData.EnCode
        // this.editFrom.enable = res.ResData.EnabledMark + ''
        // this.editFrom.sortcode = parseInt(res.ResData.SortCode)
        // this.editFrom.parentId = res.ResData.ParentId
      })
    },
    /**
     * 新增/修改保存
     */
    saveEditForm() {
      this.$refs['editFrom'].validate((valid) => {
        if (valid) {
          const data = this.editFrom
          saveGoods(data).then(res => {
            if (res.Success) {
              this.$message({
                message: '恭喜你，操作成功',
                type: 'success'
              })
              this.dialogEditFormVisible = false
              this.currentSelected = ''
              this.currentId = ''
              this.editFrom.Id = ''
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
        setGoodsEnable(data).then(res => {
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
        deleteSoftGoods(data).then(res => {
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
        deleteGoods(data).then(res => {
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
    },
    /**
     * 选择每页显示数量
     */
    handleSizeChange(val) {
      this.pagination.pagesize = val
      this.pagination.currentPage = 1
      this.loadTableData()
    },
    /**
     * 选择当页面
     */
    handleCurrentChange(val) {
      this.pagination.currentPage = val
      this.loadTableData()
    }
  }
}
</script>
