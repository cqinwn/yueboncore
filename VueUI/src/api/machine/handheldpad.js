import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 仓库分页查询
   * @param {查询条件} data
   */
export function getHandheldPDAListWithPager(data) {
  return http.request({
    url: 'HandheldPDA/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveHandheldPDA(data) {
  return http.request({
    url: 'HandheldPDA/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} 商品Id
   */
export function getHandheldPDADetail(id) {
  return http({
    url: 'HandheldPDA/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setHandheldPDAEnable(data) {
  return http({
    url: 'HandheldPDA/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftHandheldPDA(data) {
  return http({
    url: 'HandheldPDA/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteHandheldPDA(data) {
  return http({
    url: 'HandheldPDA/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
