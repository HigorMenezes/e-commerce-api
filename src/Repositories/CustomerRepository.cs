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

        public CustomerModel Create(CustomerModel customer)
        {
            _context.Customer.Add(customer);

            return customer;
        }

        public async Task<IEnumerable<CustomerModel>> FindAllAsync()
        {
            var customers = await _context.Customer.ToListAsync();

            return customers;
        }

        public async Task<CustomerModel> FindByIdAsync(long id)
        {
            var customer = await _context.Customer.FindAsync(id);

            return customer;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var saved = await _context.SaveChangesAsync();

            return saved >= 0;
        }

        public CustomerModel Update(CustomerModel customer)
        {
            _context.Customer.Update(customer);

            return customer;
        }

        public CustomerModel Delete(CustomerModel customer)
        {
            _context.Customer.Remove(customer);

            return customer;
        }
    }
}