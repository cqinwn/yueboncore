import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 系统分页查询
   * @param {查询条件} data
   */
export function getSystemTypeListWithPager(data) {
  return http.request({
    url: 'SystemType/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}/**
   * 获取所有可用的系统
   */
export function getAllSystemTypeList() {
  return http.request({
    url: 'SystemType/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存系统
   * @param data
   */
export function saveSystemType(data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取系统详情
   * @param {Id} 系统Id
   */
export function getSystemTypeDetail(id) {
  return http({
    url: 'SystemType/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setSystemTypeEnable(data) {
  return http({
    url: 'SystemType/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftSystemType(data) {
  return http({
    url: 'SystemType/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteSystemType(data) {
  return http({
    url: 'SystemType/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

