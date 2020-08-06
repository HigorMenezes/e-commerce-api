using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.DTOs;

namespace e_commerce_api.src.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDTO>> FindAll();
        Task<CustomerResponseDTO> FindById(long id);
    }
}