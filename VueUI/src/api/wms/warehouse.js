import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 仓库分页查询
   * @param {查询条件} data
   */
export function getWarehouseListWithPager(data) {
  return http.request({
    url: 'Warehouse/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存商品
   * @param data
   */
export function saveWarehouse(data) {
  return http.request({
    url: 'Warehouse/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} Id
   */
export function getWarehouseDetail(id) {
  return http({
    url: 'Warehouse/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setWarehouseEnable(data) {
  return http({
    url: 'Warehouse/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftWarehouse(data) {
  return http({
    url: 'Warehouse/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteWarehouse(data) {
  return http({
    url: 'Warehouse/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 查询所有可用的仓库
   * @param {查询条件} data
   */
export function getWarehouseAllEnable() {
  return http.request({
    url: 'Warehouse/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
