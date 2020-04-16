import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function getSortingMachineListWithPager(data) {
  return http.request({
    url: 'SortingMachine/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}

/**
   * 查询所有可用的机器
   * @param {查询条件} data
   */
export function getSortingMachineAllEnable() {
  return http.request({
    url: 'SortingMachine/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveSortingMachine(data) {
  return http.request({
    url: 'SortingMachine/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} 商品Id
   */
export function getSortingMachineDetail(id) {
  return http({
    url: 'SortingMachine/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setSortingMachineEnable(data) {
  return http({
    url: 'SortingMachine/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftSortingMachine(data) {
  return http({
    url: 'SortingMachine/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteSortingMachine(data) {
  return http({
    url: 'SortingMachine/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
