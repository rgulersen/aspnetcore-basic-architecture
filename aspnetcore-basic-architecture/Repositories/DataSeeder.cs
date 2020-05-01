using AspnetCoreBasicArchitecture.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspnetCoreBasicArchitecture.Repositories
{

    public static class DataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id= Guid.NewGuid(),
                    Code =1,
                    Name="Product1",
                    Price=12.3
                }, new Product
                {
                    Id = Guid.NewGuid(),
                    Code = 2,
                    Name = "Product2",
                    Price = 45.8
                }, new Product
                {
                    Id = Guid.NewGuid(),
                    Code = 3,
                    Name = "Product3",
                    Price = 36.9
                }, new Product
                {
                    Id = Guid.NewGuid(),
                    Code = 4,
                    Name = "Product4",
                    Price = 24.7
                }, new Product
                {
                    Id = Guid.NewGuid(),
                    Code = 5,
                    Name = "Product5",
                    Price = 13.9
                }
            );
        }

    }
}
