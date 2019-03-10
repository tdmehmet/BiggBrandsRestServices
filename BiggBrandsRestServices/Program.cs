using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BiggBrandsRestServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var pathToContentRoot = Directory.GetCurrentDirectory();

            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(@".\Properties\log4net.properties"));
            ILog log = LogManager.GetLogger(typeof(Program));
            log.Info("Burada");
            return WebHost.CreateDefaultBuilder(args)
                            .UseKestrel()
                            .UseStartup<Startup>()
                            .UseContentRoot(pathToContentRoot)
                            .UseIISIntegration()
                            .UseConfiguration(new ConfigurationBuilder()
                                              .SetBasePath(Directory.GetCurrentDirectory())
                                              .AddJsonFile(@".\Properties\db.properties")
                                              .AddJsonFile(@".\Properties\app.properties")
                                              .Build());
        }
    }
}
