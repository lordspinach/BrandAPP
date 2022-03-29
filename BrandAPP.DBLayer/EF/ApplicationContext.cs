using BrandAPP.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BrandAPP.DBLayer.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BrandDb> Brands { get; set; }
        public DbSet<SizeDb> Sizes { get; set; }
        public ApplicationContext() : base() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity is BrandDb)
                        {
                            entry.CurrentValues["IsDeleted"] = false;
                        }
                        break;
                    case EntityState.Deleted:
                        if (entry.Entity is BrandDb)
                        {
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsDeleted"] = true;
                        }
                        break;
                }
            }
            return base.SaveChanges();
        }
    }



}
