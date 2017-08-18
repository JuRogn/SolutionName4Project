using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SimplCommerce.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost2(args).Run();
        }

        // Changed to BuildWebHost2 to make EF don't pickup during design time
        private static IWebHost BuildWebHost2(string[] args) =>
            Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(SetupConfiguration)
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext hostingContext, IConfigurationBuilder configBuilder)
        {
        }
    }
}
