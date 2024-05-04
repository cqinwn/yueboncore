import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 租户分页查询
   * @param {查询条件} data
   */
export function getTenantListWithPager (data) {
  return http.request({
    url: 'Tenants/Tenant/FindWithPagerAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}/**
   * 获取所有可用的租户
   */
export function getAllTenantList () {
  return http.request({
    url: 'Tenants/Tenant/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存租户
   * @param data
   */
export function saveTenant (data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取租户详情
   * @param {Id} 租户Id
   */
export function getTenantDetail (id) {
  return http({
    url: 'Tenants/Tenant/GetById',
    method: 'get',
    params: { id: id },
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 初始化租户数据
   * @param {Id} 租户Id
   */
export function initTenantData (id) {
  return http({
    url: 'Tenants/Tenant/InitTenantData',
    method: 'get',
    params: { tenantId: id },
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setTenantEnable (data) {
  return http({
    url: 'Tenants/Tenant/SetEnabledMarktBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftTenant (data) {
  return http({
    url: 'Tenants/Tenant/DeleteSoftBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteTenant (data) {
  return http({
    url: 'Tenants/Tenant/DeleteBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}

/**
   * 注册新用户
   * @param data
   */
export function registerUser (data, url) {
  return http.request({
    url: 'Tenants/Tenant/Register',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}