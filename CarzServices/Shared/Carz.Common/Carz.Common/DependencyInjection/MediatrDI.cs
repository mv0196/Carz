using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Carz.Common.DependencyInjection
{
    public static class MediatrDI
    {
        public static IServiceCollection ConfigureMediatR(this IServiceCollection services, params string[] projectNames)
        {
            var assemblies = projectNames.Select(Assembly.Load).ToArray();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
            return services;
        }
    }
}
