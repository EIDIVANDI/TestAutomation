using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomation.Infrastructure.Entities;

namespace TestAutomation.Infrastructure.Context
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity
            {
                Id = 1,
                Name = "product1",
                PriceTaxExcluded = 12000,
                PriceTaxIncluded = 14500
            });
            modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity
            {
                Id= 2,
                Name = "product2",
                PriceTaxExcluded = 680,
                PriceTaxIncluded = 920
            });
            modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity
            {
                Id = 3,
                Name = "product3",
                PriceTaxExcluded = 2100,
                PriceTaxIncluded = 2560
            });

            base.OnModelCreating(modelBuilder);
        }
        // In EF core at the moment the virtual keywork has no effect 
        public virtual DbSet<ProductEntity> Products { get; set; }


    }
}
