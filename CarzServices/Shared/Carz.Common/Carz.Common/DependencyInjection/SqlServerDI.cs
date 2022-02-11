using Carz.Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.Common.DependencyInjection
{
    public static class SqlServerDI
    {
        public static IServiceCollection AddSqlServer<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            var sqlServerConfig = new SqlServerConfiguration();
            configuration.Bind(nameof(sqlServerConfig), configuration);
            services.AddDbContext<T>(options => options.UseSqlServer(sqlServerConfig.ConnectionString));
            return services;
        }
    }
}
