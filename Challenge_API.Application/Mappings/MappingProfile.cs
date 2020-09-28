using AutoMapper;
using Challenge_API.Application.Feature.User;
using Challenge_API.Application.Interfaces.Response;
using Challenge_API.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Challenge_API.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetProductsResponse, Product>().ReverseMap();
           // CreateMap<List<GetProductsResponse>, List<Product>>().ReverseMap();
            CreateMap<GetUserResponse,User>().ReverseMap();
        }
    }
}
