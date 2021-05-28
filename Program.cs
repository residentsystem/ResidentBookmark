using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ResidentBookmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((configureDelegate) =>
                {
                    configureDelegate.SetBasePath(Directory.GetCurrentDirectory());
                    configureDelegate.AddJsonFile("bookmarksettings.json", optional: true, reloadOnChange: true);
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
