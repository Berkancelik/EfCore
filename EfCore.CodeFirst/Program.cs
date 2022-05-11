using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext()) 
{
    var persons = _context.People.ToList().Where(x=> FormatPhone(x.Phone) == "0531 556 92 35").ToList();
    //_context.People.Add(new Person() { Name = "Ahmet", Phone = "0531 556 92 35" });
   //_context.People.Add(new Person() { Name = "Mehmet", Phone = "0531 564 92 35" });

    _context.SaveChanges();
    Console.WriteLine("İşlem Bitti");


    string FormatPhone(string phone)
    {
        return phone.Substring(1, phone.Length - 1);
    }

}


