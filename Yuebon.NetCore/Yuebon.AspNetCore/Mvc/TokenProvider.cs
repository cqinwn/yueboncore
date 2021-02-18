using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.Mvc
{
    /// <summary>
    /// Token令牌提供类
    /// </summary>
    public class TokenProvider
    {
        JwtOption _jwtModel=App.GetService<JwtOption>();
        private Type type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
        /// <summary>
        /// 构造函数
        /// </summary>
        public TokenProvider() { }
        /// <summary>
        /// 构造函数，初花jwtmodel
        /// </summary>
        /// <param name="jwtModel"></param>
        public TokenProvider(JwtOption jwtModel)
        {
            _jwtModel = jwtModel;
        }
        /// <summary>
        /// 直接通过appid和加密字符串获取访问令牌接口
        /// </summary>
        /// <param name="granttype">获取access_token填写client_credential</param>
        /// <param name="appid">用户唯一凭证AppId</param>
        /// <param name="secret">用户唯一凭证密钥，即appsecret</param>
        /// <returns></returns>
        public TokenResult GenerateToken(string granttype, string appid, string secret)
        {
            var keyByteArray = Encoding.UTF8.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(_jwtModel.Expiration));
            var signingCredentials=new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var tokenDescripor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(JwtClaimTypes.Audience,appid),
                    new Claim(JwtClaimTypes.Issuer,_jwtModel.Issuer),
                    new Claim(JwtClaimTypes.Subject, GrantType.ClientCredentials)
                }, granttype),
                Expires = expires,
                //对称秘钥SymmetricSecurityKey
                //签名证书(秘钥，加密算法)SecurityAlgorithms
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyByteArray), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescripor);
            var tokenString = tokenHandler.WriteToken(token);
            TokenResult result = new TokenResult();
            result.AccessToken = tokenString;
            result.ExpiresIn = (int)TimeSpan.FromMinutes(_jwtModel.Expiration).TotalMinutes;
            return  result;
        }
        /// <summary>
        /// 检查用户的Token有效性
        /// </summary>
        /// <param name="token">token令牌</param>
        /// <returns></returns>
        public CommonResult ValidateToken(string token)
        {
            //返回的结果对象
            CommonResult result = new CommonResult();
            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                    if (jwtToken!=null)
                    {
                        #region 检查令牌对象内容
                        DateTime now = DateTime.UtcNow;
                        DateTime refreshTime = jwtToken.ValidFrom;
                        refreshTime= refreshTime.Add(TimeSpan.FromMinutes(_jwtModel.refreshJwtTime));
                        if (now > refreshTime && jwtToken.Issuer== _jwtModel.Issuer)
                        {
                            result.ErrMsg = ErrCode.err40005;
                            result.ErrCode = "40005";
                        }
                        else
                        {
                            if (jwtToken.Subject == GrantType.Password)
                            {
                                var claimlist = jwtToken?.Payload.Claims as List<Claim>;
                                result.ResData= claimlist;
                            }
                            result.ErrMsg = ErrCode.err0;
                            result.ErrCode = ErrCode.successCode;
                            
                        }
                        #endregion
                    }
                    else
                    {
                        result.ErrMsg = ErrCode.err40004;
                        result.ErrCode = "40004";
                    }
                }
                catch (Exception ex)
                {
                    Log4NetHelper.Error(type, "验证token异常", ex);
                    throw new MyApiException(ErrCode.err40004, "40004");
                }
            }
            else
            {
                result.ErrMsg = ErrCode.err40004;
                result.ErrCode = "40004";
            }
            return result;
        }

        /// <summary>
        /// 根据用户获取token
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="appid">应用Id</param>
        /// <returns></returns>
        public TokenResult LoginToken(User userInfo,string appid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtModel.Secret);
            var authTime = DateTime.UtcNow;//授权时间
            var expires = authTime.Add(TimeSpan.FromMinutes(_jwtModel.Expiration));//过期时间
            var tokenDescripor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(JwtClaimTypes.Audience,appid),
                    new Claim(JwtClaimTypes.Issuer,_jwtModel.Issuer),
                    new Claim(JwtClaimTypes.Name, userInfo.Account),
                    new Claim(JwtClaimTypes.Id, userInfo.Id),
                    new Claim(JwtClaimTypes.Role, userInfo.RoleId),
                    new Claim(JwtClaimTypes.Subject, GrantType.Password)
                }),
                Expires = expires,
                //对称秘钥SymmetricSecurityKey
                //签名证书(秘钥，加密算法)SecurityAlgorithms
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescripor);
            var tokenString = tokenHandler.WriteToken(token);
            TokenResult result = new TokenResult();
            result.AccessToken = tokenString;
            result.ExpiresIn = (int)TimeSpan.FromMinutes(_jwtModel.Expiration).TotalMinutes;
            return result;
        }
    }
}
