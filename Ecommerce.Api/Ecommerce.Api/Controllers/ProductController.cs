using AutoMapper;
using Ecommerce.Api.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("GetProductByName/{productName}")]
        public async Task<IEnumerable<ProductDTO>> GetProducts(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                var list = await _productService.GetProductList();
                var mapped = _mapper.Map<IEnumerable<ProductDTO>>(list);
                return mapped;
            }

            var listByName = await _productService.GetProductByName(productName);
            var mappedByName = _mapper.Map<IEnumerable<ProductDTO>>(listByName);
            return mappedByName;
        }

        [HttpGet("GetProductById/{productId}")]
        public async Task<ProductDTO> GetProductById(int productId)
        {
            var product = await _productService.GetProductById(productId);
            var mapped = _mapper.Map<ProductDTO>(product);
            return mapped;
        }

        [HttpPost]
        public async Task<ProductDTO> CreateProduct(ProductDTO productViewModel)
        {
            var mapped = _mapper.Map<Product>(productViewModel);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }

            var entityDto = await _productService.Create(mapped);
            var mappedViewModel = _mapper.Map<ProductDTO>(entityDto);
            return mappedViewModel;
        }

        [HttpPut]
        public async Task UpdateProduct(ProductDTO productViewModel)
        {
            var mapped = _mapper.Map<Product>(productViewModel);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }

            await _productService.Update(mapped);
        }

        [HttpDelete]
        public async Task DeleteProduct(ProductDTO productViewModel)
        {
            var mapped = _mapper.Map<Product>(productViewModel);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }

            await _productService.Delete(mapped);
        }
    }
}
