import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function GetAllCategoryTreeTable(data) {
  return http.request({
    url: 'Articlecategory/GetAllCategoryTreeTable',
    method: 'get',
    params: data,
    headers: { sign: false },
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取所有可用的
   */
export function getAllArticlecategoryList() {
  return http.request({
    url: 'Articlecategory/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveArticlecategory(data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} Id
   */
export function getArticlecategoryDetail(id) {
  return http({
    url: 'Articlecategory/GetById',
    method: 'get',
    params: { id: id },
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setArticlecategoryEnable(data) {
  return http({
    url: 'Articlecategory/SetEnabledMarktBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftArticlecategory(data) {
  return http({
    url: 'Articlecategory/DeleteSoftBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteArticlecategory(data) {
  return http({
    url: 'Articlecategory/DeleteBatchAsync',
    method: 'delete',
    data: data,
    baseURL: defaultSettings.apiCMSUrl // 直接通过覆盖的方式
  })
}
