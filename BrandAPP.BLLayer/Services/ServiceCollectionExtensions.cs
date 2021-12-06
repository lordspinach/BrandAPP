using BrandAPP.BLLayer.MappingProfiles;
using BrandAPP.DBLayer.EF;
using BrandAPP.DBLayer.Interfaces;
using BrandAPP.DBLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrandAPP.BLLayer.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseNpgsql("Host=localhost;Database=BrandsAndProducts;Username=postgres;Password=password",
                x => x.MigrationsAssembly("BrandAPP.DBLayer")));
        }
        public static void AddDbDependency(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }

        public static void AddDbLayerMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(BrandMappings),
                typeof(SizeMappings)
            );
        }
    }
}
