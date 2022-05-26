import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 系统分页查询
   * @param {查询条件} data
   */
export function getLogListWithPager(data) {
  return http.request({
    url: 'Log/FindWithPagerSearchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取系统详情
   * @param {Id} 系统Id
   */
export function getLogDetail(id) {
  return http({
    url: 'Log/GetById',
    method: 'get',
    params: { id: id },
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteLog(data) {
  return http({
    url: 'Log/DeleteBatchAsync',
    method: 'delete',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

