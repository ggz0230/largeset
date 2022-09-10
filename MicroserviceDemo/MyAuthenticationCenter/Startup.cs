using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyAuthenticationCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAuthenticationCenter", Version = "v1" });
            });

            //客户端模式--怎么执行Ids4
            services.AddIdentityServer()//怎么处理
              .AddDeveloperSigningCredential()//临时生成的证书--即时生成的
              .AddInMemoryClients(ClientInitConfig.GetClients())//InMemory 内存模式
              .AddInMemoryApiResources(ClientInitConfig.GetApiResources());//能访问啥资源

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAuthenticationCenter v1"));
            }
            app.UseIdentityServer();//使用Ids4 请求会传过Ids4的中间件

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    /// <summary>
    /// 客户端模式
    /// </summary>
    public class ClientInitConfig
    {
        /// <summary>
        /// 定义ApiResource   
        /// 这里的资源（Resources）指的就是管理的API
        /// </summary>
        /// <returns>多个ApiResource</returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("UserApi", "用户获取API")
            };
        }

        /// <summary>
        /// 定义验证条件的Client
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "Zhaoxi.AspNetCore31.AuthDemo",//客户端惟一标识
                    ClientSecrets = new [] { new Secret("eleven123456".Sha256()) },//客户端密码，进行了加密
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //授权方式，客户端认证，只要ClientId+ClientSecrets
                    AllowedScopes = new [] { "UserApi" },//允许访问的资源
                    Claims = new List<Claim>(){
                        new Claim(IdentityModel.JwtClaimTypes.Role,"Admin"),
                        new Claim(IdentityModel.JwtClaimTypes.NickName,"Eleven"),
                        new Claim("eMail","57265177@qq.com")
                    }
                }
            };
        }
    }

}
