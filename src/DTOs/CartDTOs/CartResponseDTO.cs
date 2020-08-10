using e_commerce_api.src.DTOs.CustomerDTOs;
using e_commerce_api.src.DTOs.ProductDTOs;

namespace e_commerce_api.src.DTOs.CartDTOs
{
    public class CartResponseDTO
    {
        public long Id { get; set; }
        public CustomerResponseDTO Customer { get; set; }
        public ProductResponseDTO Product { get; set; }
        public long ProductQuantity { get; set; }
    }
}