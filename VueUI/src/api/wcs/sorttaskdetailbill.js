/**
 * 分拣机分拣明细
 */
import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function getSortingTaskDetailBillListWithPager(data) {
  return http.request({
    url: 'SortingTaskDetailBill/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftSortingTaskDetailBill(data) {
  return http({
    url: 'SortingTaskDetailBill/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteSortingTaskDetailBill(data) {
  return http({
    url: 'SortingTaskDetailBill/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
