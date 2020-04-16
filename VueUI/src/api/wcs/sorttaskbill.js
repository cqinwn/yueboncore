import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function getSortingTaskBillListWithPager(data) {
  return http.request({
    url: 'SortingTaskBill/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveSortingTaskBill(data) {
  return http.request({
    url: 'SortingTaskBill/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} 商品Id
   */
export function getSortingTaskBillDetail(id) {
  return http({
    url: 'SortingTaskBill/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setSortingTaskBillEnable(data) {
  return http({
    url: 'SortingTaskBill/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftSortingTaskBill(data) {
  return http({
    url: 'SortingTaskBill/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteSortingTaskBill(data) {
  return http({
    url: 'SortingTaskBill/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
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
