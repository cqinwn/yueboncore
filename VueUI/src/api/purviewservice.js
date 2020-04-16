import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function getMenuListWithPager(data) {
  return http.request({
    url: 'Menu/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存商品
   * @param data
   */
export function saveMenu(data) {
  return http.request({
    url: 'Menu/InsertOrUpdateAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取商品详情
   * @param {Id} 商品Id
   */
export function getMenuDetail(id) {
  return http({
    url: 'Menu/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setMenuEnable(data) {
  return http({
    url: 'Menu/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftMenu(data) {
  return http({
    url: 'Menu/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteMenu(data) {
  return http({
    url: 'Menu/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
