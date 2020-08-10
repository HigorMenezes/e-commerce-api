using System.ComponentModel.DataAnnotations;

namespace e_commerce_api.src.DTOs.CartDTOs
{
    public class CartRequestDTO
    {
        [Required]
        public long CustomerId { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public long ProductQuantity { get; set; }
    }
}