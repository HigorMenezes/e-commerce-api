using System.Threading.Tasks;
using AutoMapper;
using e_commerce_api.src.DTOs.CartDTOs;
using e_commerce_api.src.Models;
using e_commerce_api.src.Repositories;

namespace e_commerce_api.src.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CartService(
            ICartRepository cartRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        private async Task<CustomerModel> FindCustomerById(long id)
        {
            var customer = await _customerRepository.FindByIdAsync(id);

            return customer;
        }

        private async Task<ProductModel> FindProductById(long id)
        {
            var product = await _productRepository.FindByIdAsync(id);

            return product;
        }

        public async Task<CartResponseDTO> CreateAsync(CartRequestDTO cart)
        {
            var cartModel = _mapper.Map<CartModel>(cart);

            var customer = await FindCustomerById(cart.CustomerId);
            var product = await FindProductById(cart.ProductId);

            cartModel.Customer = customer;
            cartModel.Product = product;

            var createdCart = _cartRepository.Create(cartModel);

            await _cartRepository.SaveChangesAsync();

            return _mapper.Map<CartResponseDTO>(createdCart);
        }
    }
}