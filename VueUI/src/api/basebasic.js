import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
 * 获取token
 * @param {} query
 */
export function getToken(query) {
  var data = {
    'grant_type': 'client_credential',
    'appid': defaultSettings.appId,
    'secret': defaultSettings.appSecret
  }
  return http({
    url: 'Token',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
 *刷新token
 * @param {*} data
 */
export function refreshToken(data) {
  return http({
    url: 'Token/RefreshToken',
    method: 'get',
    params: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
export function getSysSetting() {
  return http({
    url: 'Security/SysSetting/GetInfo',
    method: 'get',
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
export function getSubSystemList() {
  return http({
    url: 'Security/SystemType/GetSubSystemList',
    method: 'get',
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 登录
   * @param {*} data
   */
export function login(data) {
  var query = data
  return http({
    url: 'Login/GetCheckUser',
    method: 'get',
    params: query,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
export function savePassword(data) {
  var query = data
  return http({
    url: 'Security/User/ModifyPassword',
    method: 'post',
    params: query,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
export function clearCache() {
  return http({
    url: 'Security/User/ClearCache',
    method: 'get',
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 退出登录
   */
export function logout() {
  return http({
    url: 'Login/Logout',
    method: 'get',
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取数据库表
   */
export function codeGetTableList(data) {
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
export function codeGenerator(data) {
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
export function dbtoolsConnStrDecrypt(data) {
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
export function dbtoolsConnStrEncrypt(data) {
  return http({
    url: 'DbTools/ConnStrEncrypt',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 根据字典编码获取字典内容
   */
export function getListItemDetailsByCode(code) {
  return http({
    url: 'Security/Items/GetListByItemCode?itemCode=' + code,
    method: 'get',
    baseURL: defaultSettings.apiHostUrl // 直接通过覆盖的方式
  })
}
/**
   * 根据菜单功能编码查询该页面功能
   */
export function getListMeunFuntionBymeunCode(code) {
  return http({
    url: 'Function/GetListByParentEnCode?enCode=' + code,
    method: 'get',
    baseURL: defaultSettings.apiHostUrl
  })
}

/**
   * 获取微信小程序二维码
   * @param {查询条件} data
   */
export function getWxAppletQrCode(data) {
  return http.request({
    url: 'WeiXin/WxOpen/ContentWxAppletQrCode',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiHostUrl// 直接通过覆盖的方式
  })
}
