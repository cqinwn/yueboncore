import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * SQL日志分页查询
   * @param {查询条件} data
   */
export function getSqlLogListWithPager (data) {
  return http.request({
    url: 'SqlLog/FindWithPagerAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteSqlLog (data) {
  return http({
    url: 'SqlLog/DeleteBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
