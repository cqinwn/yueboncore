import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 获取数据库表
   */
export function codeGetTableList (data) {
  return http({
    url: 'CodeGenerator/GetListTable',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 生成代码
   */
export function codeGenerator (data) {
  return http({
    url: 'CodeGenerator/Generate',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
 *
* 数据库解密
*/
export function dbtoolsConnStrDecrypt (data) {
  return http({
    url: 'DbTools/ConnStrDecrypt',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 数据库加密
   */
export function dbtoolsConnStrEncrypt (data) {
  return http({
    url: 'DbTools/ConnStrEncrypt',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
