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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));


            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API ile tanımlama
            // her zaman has ile başlanması gerekemktedir
            // aşağıdaki kod bloğu ile birlikte product içeriisnmde birden çok category geçebiliriz
        //    modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.Category_Id);
        }

    }
}
