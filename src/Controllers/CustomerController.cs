using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.DTOs;
using e_commerce_api.src.Exceptions.CustomerExceptions;
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
            IEnumerable<CustomerResponseDTO> customers;

            try
            {
                customers = await _service.FindAllAsync();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok(customers);
        }

        [HttpGet("{id}", Name = "FindById")]
        public async Task<ActionResult<CustomerResponseDTO>> FindById(long id)
        {
            CustomerResponseDTO customer;

            try
            {
                customer = await _service.FindByIdAsync(id);
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponseDTO>> Create(CustomerRequestDTO customer)
        {
            CustomerResponseDTO createdCustomer;

            try
            {
                createdCustomer = await _service.CreateAsync(customer);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return CreatedAtAction(nameof(FindById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponseDTO>> Update(long id, CustomerRequestDTO customer)
        {
            CustomerResponseDTO updatedCustomer;
            try
            {
                updatedCustomer = await _service.UpdateAsync(id, customer);
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return updatedCustomer;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerResponseDTO>> Delete(long id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}