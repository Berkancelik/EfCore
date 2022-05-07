using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
     var product = _context.Products.First();
    if (true)
    {
        _context.Entry(product).Reference(x => x.ProductFeature).Load();
   
    }
}


