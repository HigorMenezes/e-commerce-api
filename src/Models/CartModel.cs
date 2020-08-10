using System.ComponentModel.DataAnnotations;

namespace e_commerce_api.src.Models
{
    public class CartModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public CustomerModel Customer { get; set; }

        [Required]
        public ProductModel Product { get; set; }

        [Required]
        public long ProductQuantity { get; set; }
    }
}