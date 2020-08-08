using AutoMapper;
using e_commerce_api.src.DTOs;
using e_commerce_api.src.Models;

namespace e_commerce_api.src.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, CustomerResponseDTO>();
            CreateMap<CustomerRequestDTO, CustomerModel>();
        }

    }
}