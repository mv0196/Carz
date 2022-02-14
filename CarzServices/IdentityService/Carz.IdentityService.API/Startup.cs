using Carz.Common.Configuration;
using Carz.Common.DependencyInjection;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Services;
using Carz.IdentityService.Infrastructure.Mappers;
using Carz.IdentityService.Services.SQL.Contexts;
using Carz.IdentityService.Services.SQL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Linq;

namespace Carz.IdentityService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => { x.AddProfile<UserMapper>(); x.AddProfile<RoleMapper>(); });
            services.AddCommonJwtAuthentication(Configuration);
            services.AddMediatrConfiguration("Carz.IdentityService.API", "Carz.IdentityService.Domain", "Carz.IdentityService.Infrastructure");
            services.AddSqlServer<IdentityUserDbContext>(Configuration);

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, Services.SQL.Services.UserService>();

            services.AddAuthorizationFilter();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Carz.IdentityService.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carz.IdentityService.API v1"));
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<IdentityUserDbContext>();
                dataContext.Database.Migrate();
                if (!dataContext.IdentityUsers.Any(x => x.Email == "admin@carz.com"))
                {
                    dataContext.IdentityUsers.AddRange(new IdentityUser[] {
                        new IdentityUser{ Email = "admin@carz.com", PasswordHash = "admin"}
                    });
                    dataContext.SaveChanges();
                }

                if (!dataContext.Roles.Any(x => x.Name == "User"))
                {
                    dataContext.Roles.AddRange(new Role[] {
                        new Role{ Name = "User", CreatedBy = System.Guid.Empty }
                    });
                    dataContext.SaveChanges();
                }
                if (!dataContext.Roles.Any(x => x.Name == "Admin"))
                {
                    dataContext.Roles.AddRange(new Role[] {
                        new Role{ Name = "Admin", CreatedBy = System.Guid.Empty }
                    });
                    dataContext.SaveChanges();
                }
                var admin = dataContext.IdentityUsers.FirstOrDefault(u => u.Email == "admin@carz.com");
                var adminRole = dataContext.Roles.FirstOrDefault(r => r.Name == "Admin");
                var userRole = dataContext.Roles.FirstOrDefault(r => r.Name == "Admin");

                if (!dataContext.IdentityUserRoles.Any(x => x.IdentityUserId == admin.Id && x.RoleId == adminRole.Id))
                {
                    dataContext.IdentityUserRoles.AddRange(new IdentityUserRole[] {
                        new IdentityUserRole{IdentityUserId = admin.Id,
                        RoleId = adminRole.Id
                        },
                        new IdentityUserRole{IdentityUserId = admin.Id,
                        RoleId = userRole.Id
                        }
                    });
                    dataContext.SaveChanges();
                }

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
