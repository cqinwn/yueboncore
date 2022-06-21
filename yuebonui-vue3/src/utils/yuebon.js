import md5 from 'js-md5'

/**
 * 获取一个32位随机字符串
 * @returns
 */
export function GetRandomString() {
  var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789'
  var maxPos = chars.length
  var pwd = ''
  for (var i = 0; i < 32; i++) {
    pwd += chars.charAt(Math.floor(Math.random() * maxPos))
  }
  return pwd
}

/**
* 签名
* @param config 请求配置
* @param nonce 随机字符串
* @param timestamp 签名时间戳
* @param appSecret 应用密钥
* @param method 请求方式
*/
export function sign(config, nonce, timestamp, appSecret) {
  // 签名格式： timestamp + nonce + data(字典升序)+appSecret
  const ret = []
  if (config.params) {
    const pArray = []
    const data = config.params
    for (const it in data) {
      pArray.push(it)
    }
    // 字典升序
    const sArray = pArray.sort()
    for (const it of sArray) {
      let val = data[it]
      if (typeof val === 'object' && //
        (!(val instanceof Array) || (val.length > 0 && (typeof val[0] === 'object')))) {
        val = JSON.stringify(val)
      }
      ret.push(it + val)
    }
  } else {
    ret.push(JSON.stringify(config.data))
  }
  const signsrc = timestamp + nonce + ret.join('') + appSecret
  return md5(signsrc)
}

// 返回项目路径
export function getNormalPath(p) {
  if (p.length === 0 || !p || p == 'undefined') {
    return p
  };
  let res = p.replace('//', '/')
  if (res[res.length - 1] === '/') {
    return res.slice(0, res.length - 1)
  }
  return res;
}


// 验证是否为blob格式
export async function blobValidate(data) {
  try {
    const text = await data.text();
    JSON.parse(text);
    return false;
  } catch (error) {
    return true;
  }
}

