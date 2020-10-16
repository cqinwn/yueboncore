import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 获取功能菜单
   * @param {查询条件} data
   */
export function getAllItemsTreeTable () {
  return http.request({
    url: 'Items/GetAllItemsTreeTable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveItems (data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} Id
   */
export function getItemsDetail (id) {
  return http({
    url: 'Items/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setItemsEnable (data) {
  return http({
    url: 'Items/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftItems (data) {
  return http({
    url: 'Items/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteItems (data) {
  return http({
    url: 'Items/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 查询所有可用的
   * @param {查询条件} data
   */
export function getItemsAllEnable () {
  return http.request({
    url: 'Items/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 获取功能菜单
   * @param {查询条件} data
   */
export function getItemsDetailListWithPager (data) {
  return http.request({
    url: 'ItemsDetail/GetAllItemsDetailTreeTable',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveItemsDetail (data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} Id
   */
export function getItemsDetailDetail (id) {
  return http({
    url: 'ItemsDetail/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setItemsDetailEnable (data) {
  return http({
    url: 'ItemsDetail/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftItemsDetail (data) {
  return http({
    url: 'ItemsDetail/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteItemsDetail (data) {
  return http({
    url: 'ItemsDetail/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 查询所有可用的
   * @param {查询条件} data
   */
export function getItemsDetailAllEnable () {
  return http.request({
    url: 'ItemsDetail/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
 * 根据子系统查询所有功能
 * @param {} data
 */
export function getAllItemsDetailTreeTable (data) {
  return http.request({
    url: 'ItemsDetail/GetAllItemsDetailTreeTable',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
