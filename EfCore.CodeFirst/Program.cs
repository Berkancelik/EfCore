using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
    var category = new Category() { Name = "Kalemler" };
    category.Products.Add(new Product()
    {
        Name = "Kalem 1",
        Price = 100,
        Stock = 100,
        Barcode = 123,
        ProductFeature = new() { Color = "Red", Height = 100, Width = 200 }
    });

         category.Products.Add(new Product()
         {
             Name = "Kalem 2",
             Price = 100,
             Stock = 100,
             Barcode = 123,
             ProductFeature = new() { Color = "Red", Height = 100, Width = 200 }
         });

    var categoryWithProducts = _context.Categories.Include(x => x.Products).ThenInclude(x=>x.ProductFeature).First();

    await _context.AddAsync(category);    
     _context.SaveChanges(); 

}


