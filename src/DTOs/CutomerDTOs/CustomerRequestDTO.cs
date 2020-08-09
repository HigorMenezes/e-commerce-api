using System.ComponentModel.DataAnnotations;

namespace e_commerce_api.src.DTOs.CustomerDTOs
{
    public class CustomerRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}