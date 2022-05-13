using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
    var left = await (from p in _context.Products
                      join pf in _context.ProductFeature on p.Id equals pf.Id into pfList
                      from pf in pfList.DefaultIfEmpty()
                      select new
                      {
                          Id = p.Id,
                          Name = p.Name,
                          Color = pf.Color

                      }).ToListAsync();

    // Query syntax
    var right = await (from pf in _context.ProductFeature
                       join p in _context.Products on pf.Id equals p.Id into pList
                       from p in pList.DefaultIfEmpty()
                       select new
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Color = pf.Color

                       }).ToListAsync();


    var outerJoin = left.Union(right);




    Console.WriteLine("");



    //var category = new Category() { Name = "Kalemler" };
    //category.Products.Add(new() { Name = "kalem 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 2", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 4", Price = 100, Stock = 200, Barcode = 123 });
    //_context.Categories.Add(category);
    //_context.SaveChanges();
    Console.WriteLine("işlem bitti");
}