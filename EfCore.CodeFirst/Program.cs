using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
     var category = await _context.Categories.FirstAsync();

    var products = category.Products;
    Console.WriteLine("İşlem Bitti");
}


