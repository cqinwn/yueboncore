import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function getSortingBillListWithPager(data) {
  return http.request({
    url: 'SortingBill/FindWithPagerBySearchAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveSortingBill(data) {
  return http.request({
    url: 'SortingBill/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} 商品Id
   */
export function getSortingBillDetail(id) {
  return http({
    url: 'SortingBill/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setSortingBillEnable(data) {
  return http({
    url: 'SortingBill/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftSortingBill(data) {
  return http({
    url: 'SortingBill/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteSortingBill(data) {
  return http({
    url: 'SortingBill/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
 * 按单下推分拣任务
 * @param {id集合} ids
 */
export function pushOrderSortingTask(data) {
  return http({
    url: 'SortingTaskBill/PushOrderSortingTask',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}

/**
   * 打印明细
   * @param data
   */
export function PrintSortingBillDetail(data) {
  return http.request({
    url: 'SortingBill/PrintSortingBillDetail',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量导出excel
   * @param data
   */
export function SortingBillExportExcel(data) {
  return http.request({
    url: 'SortingBill/SortingBillExportExcel',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * PackingList处理
   * @param data
   */
export function PackingListTrace(data) {
  return http.request({
    url: 'PackingList/PackingListTrace',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 装箱签打印
   * @param data
   */
export function PrintSortingBillTab(data) {
  return http.request({
    url: 'SortingBill/PrintSortingBillTab',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
