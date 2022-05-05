using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
    //Product => Parent
    //ProductFeature => Child

    var product = new Product { Name = "Kalem", Price = 200, Stock = 200, Barcode = 123, Category = new() { Name = "Silgiler" } };
    _context.Products.Add(product);
    _context.SaveChanges();
    Console.WriteLine("Kayıt Edildi");
}


