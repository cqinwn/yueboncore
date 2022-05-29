
import i18n from '@/lang/index'
// translate router.meta.title, be used in breadcrumb sidebar tagsview
export function generateTitle(title) {
  const hasKey = i18n.global.t('route.' + title)

  if (hasKey) {
    // $t :this method from vue-i18n, inject in @/lang/index.js
    const translatedTitle = i18n.global.t('route.' + title)

    return translatedTitle
  }
  return title
}