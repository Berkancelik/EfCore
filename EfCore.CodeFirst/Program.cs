using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
    var category = new Category() { Name = "Kalemler" };
    var product = new Product() { Name = "Kalem", Price = 100, Stock = 200, Barcode = 123, Category = category };


    _context.Products.Add(product);
    _context.SaveChanges();
}


