import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 仓库分页查询
   * @param {查询条件} data
   */
export function getTurnoverBoxListWithPager(data) {
  return http.request({
    url: 'TurnoverBox/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveTurnoverBox(data) {
  return http.request({
    url: 'TurnoverBox/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} 商品Id
   */
export function getTurnoverBoxDetail(id) {
  return http({
    url: 'TurnoverBox/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setTurnoverBoxEnable(data) {
  return http({
    url: 'TurnoverBox/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftTurnoverBox(data) {
  return http({
    url: 'TurnoverBox/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteTurnoverBox(data) {
  return http({
    url: 'TurnoverBox/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWCSUrl // 直接通过覆盖的方式
  })
}
