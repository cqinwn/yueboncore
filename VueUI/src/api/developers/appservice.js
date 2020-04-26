import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 应用分页查询
   * @param {查询条件} data
   */
export function getAPPListWithPager(data) {
  return http.request({
    url: 'APP/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}/**
   * 获取所有可用的应用
   */
export function getAllAPPList() {
  return http.request({
    url: 'APP/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存应用
   * @param data
   */
export function saveAPP(data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取应用详情
   * @param {Id} 应用Id
   */
export function getAPPDetail(id) {
  return http({
    url: 'APP/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setAPPEnable(data) {
  return http({
    url: 'APP/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftAPP(data) {
  return http({
    url: 'APP/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteAPP(data) {
  return http({
    url: 'APP/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
 * 重置应用密钥
 * @param {id} data
 */
export function resetAppSecret(data) {
  return http({
    url: 'APP/ResetAppSecret',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}

/**
 * 重置消息加密密钥
 * @param {id} data
 */
export function resetEncodingAESKey(data) {
  return http({
    url: 'APP/ResetEncodingAESKey',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
