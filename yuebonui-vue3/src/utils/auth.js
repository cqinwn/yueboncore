import Cookies from 'js-cookie'
const TokenKey = 'yuebon_soft_token'

export function getToken() {
  return Cookies.get(TokenKey)
}

export function setToken(token) {
  return Cookies.set(TokenKey, token)
}

export function removeToken() {
  return Cookies.remove(TokenKey)
}

export function saveTokenExpire(expires_in) {
  var curTime = new Date()
  var expiredate = new Date(curTime.setMinutes(curTime.getMinutes() + expires_in))
  Cookies.set("expires_in", expires_in)
  Cookies.set("tokenExpire", expiredate)
  Cookies.set("refresh_time", expiredate)
}

export function getTokenExpire() {
  return Cookies.get("tokenExpire")
}

export function setTokenRefreshTime(expiredate) {
  Cookies.set("refresh_time", expiredate)
}
export function getTokenRefreshTime() {
  return Cookies.get("refresh_time")
}

export function saveRefreshtime() {
  let nowtime = new Date()
  let lastRefreshtime = getTokenRefreshTime() ? new Date(getTokenRefreshTime) : new Date(-1);
  let expiretime = new Date(Date.parse(getTokenExpire()))
  let refreshCount = 20;//滑动系数
  if (lastRefreshtime >= nowtime) {
    lastRefreshtime = nowtime > expiretime ? nowtime : expiretime;
    lastRefreshtime.setMinutes(lastRefreshtime.getMinutes() + refreshCount);
    setTokenRefreshTime(lastRefreshtime)
  } else {
    setTokenRefreshTime(new Date(-1))
  }
};