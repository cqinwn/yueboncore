import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 文章，通知公告分页查询
   * @param {查询条件} data
   */
export function getArticlenewsListWithPager(data) {
  return http.request({
    url: 'Articlenews/FindWithPagerAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}/**
   * 获取所有可用的文章，通知公告
   */
export function getAllArticlenewsList() {
  return http.request({
    url: 'Articlenews/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存文章，通知公告
   * @param data
   */
export function saveArticlenews(data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取文章，通知公告详情
   * @param {Id} 文章，通知公告Id
   */
export function getArticlenewsDetail(id) {
  return http({
    url: 'Articlenews/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setArticlenewsEnable(data) {
  return http({
    url: 'Articlenews/SetEnabledMarktBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftArticlenews(data) {
  return http({
    url: 'Articlenews/DeleteSoftBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteArticlenews(data) {
  return http({
    url: 'Articlenews/DeleteBatchAsync',
    method: 'delete',
    data: data,
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
