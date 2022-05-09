<template>
  <div>
    <el-form ref="editFromRef" :model="editFrom" :rules="rules">
      <el-row>
        <el-col :span="12">
          <el-form-item label="文章标题" :label-width="formLabelWidth" prop="Title">
            <slot v-if="showType==='show'">{{ editFrom.Title }}</slot>
            <el-input v-else v-model="editFrom.Title" placeholder="请输入文章标题" autocomplete="off" clearable />
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="副标题" :label-width="formLabelWidth" prop="SubTitle">
            <slot v-if="showType==='show'">{{ editFrom.SubTitle }}</slot>
            <el-input v-else v-model="editFrom.SubTitle" placeholder="请输入文章副标题" autocomplete="off" clearable />
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="文章分类" :label-width="formLabelWidth" prop="CategoryId">
            <slot v-if="showType==='show'">{{ editFrom.CategoryName }}</slot>
            <el-cascader
              v-else
              v-model="selectedCategoryOptions"
              style="width: 380px"
              :options="selectCategory"
              filterable
              :props="{
                label: 'Title',
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
            <slot v-if="showType==='show'">{{ editFrom.LinkUrl }}</slot>
            <el-input v-else v-model="editFrom.LinkUrl" placeholder="请输入外部链接" autocomplete="off" clearable />
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="排序" :label-width="formLabelWidth" prop="SortCode">
            <slot v-if="showType==='show'">{{ editFrom.SortCode }}</slot>
            <el-input v-else v-model="editFrom.SortCode" placeholder="请输入排序" autocomplete="off" clearable />
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="属性" :label-width="formLabelWidth" prop="">
            <el-tag v-if="showType==='show' &&editFrom.IsTop">置顶</el-tag>
            <slot v-else-if="showType==='show' &&!editFrom.IsTop" />
            <el-checkbox v-else v-model="editFrom.IsTop">置顶</el-checkbox>
            <el-tag v-if="showType==='show' &&editFrom.IsHot">热门</el-tag>
            <el-tag v-else-if="showType==='show' &&!editFrom.IsHot" />
            <el-checkbox v-else v-model="editFrom.IsHot">热门</el-checkbox>
            <el-tag v-if="showType==='show' &&editFrom.IsRed">推荐</el-tag>
            <slot v-else-if="showType==='show' &&!editFrom.IsRed" />
            <el-checkbox v-else v-model="editFrom.IsRed">推荐</el-checkbox>
            <el-tag v-if="showType==='show' &&editFrom.IsNew">最新</el-tag>
            <slot v-else-if="showType==='show' &&!editFrom.IsNew" />
            <el-checkbox v-else v-model="editFrom.IsNew">最新</el-checkbox>
          </el-form-item>
        </el-col>
        <el-col :span="24">
          <el-form-item label="详情" :label-width="formLabelWidth" prop="Description">
            <div v-if="showType==='show'" v-html="editFrom.Description" />
            <Tinymce v-else ref="editorDescription" v-model="editFrom.Description" />
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="是否发布" :label-width="formLabelWidth" prop="EnabledMark">
            <slot v-if="showType==='show' &&editFrom.EnabledMark">是</slot>
            <slot v-else-if="showType==='show' &&!editFrom.EnabledMark">否</slot>
            <el-radio-group v-else v-model="editFrom.EnabledMark">
              <el-radio :label="true">是</el-radio>
              <el-radio :label="false">否</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
      </el-row>
    </el-form>
    <div v-if="showType!=='show'" class="yuebon-page-footer">
      <el-button @click="reset">重置</el-button>
      <el-button type="primary" @click="saveEditForm">保存</el-button>
    </div>
  </div>
</template>

<script setup name="ArticleDetail">
import { getArticlenewsDetail, saveArticlenews } from '@/api/cms/articlenews'
import { GetAllCategoryTreeTable } from '@/api/cms/articlecategory'
import Tinymce from '@/components/Tinymce'
import store from '@/store'
const { proxy } = getCurrentInstance()
const route = useRoute()

const formLabelWidth=ref("100px")
const currentId=ref("")// 当前操作对象的ID值，主要用于修改
const showType=ref('edit')

const selectedCategoryOptions=ref('')
const selectCategory=ref([])
const data = reactive({
  editFrom: {
      Description: '',
  },
  rules: {
    CategoryId: [
      { required: true, message: '请输入文章分类', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ],
    Title: [
      { required: true, message: '请输入文章标题', trigger: 'blur' },
      { min: 2, max: 50, message: '长度在 2 到 50 个字符', trigger: 'blur' }
    ]
  }
})
const {editFrom, rules } = toRefs(data)

/**
 * 初始化数据
 */
function InitDictItem() {
  GetAllCategoryTreeTable().then(res => {
    selectCategory.value = res.ResData
  })
  reset()
  if (route.params && route.params.id && route.params.id !== 'null') {
    currentId.value = route.params.id
    showType.value = route.params.showtype
    bindEditInfo()
  }
}

/**
 * 选择分类
 */
function handleSelectCategoryChange() {
  editFrom.value.CategoryId = selectedCategoryOptions.value
}

// 表单重置
function reset() {
  if (!currentId.value) {
    editFrom.value = {
      CategoryId: '',
      Title: '',
      Description: '',
      SortCode: 99,
      EnabledMark: true
    }
    selectedCategoryOptions.value = ''
    proxy.resetForm('editFromRef')
  } else {
    bindEditInfo()
  }
}
function bindEditInfo() {
  getArticlenewsDetail(currentId.value).then(res => {
    editFrom.value=res.ResData
    selectedCategoryOptions.value = res.ResData.CategoryId
        editFrom.value.Description=res.ResData.Description    
  })

}
/**
 * 新增/修改保存
 */
function saveEditForm() {
  proxy.$refs['editFromRef'].validate((valid) => {
    if (valid) {
      var url = 'Articlenews/Insert'
      if (currentId.value !== '') {
        url = 'Articlenews/Update'
      }
      saveArticlenews(editFrom.value, url).then(res => {
        if (res.Success) {
          proxy.$modal.msgSuccess('恭喜你，操作成功')
          store.state.tagsView.visitedViews.splice(store.state.tagsView.visitedViews.findIndex(item => item.path === route.path), 1)
          proxy.$router.push(store.state.tagsView.visitedViews[store.state.tagsView.visitedViews.length - 1].path)
        } else {
          proxy.$modal.msgError(res.ErrMsg)
        }
      })
    } else {
      return false
    }
  })
}
InitDictItem()
</script>
<style lang="scss" scoped>
.yuebon-page-footer{
    padding: 10px 20px 20px;
    text-align: right;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    & button{
        margin-right: 10px;
    }
}
</style>
