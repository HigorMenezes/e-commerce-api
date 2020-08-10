using System.Threading.Tasks;
using e_commerce_api.src.Models;

namespace e_commerce_api.src.Repositories
{
    public interface ICartRepository
    {
        Task<bool> SaveChangesAsync();
        CartModel Create(CartModel cart);
    }
}