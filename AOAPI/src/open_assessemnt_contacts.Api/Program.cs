using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Open.Assessement.Contacts.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {                    
                    webBuilder
                        .UseIISIntegration()
                        .UseStartup<Startup>()
                        .ConfigureLogging((hostingContext, logging) => {
                            logging.AddLog4Net();
                            logging.SetMinimumLevel(LogLevel.Information);
                        });
                });
    }
}
