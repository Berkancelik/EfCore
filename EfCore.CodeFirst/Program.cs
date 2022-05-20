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


    using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted)
    {
        var product = _context.Products.First();
        product.Price = 3000;
        _context.SaveChanges();
        transaction.Commit();
    }




}


