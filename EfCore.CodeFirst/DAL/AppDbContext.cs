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
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductFeature> ProductFeature { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Trace
            //Debug
            //Information
            //Warning
            //Error
            //Critical
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().OwnsOne(x => x.Person,p=>
            {
                p.Property(x=>x.FirstName).HasColumnName("FirstName");
                p.Property(x=>x.LastName).HasColumnName("LastName");
                p.Property(x=>x.Age).HasColumnName("Age");
            });

            modelBuilder.Entity<Employee>().OwnsOne(x => x.Person, p =>
            {
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Age).HasColumnName("Age");
            });
            modelBuilder.Entity<Employee>().OwnsOne(x => x.Person);
      
            base.OnModelCreating(modelBuilder);
        }

    }
}
