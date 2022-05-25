<template>
  <el-dropdown trigger="click" class="international" @command="handleSetLanguage">
    <div class="size-icon--style">
      <svg-icon class-name="international-icon" icon-class="language" />
    </div>
    <template #dropdown>
    <el-dropdown-menu>      
      <el-dropdown-item :disabled="language==='zh'" command="zh">
        中文
      </el-dropdown-item>
      <el-dropdown-item :disabled="language==='en'" command="en">
        English
      </el-dropdown-item>
      <el-dropdown-item :disabled="language==='es'" command="es">
        Español
      </el-dropdown-item>
      <el-dropdown-item :disabled="language==='ja'" command="ja">
        日本語
      </el-dropdown-item>
    </el-dropdown-menu>
    </template>
  </el-dropdown>
</template>

<script setup>

const store = useStore();
const {proxy} = getCurrentInstance();
const language = computed(() => store.getters.language);
function handleSetLanguage(language) {
  store.dispatch('app/setLanguage', language)
  proxy.$i18n.locale = language
  proxy.$modal.msgSuccess("Switch Language Success");
}
</script>

<style lang='scss' scoped>
.size-icon--style {
  font-size: 18px;
  line-height: 50px;
  padding-right: 7px;
}
</style>