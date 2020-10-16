import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
 * 获取树形组织机构
*/
export function getAllOrganizeTreeTable () {
  return http.request({
    url: 'Organize/GetAllOrganizeTreeTable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 角色分页查询
   * @param {查询条件} data
   */
export function getOrganizeListWithPager (data) {
  return http.request({
    url: 'Organize/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存角色
   * @param data
   */
export function saveOrganize (data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取角色详情
   * @param {Id} 角色Id
   */
export function getOrganizeDetail (id) {
  return http({
    url: 'Organize/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setOrganizeEnable (data) {
  return http({
    url: 'Organize/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftOrganize (data) {
  return http({
    url: 'Organize/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteOrganize (data) {
  return http({
    url: 'Organize/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

