import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 系统分页查询
   * @param {查询条件} data
   */
export function getUploadFileListWithPager (data) {
  return http.request({
    url: 'UploadFile/FindWithPagerAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteUploadFile (data) {
  return http({
    url: 'UploadFile/DeleteBatchAsync',
    method: 'delete',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

