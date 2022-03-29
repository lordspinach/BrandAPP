using BrandAPP.API.MappingProfiles;
using BrandAPP.BLLayer.Interfaces;
using BrandAPP.BLLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace BrandAPP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationContext(Configuration.GetConnectionString("DataDbConnection"));
            services.AddDbDependency();
            services.AddTransient<IBrandService, BrandService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddDbLayerMapper();
            services.AddAutoMapper(
                typeof(BrandMappings),
                typeof(SizeMappings)
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            var serviceProvider = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider;
            SeedDatabase.Initialize(serviceProvider);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
