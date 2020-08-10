using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using e_commerce_api.src.DTOs.ProductDTOs;
using e_commerce_api.src.Exceptions.ProductExceptions;
using e_commerce_api.src.Models;
using e_commerce_api.src.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace e_commerce_api.src.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponseDTO> CreateAsync(ProductRequestDTO product)
        {
            var productModel = _mapper.Map<ProductModel>(product);
            var createdProduct = _repository.Create(productModel);

            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductResponseDTO>(createdProduct);
        }

        public async Task<ProductResponseDTO> DeleteAsync(long id)
        {
            var productToDelete = await _repository.FindByIdAsync(id);

            if (productToDelete == null)
            {
                throw new ProductNotFoundException(String.Format("Product with the id '{0}' was not found", id));
            }

            var deletedProduct = _repository.Delete(productToDelete);

            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductResponseDTO>(deletedProduct);
        }

        public async Task<IEnumerable<ProductResponseDTO>> FindAllAsync()
        {
            var products = await _repository.FindAllAsync();

            return _mapper.Map<IEnumerable<ProductResponseDTO>>(products);
        }

        public async Task<ProductResponseDTO> FindByIdAsync(long id)
        {
            var product = await _repository.FindByIdAsync(id);

            if (product == null)
            {
                throw new ProductNotFoundException(String.Format("Product with the id '{0}' was not found", id));
            }

            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO> FullUpdateAsync(long id, ProductRequestDTO product)
        {
            var currentProduct = await _repository.FindByIdAsync(id);

            if (currentProduct == null)
            {
                throw new ProductNotFoundException(String.Format("Product with the id '{0}' was not found", id));
            }

            var updatedProduct = _mapper.Map(product, currentProduct);

            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductResponseDTO>(updatedProduct);
        }

        public async Task<ProductResponseDTO> PartialUpdateAsync(long id, ProductUpdateRequestDTO product)
        {
            var currentProduct = await _repository.FindByIdAsync(id);

            if (currentProduct == null)
            {
                throw new ProductNotFoundException(String.Format("Product with the id '{0}' was not found", id));
            }

            _mapper.Map(product, currentProduct);

            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductResponseDTO>(currentProduct);
        }
    }
}