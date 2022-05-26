<template>
  <el-config-provider :locale="locale">
    <router-view />
  </el-config-provider>
</template>
<script setup>
import i18n from "./lang/index.js";//本地化语言
// 导入 Element Plus 语言包
import zhCn from 'element-plus/es/locale/lang/zh-cn';
import en from 'element-plus/es/locale/lang/en';
const store = useStore();
const locale = ref()
const language = computed(() => store.getters.language);
watch(
  language,
  value => {
    locale.value = value == 'en' ? en : zhCn;
  },
  {
    // 初始化立即执行
    immediate: true
  }
)
</script>
