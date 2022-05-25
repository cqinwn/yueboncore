import { createI18n } from "vue-i18n";
import Cookies from 'js-cookie'

import elementEnLocale from 'element-plus/es/locale/lang/en' // element-plus lang
import elementZhLocale from 'element-plus/es/locale/lang/zh-cn'// element-plus lang

import zhLocale from "./zh";
import enLocale from "./en.js";

const messages = {
    en: {
        ...enLocale,
        ...elementEnLocale
    },
    zh: {
        ...zhLocale,
        ...elementZhLocale
    }
}

export function getLanguage() {
    const chooseLanguage = Cookies.get('language')
    if (chooseLanguage) return chooseLanguage

    // if has not choose language
    const language = (navigator.language || navigator.browserLanguage).toLowerCase()
    const locales = Object.keys(messages)
    for (const locale of locales) {
        if (language.indexOf(locale) > -1) {
            return locale
        }
    }
    return 'zh'
}

const i18n = createI18n({
    globalInjection: true,//在全局注入
    legacy: false,
    silentFallbackWarn: true,//抑制警告
    locale: getLanguage(),//localStorage.getItem("lang") || "zh",
    messages
});

export default i18n;