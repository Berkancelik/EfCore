using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{



    _context.Products.Add(new() { Name = "Kalem 1", Price = 100, Stock = 200, Barcode = 123, Kdv = 18 });
    _context.SaveChanges();
    Console.WriteLine("Kayıt Edildi");



}


