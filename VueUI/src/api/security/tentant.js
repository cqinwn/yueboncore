import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 租户分页查询
   * @param {查询条件} data
   */
export function getTentantListWithPager (data) {
  return http.request({
    url: 'Tentant/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}/**
   * 获取所有可用的租户
   */
export function getAllTentantList () {
  return http.request({
    url: 'Tentant/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存租户
   * @param data
   */
export function saveTentant (data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取租户详情
   * @param {Id} 租户Id
   */
export function getTentantDetail (id) {
  return http({
    url: 'Tentant/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setTentantEnable (data) {
  return http({
    url: 'Tentant/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftTentant (data) {
  return http({
    url: 'Tentant/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteTentant (data) {
  return http({
    url: 'Tentant/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
