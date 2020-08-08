using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using e_commerce_api.src.DTOs;
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

        public async Task<CustomerResponseDTO> Create(CustomerRequestDTO customer)
        {
            var customerModel = _mapper.Map<CustomerModel>(customer);
            var customerCreated = _repository.Create(customerModel);

            await _repository.SaveChangesAsync();

            return _mapper.Map<CustomerResponseDTO>(customerCreated);
        }

        public async Task<IEnumerable<CustomerResponseDTO>> FindAll()
        {
            var customers = await _repository.FindAllAsync();

            return _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
        }

        public async Task<CustomerResponseDTO> FindById(long id)
        {
            var customer = await _repository.FindByIdAsync(id);

            return _mapper.Map<CustomerResponseDTO>(customer);
        }

    }
}