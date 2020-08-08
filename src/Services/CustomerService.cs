using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using e_commerce_api.src.DTOs;
using e_commerce_api.src.Exceptions.CustomerExceptions;
using e_commerce_api.src.Models;
using e_commerce_api.src.Repositories;

namespace e_commerce_api.src.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerResponseDTO> CreateAsync(CustomerRequestDTO customer)
        {
            var customerModel = _mapper.Map<CustomerModel>(customer);
            var createdCustomer = _repository.Create(customerModel);

            await _repository.SaveChangesAsync();

            return _mapper.Map<CustomerResponseDTO>(createdCustomer);
        }

        public async Task<IEnumerable<CustomerResponseDTO>> FindAllAsync()
        {
            var customers = await _repository.FindAllAsync();

            return _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
        }

        public async Task<CustomerResponseDTO> FindByIdAsync(long id)
        {
            var customer = await _repository.FindByIdAsync(id);

            if (customer == null)
            {
                throw new CustomerNotFoundException(String.Format("Customer with the id '{0}' was not found", id));
            }

            return _mapper.Map<CustomerResponseDTO>(customer);
        }

        public async Task<CustomerResponseDTO> UpdateAsync(long id, CustomerRequestDTO customer)
        {
            var currentCustomer = await _repository.FindByIdAsync(id);

            if (currentCustomer == null)
            {
                throw new CustomerNotFoundException(String.Format("Customer with the id '{0}' was not found", id));
            }

            _mapper.Map(customer, currentCustomer);
            var updatedCustomer = _repository.Update(currentCustomer);

            await _repository.SaveChangesAsync();

            return _mapper.Map<CustomerResponseDTO>(updatedCustomer);
        }

        public async Task<CustomerResponseDTO> DeleteAsync(long id)
        {
            var customerToDelete = await _repository.FindByIdAsync(id);

            if (customerToDelete == null)
            {
                throw new CustomerNotFoundException(String.Format("Customer with the id '{0}' was not found", id));
            }

            var deletedCustomer = _repository.Delete(customerToDelete);

            await _repository.SaveChangesAsync();

            return _mapper.Map<CustomerResponseDTO>(deletedCustomer);
        }
    }
}