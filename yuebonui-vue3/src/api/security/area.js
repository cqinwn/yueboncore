import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 地区信息分页查询
   * @param {查询条件} data
   */
export function getAreaListWithPager (data) {
  return http.request({
    url: 'Area/FindWithPagerAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取所有可用的地区信息
   */
export function getAllAreaList () {
  return http.request({
    url: 'Area/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存地区信息
   * @param data
   */
export function saveArea (data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取地区信息详情
   * @param {Id} 地区信息Id
   */
export function getAreaDetail (id) {
  return http({
    url: 'Area/GetById',
    method: 'get',
    params: { id: id },
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setAreaEnable (data) {
  return http({
    url: 'Area/SetEnabledMarktBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftArea (data) {
  return http({
    url: 'Area/DeleteSoftBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteArea (data) {
  return http({
    url: 'Area/DeleteBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
 * 采集高德地区地区数据
 * @returns 
 */
export function collectGaodeData () {
  return http({
    url: 'Area/CollectData',
    method: 'post',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/***
 * 获取行政区划 Vue树形
 */
export function getAllAreaTreeTable () {
  return http.request({
    url: 'Area/getAllAreaTreeTable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

export function getAllSubAreaByParentId (parentId) {
  return http.request({
    url: 'Area/GetAllSubAreaByParentId',
    method: 'get',
    params: { parentId: parentId },
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}