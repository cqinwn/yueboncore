<template>
    <editor :api-key="apiKey" v-model="state.contentValue" :init="initOptions" @onClick="onClick" />
</template>

<script setup>
import tinymce from "tinymce/tinymce";
import Editor from "@tinymce/tinymce-vue";
import { autoResetRef } from "@vueuse/core";
import "tinymce/themes/silver/theme"; // 引用主题文件
import "tinymce/icons/default"; // 引用图标文件
import 'tinymce/models/dom'
import "tinymce/plugins/link";
import "tinymce/plugins/code";
import "tinymce/plugins/table";
import "tinymce/plugins/lists";
import "tinymce/plugins/advlist";
import "tinymce/plugins/anchor";
import "tinymce/plugins/autolink"; //锚点
import "tinymce/plugins/autoresize";
import "tinymce/plugins/autosave";
import "tinymce/plugins/charmap"; //特殊字符
import "tinymce/plugins/code"; //查看源码
import "tinymce/plugins/codesample"; //插入代码
import "tinymce/plugins/directionality"; //
import "tinymce/plugins/fullscreen"; //全屏
import "tinymce/plugins/help"; //帮助
import "tinymce/plugins/image"; //图片
import "tinymce/plugins/importcss"; //图片工具
import "tinymce/plugins/insertdatetime"; //时间插入
import "tinymce/plugins/media"; //媒体插入
import "tinymce/plugins/nonbreaking"; //
import "tinymce/plugins/pagebreak"; //分页
import "tinymce/plugins/preview"; //预览
import "tinymce/plugins/quickbars"; //快捷菜单
import "tinymce/plugins/save"; //保存
import "tinymce/plugins/searchreplace"; //查询替换
import "tinymce/plugins/template"; //插入模板
import "tinymce/plugins/visualblocks"; //
import "tinymce/plugins/visualchars"; //
import "tinymce/plugins/wordcount"; //数字统计
import { reactive, watch, ref, onMounted } from 'vue';
const props = defineProps({
    value: {
        type: String,
        defaul:""
    }
})
const apiKey = "qagffr3pkuv17a8on1afax661irst1hbr4e6tbv888sz91jc";
const state = reactive({
    contentValue: props.value,
});
const initOptions = ref({
    language_url: "/tinymce/langs/zh_CN.js", // 中文语言包路径
    language: "zh_CN",
    skin_url: '/tinymce/skins/ui/oxide',
    content_css: "/tinymce/skins/content/default/",
    plugins:
        "wordcount visualchars visualblocks template preview pagebreak nonbreaking media insertdatetime importcss image help fullscreen directionality codesample code charmap link code table lists advlist anchor autolink autoresize autosave", // 插件需要import进来
    toolbar:
        "formats undo redo paste fontsizeselect fontselect template |wordcount ltr rtl visualchars visualblocks searchreplace|save preview pagebreak nonbreaking|media image|outdent indent aligncenter alignleft alignright alignjustify lineheight  underline quicklink h2 h3 blockquote numlist bullist table removeformat forecolor backcolor bold italic  strikethrough charmap link insertdatetime|subscript superscript cut codesample code |anchor preview fullscreen|help",
    fontsize_formats: "12px 14px 16px 18px 24px 36px 48px 56px 72px",
    font_formats:
        "微软雅黑=Microsoft YaHei,Helvetica Neue,PingFang SC,sans-serif;苹果苹方=PingFang SC,Microsoft YaHei,sans-serif;宋体=simsun,serif;仿宋体=FangSong,serif;黑体=SimHei,sans-serif;Arial=arial,helvetica,sans-serif;Arial Black=arial black,avant garde;Book Antiqua=book antiqua,palatino;",
    menubar: true, // 隐藏菜单栏
    autoresize_bottom_margin: 50,
    max_height: 500,
    branding: false,
    toolbar_mode: "none",
    // 初始化完成
    init_instance_callback: (editor) => {
    },
    //   图片上传,修正图片上传错误
    images_upload_handler: blobInfo => new Promise((resolve, reject) => {
        const formData = new FormData()
        formData.append('file', blobInfo.blob())
        //改成自己的图片上传api
        uploadTalent(formData).then(res => {
            resolve(baseUrl + res.ResData.FilePath)
        }).catch(err => {
            reject(res.ErrMsg)
        })
    }),
})
const emits = defineEmits(['input', 'onClick'])
const onClick = (e) => {
    emits('onClick', e, tinymce);
}

onMounted(() => {
    tinymce.init({})
})
watch(
    () => props.value,
    (newValue) => {
        state.contentValue = newValue;
    }
)
watch(
    () => state.contentValue,
    (newValue) => {
        emits('input', newValue);
    }
)
</script>