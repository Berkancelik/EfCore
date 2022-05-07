using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{

    var category = new Category()
    {
        Name = "Kalemler",
        Products = new List<Product>()
        {
            new(){Name="Kalem 1", Price=100, Stock=200, Barcode=123},
            new(){Name="Kalem 2", Price=350, Stock=200, Barcode=123},
            new(){Name="Kalem 3", Price=250, Stock=123, Barcode=123},
        }
    };
    _context.Add(category);
    _context.SaveChanges(); 

    Console.WriteLine("Kayıt Edildi");
}


