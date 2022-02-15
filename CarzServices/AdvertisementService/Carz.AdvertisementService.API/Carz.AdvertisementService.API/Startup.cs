using Carz.AdvertisementService.Domain.Services;
using Carz.AdvertisementService.Services.Mongo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Carz.AdvertisementService.Infrastructure.Mappers;
using Carz.Common.DependencyInjection;
using Carz.AdvertisementService.Services.Mongo.Contexts;
using System.Reflection;

namespace Carz.AdvertisementService.API
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
            services.AddAutoMapper( x => { x.AddProfile<AdMapper>(); x.AddProfile<BidMapper>(); });
            services.AddCommonJwtAuthentication(Configuration);
            services.AddScoped<AdvertisementDbContext>();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();

            services.AddScoped<IAdService, AdService>();
            services.AddScoped<IBidService, BidService>();

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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carz.AdvertisementService.API v1"));
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
