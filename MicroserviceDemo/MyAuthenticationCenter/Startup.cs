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

            //�ͻ���ģʽ--��ôִ��Ids4
            services.AddIdentityServer()//��ô����
              .AddDeveloperSigningCredential()//��ʱ���ɵ�֤��--��ʱ���ɵ�
              .AddInMemoryClients(ClientInitConfig.GetClients())//InMemory �ڴ�ģʽ
              .AddInMemoryApiResources(ClientInitConfig.GetApiResources());//�ܷ���ɶ��Դ

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
            app.UseIdentityServer();//ʹ��Ids4 ����ᴫ��Ids4���м��

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    /// <summary>
    /// �ͻ���ģʽ
    /// </summary>
    public class ClientInitConfig
    {
        /// <summary>
        /// ����ApiResource   
        /// �������Դ��Resources��ָ�ľ��ǹ����API
        /// </summary>
        /// <returns>���ApiResource</returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("UserApi", "�û���ȡAPI")
            };
        }

        /// <summary>
        /// ������֤������Client
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "Zhaoxi.AspNetCore31.AuthDemo",//�ͻ���Ωһ��ʶ
                    ClientSecrets = new [] { new Secret("eleven123456".Sha256()) },//�ͻ������룬�����˼���
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //��Ȩ��ʽ���ͻ�����֤��ֻҪClientId+ClientSecrets
                    AllowedScopes = new [] { "UserApi" },//������ʵ���Դ
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
