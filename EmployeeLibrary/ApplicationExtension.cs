using Microsoft.Extensions.Hosting;
using Serilog;

namespace EmployeeLibrary
{
    public static class ApplicationExtension
    {
        public static void ConfigureSerilog(this IHostBuilder host)
        {
            host.UseSerilog((context, loggerConfig) =>
            {
                loggerConfig.WriteTo.Console();
                loggerConfig.WriteTo.File("logs.txt");
            });
        }
    }
}
