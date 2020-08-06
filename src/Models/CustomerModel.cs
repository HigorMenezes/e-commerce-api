using System.ComponentModel.DataAnnotations;

namespace e_commerce_api.src.Models
{
    public class CustomerModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}