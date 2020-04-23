import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 角色分页查询
   * @param {查询条件} data
   */
export function getRoleListWithPager(data) {
  return http.request({
    url: 'Role/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}/**
   * 获取所有可用的角色
   */
export function getAllRoleList() {
  return http.request({
    url: 'Role/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存角色
   * @param data
   */
export function saveRole(data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取角色详情
   * @param {Id} 角色Id
   */
export function getRoleDetail(id) {
  return http({
    url: 'Role/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setRoleEnable(data) {
  return http({
    url: 'Role/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftRole(data) {
  return http({
    url: 'Role/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteRole(data) {
  return http({
    url: 'Role/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}

/**
 *获取功能菜单树
 * @param {roleId:角色Id} data
 */
export function getAllFunctionTree() {
  return http({
    url: 'RoleAuthorize/GetAllFunctionTree',
    method: 'get',
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
 *获取功能菜单树
 * @param {roleId:角色Id} data
 */
export function getRoleAuthorizeFunction(data) {
  return http({
    url: 'RoleAuthorize/GetRoleAuthorizeFunction',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
 * 保存角色权限
 * @param {} data
 */
export function saveRoleAuthorize(data) {
  return http.request({
    url: 'RoleAuthorize/SaveRoleAuthorize',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
