using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
    var product = await _context.Products.Select(x=> new
    {
        CategoryName = x.Category.Name,
        ProductName = x.Name,
        ProductPrice = x.Price,
        width=(int?)x.ProductFeature.Width
    }).Where(x=>x.width >10).ToListAsync();

    var categories = _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature).Select(x => new
    {
        CategoryName = x.Name,
        Products = String.Join(",", x.Products.Select(z => z.Name)),
        TotalPrice = x.Products.Sum(x => x.Price)
    }).Where(y=>y.TotalPrice>100).OrderBy(x=>x.TotalPrice).ToList();


  Console.WriteLine("");
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


