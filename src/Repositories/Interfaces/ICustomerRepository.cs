using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.Models;

namespace e_commerce_api.src.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<CustomerModel>> FindAllAsync();
        Task<CustomerModel> FindByIdAsync(long id);
        CustomerModel Create(CustomerModel customer);
    }
}