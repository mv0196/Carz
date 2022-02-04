using Carz.Common.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.Common.DependencyInjection
{
    public static class AuthorizationFilterDI
    {
        public static IServiceCollection AddAuthorizationFilter(this IServiceCollection services)
        {
            services.AddScoped<AuthorizationFilterAttribute>();
            return services;
        }
    }
}
