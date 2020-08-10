using AutoMapper;
using e_commerce_api.src.DTOs.CartDTOs;
using e_commerce_api.src.Models;

namespace e_commerce_api.src.Profiles
{
    public class CartProfile : Profile
    {

        public CartProfile()
        {
            CreateMap<CartRequestDTO, CartModel>();
            CreateMap<CartModel, CartResponseDTO>();
        }

    }
}