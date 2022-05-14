using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{


    var productsWithFeatures = _context.Products.TagWith("Bu Query ürünler " +
        "ve ürünlere bağlı özellikleri getirir").Include(x => x.ProductFeature).Where(x => x.Price > 100).ToList();

    #region DataInsert
    //var category = new Category() { Name = "Defterler" };
    //category.Products.Add(new() { Name = "Defter 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Defter 2", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Defter 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Defter 4", Price = 100, Stock = 200, Barcode = 123 });
    //_context.Categories.Add(category);
    //_context.SaveChanges();

    #endregion



}


