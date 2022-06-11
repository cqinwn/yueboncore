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
  var curTime = new Date();
  console.log("expires_in:" + expires_in)
  var expiredate = new Date(curTime.setSeconds(curTime.getSeconds() + expires_in));
  Cookies.set("expires_in", expires_in)
  console.log(expiredate)
  return Cookies.set("saveTokenExpire", expiredate);
}
