import { createI18n } from "vue-i18n";
import zh from "./zh";
import en from "./en.js";

const i18n = createI18n({
    globalInjection: true,//在全局注入
    legacy: false,
    silentFallbackWarn: true,//抑制警告
    locale: localStorage.getItem("lang") || "zh",
    messages: {
        zh,
        en
    },
});

export default i18n;