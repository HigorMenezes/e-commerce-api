using System.ComponentModel.DataAnnotations;

namespace e_commerce_api.src.DTOs
{
    public class CustomerRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}