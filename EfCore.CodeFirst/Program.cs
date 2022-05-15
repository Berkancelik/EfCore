using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{


    // Not: Aşağıda Where koşulu kullanamayız
    var products = await _context.ProductFulls.FromSqlRaw("exec sp_get_products_full").ToListAsync();
    // where ister isek 
    var prdoduct2 = products.Where(x => x.Width > 200);


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


