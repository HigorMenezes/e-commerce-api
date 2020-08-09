using System.ComponentModel.DataAnnotations;

namespace e_commerce_api.src.DTOs.ProductDTOs
{
    public class ProductRequestDTO
    {
        [Required]
        public string name { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public double Price { get; set; }
    }
}