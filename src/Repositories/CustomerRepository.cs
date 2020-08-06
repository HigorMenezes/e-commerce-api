using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using e_commerce_api.src.Contexts;
using e_commerce_api.src.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.src.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ECommerceContext _context;

        public CustomerRepository(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerModel>> FindAll()
        {
            var customers = await _context.Customer.ToListAsync();

            return customers;
        }

        public async Task<CustomerModel> FindById(long id)
        {
            var customer = await _context.Customer.FindAsync(id);

            return customer;
        }

        public async Task<bool> SaveChanges()
        {
            var saved = await _context.SaveChangesAsync();

            return saved >= 0;
        }


    }
}