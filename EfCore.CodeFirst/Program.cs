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

    var productDto1 = _context.Products.Select(x => new ProductDto()
    {
        Id = x.Id,
        Name = x.Name,
        Price = x.Price,
        Stock = x.Stock,
    }).ToList();

    var product = _context.Products.ToList();

    var productDto = ObjextMapper.Mapper.Map<List<ProductDto>>(product);
    Console.WriteLine("");



}


