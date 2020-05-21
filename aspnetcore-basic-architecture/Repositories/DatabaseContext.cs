using AspnetCoreBasicArchitecture.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AspnetCoreBasicArchitecture.Repositories
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(x => x is BaseEntity && (x.State == EntityState.Added));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).DiteTime = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        DbSet<Product> Products { get; set; }
    }
}
