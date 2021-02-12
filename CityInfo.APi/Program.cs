using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var logger = NLogBuilder.ConfigureNLog("nlog.config")
                                    .GetCurrentClassLogger();
            try
            {
                logger.Info("Initializing application ...");
                CreateWebHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {

                logger.Error(ex, " Your City Index is outof Bound");
                throw;
            }
            finally {

                NLog.LogManager.Shutdown();
            }
            }
            

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .UseNLog();
    }
}
