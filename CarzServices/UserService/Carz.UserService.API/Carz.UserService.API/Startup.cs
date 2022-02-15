using Carz.UserService.Infrastructure.Mappers;
using Carz.UserService.Services.SQL.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using MediatR;
using Carz.Common.DependencyInjection;
using System.Reflection;

namespace Carz.UserService.API
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
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();

            services.AddAutoMapper(x => { x.AddProfile<ProfileMapper>(); });
            
            services.AddCommonJwtAuthentication(Configuration);

            services.AddMediatR(typeof(Startup));

            services.AddSqlServer<UserDbContext>(Configuration);

            services.AddAuthorizationFilter();

            services.AddControllers();
            services.AddSwaggerConfiguration(Assembly.GetExecutingAssembly().FullName.Split(',')[0]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carz.UserService.API v1"));
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
                dataContext.Database.Migrate();
            }

            app.UseSerilogRequestLogging();

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
