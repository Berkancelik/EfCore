using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.Models
{
    public class ProductFull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int Width { get; set; }
        public decimal Price { get; set; }
        public int Height { get; set; }
    }
}
