using System.ComponentModel.DataAnnotations;

namespace e_commerce_api.src.Models
{
    public class CartModel
    {
        [Key]
        public long Id { get; set; }

        public CustomerModel Customer { get; set; }

        public ProductModel Product { get; set; }

        [Required]
        public long ProductQuantity { get; set; }
    }
}