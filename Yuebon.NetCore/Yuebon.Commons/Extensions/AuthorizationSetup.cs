using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Options;

namespace Yuebon.Commons.Extensions
{
    /// <summary>
    /// 系统 授权服务 配置
    /// </summary>
    public static class AuthorizationSetup
    {
        /// <summary>
        /// 系统 授权服务 配置
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddAuthorizationSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var jwtConfig = Appsettings.Configuration.GetSection("Jwt");
            var jwtOption = new JwtOption
            {
                Issuer = jwtConfig["Issuer"],
                Expiration = Convert.ToInt16(jwtConfig["Expiration"]),
                Secret = jwtConfig["Secret"],
                Audience = jwtConfig["Audience"],
                refreshJwtTime = Convert.ToInt16(jwtConfig["refreshJwtTime"])
            };
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; ;

            }).AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtOption.Secret)),//秘钥
                    ValidateIssuer = true,
                    ValidIssuer = jwtOption.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtOption.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            services.AddSingleton(jwtOption);//注册配置
        }
    }
}
