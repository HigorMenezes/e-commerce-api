using System.ComponentModel.DataAnnotations;

namespace e_commerce_api.src.DTOs.ProductDTOs
{
    public class ProductUpdateRequestDTO
    {
        public string Name { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Price { get; set; }
    }
}