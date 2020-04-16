import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function getOutStockListWithPager(data) {
  return http.request({
    url: 'OutStock/FindWithPagerBySearchAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveOutStock(data) {
  return http.request({
    url: 'OutStock/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} 商品Id
   */
export function getOutStockDetail(id) {
  return http({
    url: 'OutStock/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setOutStockEnable(data) {
  return http({
    url: 'OutStock/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftOutStock(data) {
  return http({
    url: 'OutStock/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteOutStock(data) {
  return http({
    url: 'OutStock/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
 * 按单整单批量下推分拣单
 * @param {id集合} ids
 */
export function pushDownSortingBill(data) {
  return http({
    url: 'OutStock/PushSortingBillByOrder',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
 * 按客户下推分拣单
 * @param {id集合} ids
 */
export function SortingBillByCustomer(data) {
  return http({
    url: 'OutStock/PushSortingBillByCustomer',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量导出excel
   * @param data
   */
export function OutStockBillExportExcel(data) {
  return http.request({
    url: 'OutStock/OutStockBillExportExcel',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 打印明细
   * @param data
   */
export function PrintOutStockDetail(data) {
  return http.request({
    url: 'OutStock/PrintOutStockDetail',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
