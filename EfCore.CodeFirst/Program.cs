using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();


GetProducts(1, 3).ForEach(x =>
{
    Console.WriteLine($"{ x.Id} {x.Name}");
});

// page sayfa , ikinçisi ise sayafa da kaç data olacak
static List<Product> GetProducts(int page, int pageSize)
{
    using (var _context = new AppDbContext())
    {
        // ilk üç data :page=3 pageSize = 5 
        return _context.Products.OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();




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
}

