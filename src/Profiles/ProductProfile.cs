using AutoMapper;
using e_commerce_api.src.DTOs.ProductDTOs;
using e_commerce_api.src.Models;

namespace e_commerce_api.src.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, ProductResponseDTO>();
            CreateMap<ProductRequestDTO, ProductModel>();
            CreateMap<ProductUpdateRequestDTO, ProductModel>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ProductModel, ProductUpdateRequestDTO>();
        }
    }
}