using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDatabaseFirst.DataAccessLayer
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }


        // aşağıda Sql için bağlantı alanı açılmaktadır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-IITT7DV;Initial Catalog=EFCoreDatabaseFirstDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }
}
