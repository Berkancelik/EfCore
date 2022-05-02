using EfCoreDatabaseFirst.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;

DbContextInitializer.Build();

using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();
    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id}:{p.Name}");
    });
}