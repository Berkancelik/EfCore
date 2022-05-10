using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.DAL
{
    [Index(nameof(Name),nameof(Url))]
    public class Product
    {

        // Index tablosuna gidiyor kalem1 aslı1 tablodaki yerini buluyor
        // asıl product tablosunda id,name,url
        // ceontext.products.where(x=>x.name="kalem1").select(x=>new{name=>x.Name, Price = x.Price})
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductFeature ProductFeature { get; set; }


    }
}
