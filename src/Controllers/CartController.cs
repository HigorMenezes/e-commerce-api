using System;
using System.Threading.Tasks;
using e_commerce_api.src.DTOs.CartDTOs;
using e_commerce_api.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace e_commerce_api.src.Controllers
{
    [Route("v1/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;
        private readonly ILogger _logger;

        public CartController(ICartService service, ILogger<CartController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<CartResponseDTO>> CreateAsync(CartRequestDTO cart)
        {
            CartResponseDTO createdCart;

            try
            {
                createdCart = await _service.CreateAsync(cart);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500);
            }

            return Ok(createdCart);
        }

    }
}