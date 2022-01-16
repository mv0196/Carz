using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Carz.Common.DependencyInjection
{
    public static class SerilogDI
    {
        public static IServiceCollection AddSerilog(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            return services;
        }
    }
}
