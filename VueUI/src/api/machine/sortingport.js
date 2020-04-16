import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function getSortingPortListWithPager(data) {
  return http.request({
    url: 'SortingPort/FindWithPagerBySearchAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveSortingPort(data) {
  return http.request({
    url: 'SortingPort/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} 商品Id
   */
export function getSortingPortDetail(id) {
  return http({
    url: 'SortingPort/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setSortingPortEnable(data) {
  return http({
    url: 'SortingPort/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftSortingPort(data) {
  return http({
    url: 'SortingPort/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteSortingPort(data) {
  return http({
    url: 'SortingPort/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
