import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 分页查询
   * @param {查询条件} data
   */
export function getSequenceRuleListWithPager(data) {
  return http.request({
    url: 'SequenceRule/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}/**
   * 获取所有可用的
   */
export function getAllSequenceRuleList() {
  return http.request({
    url: 'SequenceRule/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存
   * @param data
   */
export function saveSequenceRule(data) {
  return http.request({
    url: 'SequenceRule/InsertOrUpdateAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取详情
   * @param {Id} Id
   */
export function getSequenceRuleDetail(id) {
  return http({
    url: 'SequenceRule/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setSequenceRuleEnable(data) {
  return http({
    url: 'SequenceRule/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftSequenceRule(data) {
  return http({
    url: 'SequenceRule/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteSequenceRule(data) {
  return http({
    url: 'SequenceRule/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiWSecurityUrl // 直接通过覆盖的方式
  })
}

