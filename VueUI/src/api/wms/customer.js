import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 仓库分页查询
   * @param {查询条件} data
   */
export function getCustomerListWithPager(data) {
  return http.request({
    url: 'Customer/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存商品
   * @param data
   */
export function saveCustomer(data) {
  return http.request({
    url: 'Customer/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} Id
   */
export function getCustomerDetail(id) {
  return http({
    url: 'Customer/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setCustomerEnable(data) {
  return http({
    url: 'Customer/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftCustomer(data) {
  return http({
    url: 'Customer/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteCustomer(data) {
  return http({
    url: 'Customer/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 查询所有可用的仓库
   * @param {查询条件} data
   */
export function getCustomerAllEnable() {
  return http.request({
    url: 'Customer/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
