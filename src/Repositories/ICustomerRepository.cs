using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.Models;

namespace e_commerce_api.src.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> SaveChanges();
        Task<IEnumerable<CustomerModel>> FindAll();
        Task<CustomerModel> FindById(long id);
    }
}