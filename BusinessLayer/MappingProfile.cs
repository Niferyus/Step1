using AutoMapper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductListDto>()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => src.ImageUrl != null && src.ImageUrl.Any()
                                          ? src.ImageUrl.First()
                                          : null))
                .ReverseMap()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ImageUrl)
                                          ? new List<string>()
                                          : new List<string> { src.ImageUrl }));
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductDetailDto>().ReverseMap();
        }
    }
}
