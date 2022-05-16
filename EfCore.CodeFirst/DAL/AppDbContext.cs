using EfCore.CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {

        public  int GetProductCount(int categoryId)
        {
            throw new NotSupportedException("Bu method Ef Core tarafından çalıştırılmaktadır.");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
     

 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging
                .LogLevel.Information).UseSqlServer(Initializer.Configuration
                .GetConnectionString("SqlCon"))
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     

            base.OnModelCreating(modelBuilder);
        }
    }
}