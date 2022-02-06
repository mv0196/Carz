using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
using System.Text;
using System.Threading.Tasks;

namespace Carz.Common.DependencyInjection
{
    public static class MediatrDI
    {
        public static IServiceCollection AddMediatrConfiguration(this IServiceCollection services, params string[] projectNames)
        {
            var assemblies = projectNames.Select(Assembly.Load).ToArray();
            services.AddMediatR(assemblies);
            return services;
        }
    }
}
