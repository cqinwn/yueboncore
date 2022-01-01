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
using Yuebon.Commons.Cache;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.Mvc
{
    /// <summary>
    /// Token令牌提供类
    /// </summary>
    public class TokenProvider
    {
        JwtOption _jwtModel=App.GetService<JwtOption>();
        IRoleService _roleService = App.GetService<IRoleService>();
        IAPPService _appService = App.GetService<IAPPService>();
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

                    if (jwtToken != null)
                    {
                        #region 检查令牌对象内容
                        string appId = jwtToken.Claims.ToList()[0].Value;//Audience
                        string secret = _jwtModel.Secret;
                        List<APP> list = MemoryCacheHelper.Get<List<APP>>("cacheAppList");
                        if (list.Count== 0||list==null)
                        {
                            list = _appService.GetAll().ToList();
                        }
                        secret = list.Find(o => o.AppId == appId)?.AppSecret;
                        var keyByteArray = Encoding.UTF8.GetBytes(secret);
                        new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters()
                        {
                            RequireExpirationTime = true,//RequireExpirationTime = true, 
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(keyByteArray),
                            ValidateAudience = true,
                            ValidAudience = appId,
                            ValidateIssuer = true,
                            ValidIssuer = _jwtModel.Issuer,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero
                        }, out SecurityToken validatedToken);

                        if (jwtToken.Subject == GrantType.Password)
                        {
                            var claimlist = jwtToken?.Payload.Claims as List<Claim>;
                            result.ResData = claimlist;
                        }
                        result.ErrMsg = ErrCode.err0;
                        result.ErrCode = ErrCode.successCode;


                        #endregion
                    }
                    else
                    {
                        result.ErrMsg = ErrCode.err40004;
                        result.ErrCode = "40004";
                    }
                }
                catch (SecurityTokenExpiredException ex)
                {
                    Log4NetHelper.Error("验证token异常 SecurityTokenExpiredException", ex);
                    result.ErrMsg = ErrCode.err40005;
                    result.ErrCode = "40005";
                }
                catch (SecurityTokenInvalidLifetimeException ex)
                {
                    Log4NetHelper.Error("验证token异常 SecurityTokenInvalidLifetimeException", ex);
                    result.ErrMsg = ErrCode.err40005;
                    result.ErrCode = "40005";
                }
                catch (Exception ex)
                {
                    Log4NetHelper.Error("验证token异常", ex);
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
            string secret = _jwtModel.Secret;
            List<APP> list = MemoryCacheHelper.Get<List<APP>>("cacheAppList");
            if (list != null)
            {
                secret = list.Find(o => o.AppId == appid)?.AppSecret;
            }
            var key = Encoding.UTF8.GetBytes(secret);
            var authTime = DateTime.UtcNow;//授权时间
            var expires = authTime.Add(TimeSpan.FromMinutes(_jwtModel.Expiration));//过期时间
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescripor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(JwtClaimTypes.Audience,appid),
                    new Claim(JwtClaimTypes.Issuer,_jwtModel.Issuer),
                    new Claim(JwtClaimTypes.Name, userInfo.Account),
                    new Claim(JwtClaimTypes.Id, userInfo.Id),
                    new Claim(JwtClaimTypes.Role, _roleService.GetRoleEnCode(userInfo.RoleId)),
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


        /// <summary>
        /// 根据登录用户获取token
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="appid">应用Id</param>
        /// <returns></returns>
        public TokenResult GetUserToken(User userInfo, string appid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string secret = _jwtModel.Secret;
            List<APP> list = MemoryCacheHelper.Get<List<APP>>("cacheAppList");
            if (list != null)
            {
                secret = list.Find(o => o.AppId == appid)?.AppSecret;
            }
            var key = Encoding.UTF8.GetBytes(secret);
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
