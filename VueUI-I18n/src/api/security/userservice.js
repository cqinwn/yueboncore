import http from '@/utils/request'
import defaultSettings from '@/settings'

/**
   * 用户分页查询
   * @param {查询条件} data
   */
export function getUserListWithPager(data) {
  return http.request({
    url: 'User/FindWithPagerSearchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 新增或修改保存用户
   * @param data
   */
export function saveUser(data, url) {
  return http.request({
    url: url,
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取用户详情
   * @param {Id} 用户Id
   */
export function getUserDetail(id) {
  return http({
    url: 'User/GetById',
    method: 'get',
    params: { id: id },
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 获取用户详情
   * @param {userName} 用户账号
   */
export function getByUserName(userName) {
  return http({
    url: 'User/GetByUserName',
    method: 'get',
    params: { userName: userName },
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量设置启用状态
   * @param {id集合} ids
   */
export function setUserEnable(data) {
  return http({
    url: 'User/SetEnabledMarktBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}
/**
   * 批量软删除
   * @param {id集合} ids
   */
export function deleteSoftUser(data) {
  return http({
    url: 'User/DeleteSoftBatchAsync',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 批量删除
   * @param {id集合} ids
   */
export function deleteUser(data) {
  return http({
    url: 'User/DeleteBatchAsync',
    method: 'delete',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 重置密码
   * @param {userId:用户id} data
   */
export function resetPassword(data) {
  return http({
    url: 'User/ResetPassword',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 修改密码
   * @param {password:新密码,password2:重复新密码} data
   */
export function modifyPassword(data) {
  return http({
    url: 'User/ModifyPassword',
    method: 'post',
    params: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 注册新用户
   * @param data
   */
export function registerUser(data, url) {
  return http.request({
    url: 'User/Register',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

/**
   * 保存用户主题配置
   * @param data
   */
export function saveThemeConfig(data) {
  return http.request({
    url: 'User/SaveUserTheme',
    method: 'post',
    data: data,
    baseURL: defaultSettings.apiSecurityUrl // 直接通过覆盖的方式
  })
}

