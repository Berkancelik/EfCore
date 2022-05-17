using AutoMapper.QueryableExtensions;
using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using EfCore.CodeFirst.DTOs;
using EfCore.CodeFirst.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
var connection = new SqlConnection(Initializer.Configuration.GetConnectionString("SqlCon"));

using (var _context = new AppDbContext())
{


    using(var transection = _context.Database.BeginTransaction())
    {
        var category = new Category() { Name = "Telefonlar" };
        _context.Categories.Add(category);
        var product = _context.Products.First();
        product.Name = "Defter 123";
        Product product2 = new()
        {
            Name = "Defter 1",
            Price = 100,
            Stock = 200,
            Barcode = 123,
            CategoryId = category.Id
        };
        _context.Products.Add(product2);
        _context.SaveChanges();
        Console.WriteLine("");
        transection.Commit();
    }






}


