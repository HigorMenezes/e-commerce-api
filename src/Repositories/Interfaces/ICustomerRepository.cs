using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.Models;

namespace e_commerce_api.src.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> SaveChangesAsync();
        CustomerModel Create(CustomerModel customer);
        Task<IEnumerable<CustomerModel>> FindAllAsync();
        Task<CustomerModel> FindByIdAsync(long id);
        CustomerModel Update(CustomerModel customer);
    }
}