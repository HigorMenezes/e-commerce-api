using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.DTOs.ProductDTOs;

namespace e_commerce_api.src.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> FindAllAsync();
        Task<ProductResponseDTO> FindByIdAsync(long id);
        Task<ProductResponseDTO> CreateAsync(ProductRequestDTO product);
        Task<ProductResponseDTO> FullUpdateAsync(long id, ProductRequestDTO product);
        Task<ProductResponseDTO> DeleteAsync(long id);
    }
}