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

        //public DbSet<ProductFeature> ProductFeature { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.PriceKdv).HasComputedColumnSql("[Price]*[Kdv]");

            modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAdd(); //identity
            modelBuilder.Entity<Product>().Property(x=> x.PriceKdv).ValueGeneratedOnAddOrUpdate(); // compudet
            modelBuilder.Entity<Product>().Property(x=> x.PriceKdv).ValueGeneratedNever();// none
            base.OnModelCreating(modelBuilder);
        }

    }
}
