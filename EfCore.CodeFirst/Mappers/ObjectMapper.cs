using AutoMapper;
using EfCore.CodeFirst.DAL;
using EfCore.CodeFirst.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.Mappers
{
    public class ObjextMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;

    internal class CustomMapping:Profile
    {
        public CustomMapping()
        {
            CreateMap<ProductDto,Product>().ReverseMap(); 
        }

    }
}
