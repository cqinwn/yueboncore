/**
 * 打包装作业
 */
import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function getPackingListListWithPager(data) {
  return http.request({
    url: 'PackingList/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
