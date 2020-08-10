using System.Threading.Tasks;
using e_commerce_api.src.DTOs.CartDTOs;

namespace e_commerce_api.src.Services
{
    public interface ICartService
    {
        Task<CartResponseDTO> CreateAsync(CartRequestDTO cart);
    }
}