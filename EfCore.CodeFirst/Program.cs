using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
    var id = 5;

    decimal price = 100;

    var products = await _context.Products.FromSqlRaw("select * from products").ToListAsync();


    //parametre
    var product = await _context.Products.FromSqlRaw("select * from products where id={0}", id).FirstAsync();

    var products2 = await _context.Products.FromSqlRaw("select * from products where  price>{0}", price).ToListAsync();


    var products3 = await _context.Products.FromSqlInterpolated($"select * from products where  price>{price}").ToListAsync();

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
