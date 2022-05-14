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


        private readonly int Barcode;

        public AppDbContext(int barcode)
        {
            Barcode = barcode;
        }
        public AppDbContext()
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductFull> ProductFulls { get; set; }
        public DbSet<ProductEssential> ProductEssentials { get; set; }

        //public DbSet<ProductWithFeature> ProductWithFeatures { get; set; }
        //public DbSet<Person> People { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // global filter'ı burada tanımlama koldukça basittir
            //default'u false olarak gelecektir
            modelBuilder.Entity<Product>().Property(x => x.IsDeleted).HasDefaultValue(false);
            // product üzeridne yaptığımız her bir where koşulunda buradaki isDeleted otomatik şekilde eklenmektedir.
            //(p => p.IsDeleted );==aşağıdaki ile aynı anlamı taşımaktadır.
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.IsDeleted == false);

      
            base.OnModelCreating(modelBuilder);
        }
    }
}