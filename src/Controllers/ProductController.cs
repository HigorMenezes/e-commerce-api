

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce_api.src.DTOs.ProductDTOs;
using e_commerce_api.src.Exceptions.ProductExceptions;
using e_commerce_api.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace e_commerce_api.src.Controllers
{
    [Route("v1/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger _logger;

        public ProductController(IProductService service, ILogger<ProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> FindAllAsync()
        {
            IEnumerable<ProductResponseDTO> products;

            try
            {
                products = await _service.FindAllAsync();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok(products);
        }

        [HttpGet("{id}", Name = "FindProductById")]
        public async Task<ActionResult<ProductResponseDTO>> FindByIdAsync(long id)
        {
            ProductResponseDTO product;

            try
            {
                product = await _service.FindByIdAsync(id);
            }
            catch (ProductNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDTO>> CreateAsync(ProductRequestDTO product)
        {
            ProductResponseDTO createdProduct;

            try
            {
                createdProduct = await _service.CreateAsync(product);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return CreatedAtRoute("FindProductById", new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> FullUpdateAsync(long id, ProductRequestDTO product)
        {
            ProductResponseDTO updatedProduct;

            try
            {
                updatedProduct = await _service.FullUpdateAsync(id, product);
            }
            catch (ProductNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch (ProductNotFoundException)
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