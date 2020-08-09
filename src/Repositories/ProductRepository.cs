using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.Contexts;
using e_commerce_api.src.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.src.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceContext _context;

        public ProductRepository(ECommerceContext context)
        {
            _context = context;
        }

        public ProductModel Create(ProductModel product)
        {
            _context.Product.Add(product);

            return product;
        }

        public ProductModel Delete(ProductModel product)
        {
            _context.Product.Remove(product);

            return product;
        }

        public async Task<IEnumerable<ProductModel>> FindAllAsync()
        {
            var products = await _context.Product.ToListAsync();

            return products;
        }

        public async Task<ProductModel> FindByIdAsync(long id)
        {
            var product = await _context.Product.FindAsync(id);

            return product;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var saved = await _context.SaveChangesAsync();

            return saved >= 0;
        }

        public ProductModel FullUpdate(ProductModel product)
        {
            _context.Update(product);

            return product;
        }
    }
}