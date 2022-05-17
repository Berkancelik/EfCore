using AutoMapper.QueryableExtensions;
using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using EfCore.CodeFirst.DTOs;
using EfCore.CodeFirst.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
    var category = new Category() { Name = "Telefonlar" };
    _context.Categories.Add(category);

    var product = _context.Products.First();
    product.Name = "Defter 123";
    _context.SaveChanges();

    Console.WriteLine("");


}


