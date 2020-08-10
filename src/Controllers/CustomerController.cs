using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.DTOs.CustomerDTOs;
using e_commerce_api.src.Exceptions.CustomerExceptions;
using e_commerce_api.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace e_commerce_api.src.Controllers
{
    [Route("v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService service, ILogger<CustomerController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> FindAllAsync()
        {
            IEnumerable<CustomerResponseDTO> customers;

            try
            {
                customers = await _service.FindAllAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500);
            }

            return Ok(customers);
        }

        [HttpGet("{id}", Name = "FindCustomerById")]
        public async Task<ActionResult<CustomerResponseDTO>> FindByIdAsync(long id)
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
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500);
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponseDTO>> CreateAsync(CustomerRequestDTO customer)
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

            return CreatedAtRoute("FindCustomerById", new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponseDTO>> FullUpdateAsync(long id, CustomerRequestDTO customer)
        {
            CustomerResponseDTO updatedCustomer;
            try
            {
                updatedCustomer = await _service.FullUpdateAsync(id, customer);
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500);
            }

            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}