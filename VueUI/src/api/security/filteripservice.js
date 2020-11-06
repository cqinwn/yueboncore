import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 系统分页查询
   * @param {查询条件} data
   */
export function getFilterIPListWithPager (data) {
  return http.request({
    url: 'FilterIP/FindWithPagerAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}/**
   * 获取所有可用的系统
   */
export function getAllFilterIPList () {
  return http.request({
    url: 'FilterIP/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存系统
   * @param data
   */
export function saveFilterIP (data, url) {
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
export function getFilterIPDetail (id) {
  return http({
    url: 'FilterIP/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setFilterIPEnable (data) {
  return http({
    url: 'FilterIP/SetEnabledMarktBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftFilterIP (data) {
  return http({
    url: 'FilterIP/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteFilterIP (data) {
  return http({
    url: 'FilterIP/DeleteBatchAsync',
    method: 'delete',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

