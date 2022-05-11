using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext()) 
{

    var result = _context.Categories
        .Join(_context.Products, c => c.Id, p => p.CategoryId, (c, p) => new
        {
            c,
            p
        }).Join(_context.ProductFeature,x=>x.p.Id,y=>y.Id(c,pf)=> new
        {
            CategoryName = c.c.Name,
            ProduvtName = c.p.Name,
            ProductFeature = pf.Color
        });

    //3 lü join
    var result2 = (from c in _context.Categories
                   join p in _context.Products on c.Id equals p.CategoryId
                   join pf in _context.ProductFeature on p.Id equals pf.Id
                   select new { c, p, pf }).ToList();  

    // sadece join metodu vardır burada. Bu kategoriye bağlı
    //var result = _context.Categories.Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) => p).ToList();


    //var resul2 = (from c in _context.Categories 
    //             join p in _context.Products on c.Id equals p.Id
    //             select new {
    //             CategoryName = c.Name,
    //             ProductName = c.Name,
    //             ProductPrice = p.Price
    //             }).ToList();



    //var category = new Category() { Name = "Kalemler" };
    //category.Products.Add(new() { Name = "kalem 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 2", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 4", Price = 100, Stock = 200, Barcode = 123 });
    //_context.Categories.Add(category);
    _context.SaveChanges();
    Console.WriteLine("işlem bitti");
}
