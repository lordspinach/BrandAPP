using BrandAPP.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrandAPP.DBLayer.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BrandDb> Brands { get; set; }
        public DbSet<SizeDb> Sizes { get; set; }
        public ApplicationContext() : base() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    }
}
