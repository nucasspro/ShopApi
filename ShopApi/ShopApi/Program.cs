using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ShopApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(
                    (config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
                        config.AddJsonFile($"appsettings.Development.json", optional: false, reloadOnChange: false);
                        config.AddCommandLine(args);
                    })
                .UseStartup<Startup>();
    }
}