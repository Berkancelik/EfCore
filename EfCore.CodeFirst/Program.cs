using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;

Initializer.Build();
using (var _context = new AppDbContext())
{



    _context.Update(new Product() {Id=1, Name = "Ahmet", Price = 456, Stock = 245, Barcode = 22213 });
    await _context.SaveChangesAsync();

    //Console.WriteLine($"Son after save changes :{_context.Entry(product).State}");




    //var newProduct = new Product { Name = "Berkan", Price = 200, Stock = 100, Barcode = 333 };

    //var product = await _context.Products.FirstAsync();

    //EfCore tarafında veritabanına hiçbir veri yansıtılamaz
    //_context.Entry(product).State = EntityState.Detached;

    //Console.WriteLine($"İlk State :{_context.Entry(product).State}");

    //Console.WriteLine($"Son State :{_context.Entry(product).State}");

    //Aşağıdaki update therad edilmeyen bir datalar için vardır.
    //_context.Remove(product);

    // aşağıdaki ikisi aynı add işlemini gerçekleştirmektedir
    //  _context.Entry(product).State = EntityState.Added;
    // await _context.AddAsync(product);

    //var products = await _context.Products.ToListAsync();
    //products.ForEach(p =>
    //{
    //    var state = _context.Entry(p).State;
    //    Console.WriteLine($"{p.Id}:{p.Name}:{p.Price}:{p.Stock} state {state}" );
    //});

}