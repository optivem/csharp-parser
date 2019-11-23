﻿using AutoMapper;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
{
    public class RelistProductResponseProfile : Profile
    {
        public RelistProductResponseProfile()
        {
            CreateMap<Product, RelistProductResponse>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(e => e.ProductCode))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(e => e.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(e => e.ListPrice));
        }
    }
}