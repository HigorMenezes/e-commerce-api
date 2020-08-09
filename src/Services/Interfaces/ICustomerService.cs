using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.DTOs.CustomerDTOs;

namespace e_commerce_api.src.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDTO>> FindAllAsync();
        Task<CustomerResponseDTO> FindByIdAsync(long id);
        Task<CustomerResponseDTO> CreateAsync(CustomerRequestDTO customer);
        Task<CustomerResponseDTO> FullUpdateAsync(long id, CustomerRequestDTO customer);
        Task<CustomerResponseDTO> DeleteAsync(long id);
    }
}