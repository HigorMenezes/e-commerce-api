using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.Models;

namespace e_commerce_api.src.Repositories
{
    public interface IProductRepository
    {
        Task<bool> SaveChangesAsync();
        ProductModel Create(ProductModel product);
        Task<IEnumerable<ProductModel>> FindAllAsync();
        Task<ProductModel> FindByIdAsync(long id);
        ProductModel FullUpdate(ProductModel product);
        ProductModel Delete(ProductModel product);
    }
}