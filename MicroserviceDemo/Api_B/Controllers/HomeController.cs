using Consul;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 自增变量--不考虑线程安全
        /// </summary>
        private static long iTotalCount = 0;

        [HttpGet]
        [Route("Index")]
        public string Index()
        {
            string url = null;
            //url = "http://localhost:5726/api/users/all";
            //url = "http://47.95.2.2:5726/api/users/all";
            //url = "http://47.95.2.2:5727/api/users/all";
            //url = "http://47.95.2.2:5728/api/users/all";

            //url = "http://47.95.2.2:8086/api/users/all";

            url = "http://ZhaoxiService/api/users/all";

            ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");//consul地址
                c.Datacenter = "dc1";
            });
            var response = client.Agent.Services().Result.Response;
            foreach (var item in response)
            {
                Console.WriteLine("***************************************");
                Console.WriteLine(item.Key);
                var service = item.Value;
                Console.WriteLine($"{service.Address}--{service.Port}--{service.Service}");
                Console.WriteLine("***************************************");
            }

            Uri uri = new Uri(url);
            string groupName = uri.Host;
            AgentService agentService = null;

            var serviceDictionary = response.Where(s => s.Value.Service.Equals(groupName, StringComparison.OrdinalIgnoreCase)).ToArray();//获取的全部服务实例信息 5726/5727/5728
            //{
            //    agentService = serviceDictionary[0].Value;//写死--死心眼，怼一个
            //}
            //{
            //    //雨露均沾--轮询策略
                agentService = serviceDictionary[iTotalCount++ % serviceDictionary.Length].Value;
            //}
            //{
            //    //看RP--随机策略
            //    agentService = serviceDictionary[new Random().Next(0, 1000) % serviceDictionary.Length].Value;
            //}
            {
                //权重策略--不同的服务器处理能力不同，按能力分配
                //serviceDictionary[0].Value.Tags//获取权重1
                //大家找小助教获取下代码，自己动手试试
            }

            url = $"{uri.Scheme}://{agentService.Address}:{agentService.Port}{uri.PathAndQuery}";

            string content = InvokeApi(url);
            Console.WriteLine($"This is {url} Invoke");
            return url + "      " + content;
        }

        private string InvokeApi(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri(url);
                var result = httpClient.SendAsync(message).Result;
                string content = result.Content.ReadAsStringAsync().Result;
                return content;
            }
        }

    }
}
