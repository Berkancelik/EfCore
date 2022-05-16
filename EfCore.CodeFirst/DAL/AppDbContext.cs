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


      

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductFull> ProductFulls { get; set; }
        //public DbSet<ProductEssential> ProductEssentials { get; set; }

        public DbSet<ProductWithFeature> ProductWithFeatures { get; set; }
        //public DbSet<Person> People { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        // not return ifadesi yerimne lambda ile içeri girebiliriz
        public IQueryable<ProductWithFeature> GetProductWithFeatures(int categoryId)
        {
            return FromExpression(() => GetProductWithFeatures(categoryId));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging
                .LogLevel.Information).UseSqlServer(Initializer.Configuration
                .GetConnectionString("SqlCon")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductWithFeatures),new[] { typeof(int) })).HasName("functionName");
            modelBuilder.Entity<Product>().ToFunction("fc_product_full");
      
            base.OnModelCreating(modelBuilder);
        }
    }
}