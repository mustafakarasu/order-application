using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductAddDto>().ForMember(dest => dest.ImageFile, opt => opt.Ignore()).ReverseMap();
            CreateMap<Product, ProductCartDto>().ForMember(dest => dest.ImageFile, options => options.Ignore()).ForMember(x => x.Quantity, options => options.Ignore()).ForMember(x => x.TotalPrice, options => options.Ignore()).ReverseMap();
        }
    }
}
