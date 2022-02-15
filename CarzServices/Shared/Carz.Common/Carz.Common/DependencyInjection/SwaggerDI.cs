using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Carz.Common.DependencyInjection
{
    public static class SwaggerDI
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, string title)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = @"Enter 'Bearer' [space] and then your valid token in the text input below.
<br>Example: ""Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"""
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

            });
            return services;
        }
    }
}
