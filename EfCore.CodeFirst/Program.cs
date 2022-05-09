using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

Initializer.Build();
using (var _context = new AppDbContext())
{
    //var managers = _context.Managers.ToList();
    //var employee = _context.Employees.ToList();

    //var persons = _context.Persons.ToList();


    //persons.ForEach (p =>
    //{
    //    switch (p)
    //    {
    //        case Manager manager:
    //            Console.WriteLine($"Manager entity: {manager.Grade}");
    //            break;
    //        case Employee employee:
    //            Console.WriteLine($"Manager entity: {employee.Salary}");

    //            break;
    //        default:
    //            break;
    //    }
    //}) ;




}


