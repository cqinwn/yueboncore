import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 定时任务执行日志分页查询
   * @param {查询条件} data
   */
export function getTaskJobsLogListWithPager (data) {
  return http.request({
    url: 'TaskJobsLog/FindWithPagerAsync',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}/**
   * 获取所有可用的定时任务执行日志
   */
export function getAllTaskJobsLogList () {
  return http.request({
    url: 'TaskJobsLog/GetAllEnable',
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存定时任务执行日志
   * @param data
   */
export function saveTaskJobsLog (data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取定时任务执行日志详情
   * @param {Id} 定时任务执行日志Id
   */
export function getTaskJobsLogDetail (id) {
  return http({
    url: 'TaskJobsLog/GetById?id=' + id,
    method: 'get',
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setTaskJobsLogEnable (data) {
  return http({
    url: 'TaskJobsLog/SetEnabledMarktBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftTaskJobsLog (data) {
  return http({
    url: 'TaskJobsLog/DeleteSoftBatchAsync',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteTaskJobsLog (data) {
  return http({
    url: 'TaskJobsLog/DeleteBatchAsync',
    method: 'delete',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
