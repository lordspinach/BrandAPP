using BrandAPP.DBLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace BrandAPP.BLLayer.Services
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var dataContext = serviceProvider.GetRequiredService<ApplicationContext>();
            dataContext.Database.Migrate();
        }
    }
}
