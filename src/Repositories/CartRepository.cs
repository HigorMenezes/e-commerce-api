using System.Threading.Tasks;
using e_commerce_api.src.Contexts;
using e_commerce_api.src.Models;

namespace e_commerce_api.src.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ECommerceContext _context;

        public CartRepository(ECommerceContext context)
        {
            _context = context;
        }

        public CartModel Create(CartModel cart)
        {
            _context.Cart.Add(cart);

            return cart;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var saved = await _context.SaveChangesAsync();

            return saved >= 0;
        }
    }
}