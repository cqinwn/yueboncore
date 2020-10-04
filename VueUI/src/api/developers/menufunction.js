import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 获取功能菜单
   * @param {查询条件} data
   */
export function getAllMenuTreeTable(data) {
  return http.request({
    url: 'Menu/GetAllMenuTreeTable',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveMenu(data, url) {
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
export function getMenuDetail(id) {
  return http({
    url: 'Menu/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setMenuEnable(data) {
  return http({
    url: 'Menu/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftMenu(data) {
  return http({
    url: 'Menu/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteMenu(data) {
  return http({
    url: 'Menu/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 查询所有可用的
   * @param {查询条件} data
   */
export function getMenuAllEnable() {
  return http.request({
    url: 'Menu/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 获取功能菜单
   * @param {查询条件} data
   */
export function getFunctionListWithPager(data) {
  return http.request({
    url: 'Function/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveFunction(data, url) {
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
export function getFunctionDetail(id) {
  return http({
    url: 'Function/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setFunctionEnable(data) {
  return http({
    url: 'Function/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftFunction(data) {
  return http({
    url: 'Function/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteFunction(data) {
  return http({
    url: 'Function/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 查询所有可用的
   * @param {查询条件} data
   */
export function getFunctionAllEnable() {
  return http.request({
    url: 'Function/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
 * 根据子系统查询所有功能
 * @param {} data
 */
export function getAllFunctionTreeTable(data) {
  return http.request({
    url: 'Function/GetAllFunctionTreeTable',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
