using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.Common.DependencyInjection
{
    public static class JwtSecurityTokenHandlerDI
    {
        public static IServiceCollection AddJwtSecurityTokenHandler(this IServiceCollection services)
        {
            services.AddScoped<JwtSecurityTokenHandler>();
            return services;
        }
    }
}
