using System.ComponentModel.DataAnnotations;

namespace e_commerce_api.src.Models
{
    public class ProductModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public double Price { get; set; }
    }
}