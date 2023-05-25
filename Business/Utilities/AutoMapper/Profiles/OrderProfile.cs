using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Utilities.AutoMapper.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderCartDto>().ForMember(x => x.TotalQuantity, dest => dest.MapFrom(x => x.Quantity))
                .ForMember(x => x.TotalAmount, dest => dest.MapFrom(x => x.Price))
                .ForMember(x => x.Products, dest => dest.Ignore())
                .ReverseMap()
                .ForMember(x => x.AddressId, dest => dest.Ignore())
                .ForMember(x => x.CustomerId, dest => dest.Ignore())
                .ForMember(x => x.Status, dest => dest.Ignore());
        }
    }
}
