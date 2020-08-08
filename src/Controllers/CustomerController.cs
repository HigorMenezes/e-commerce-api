using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.DTOs;
using e_commerce_api.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.src.Controllers
{

    [Route("v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> FindAll()
        {
            var customers = await _service.FindAllAsync();

            return Ok(customers);
        }

        [HttpGet("{id}", Name = "FindById")]
        public async Task<ActionResult<CustomerResponseDTO>> FindById(long id)
        {
            var customers = await _service.FindByIdAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponseDTO>> Create(CustomerRequestDTO customer)
        {
            var customerCreated = await _service.CreateAsync(customer);

            return CreatedAtAction(nameof(FindById), new { id = customerCreated.Id }, customerCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponseDTO>> Update(long id, CustomerRequestDTO customer)
        {
            var newCustomer = await _service.UpdateAsync(id, customer);

            return newCustomer;
        }
    }
}