import http from '@/utils/request'
import defaultSettings from '@/settings'

export function getCategoriesAlldEnabledMark() {
  return http({
    url: 'GoodsCategories/GetAlldEnabledMark',
    method: 'get',
    baseURL: defaultSettings.apiWMSUrl// 直接通过覆盖的方式
  })
}
export function getCategoriesDetail(id) {
  return http({
    url: 'GoodsCategories/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 保存分类
   * @param data
   */
export function saveCategories(data) {
  return http.request({
    url: 'GoodsCategories/InsertOrUpdateAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setCategoriesEnable(data) {
  return http({
    url: 'GoodsCategories/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftCategories(data) {
  return http({
    url: 'GoodsCategories/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteCategories(data) {
  return http({
    url: 'GoodsCategories/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 分页查询
   * @param {查询条件} data
   */
export function getListWithPager(data) {
  return http.request({
    url: 'GoodsCategories/FindWithPager1Async',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 商品分页查询
   * @param {查询条件} data
   */
export function getGoodsListWithPager(data) {
  return http.request({
    url: 'Goods/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存商品
   * @param data
   */
export function saveGoods(data) {
  return http.request({
    url: 'Goods/InsertOrUpdateAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取商品详情
   * @param {Id} 商品Id
   */
export function getGoodsDetail(id) {
  return http({
    url: 'Goods/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setGoodsEnable(data) {
  return http({
    url: 'Goods/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftGoods(data) {
  return http({
    url: 'Goods/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteGoods(data) {
  return http({
    url: 'Goods/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWMSUrl // 直接通过覆盖的方式
  })
}

