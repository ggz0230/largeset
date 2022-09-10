using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WfwDiscovery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
            .Build()
            .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://0.0.0.0:9001")
                .UseStartup<Startup>();
            return builder;
        }
    }
}
