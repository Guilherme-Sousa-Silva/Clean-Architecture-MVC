using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<IList<ProductDTO>> GetAsync()
		{
			var products = await _productRepository.GetAsync();
			return _mapper.Map<IList<ProductDTO>>(products);
		}

		public async Task<ProductDTO> GetByIdAsync(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			return _mapper.Map<ProductDTO>(product);
		}

		public async Task<ProductDTO> CreateAsync(ProductDTO productDTO)
		{
			var product = _mapper.Map<Product>(productDTO);
			var createdProduct = await _productRepository.CreateAsync(product);
			return _mapper.Map<ProductDTO>(createdProduct);
		}

		public async Task<ProductDTO> UpdateAsync(ProductDTO productDTO)
		{
			var product = _mapper.Map<Product>(productDTO);
			var updatedProduct = await _productRepository.UpdateAsync(product);
			return _mapper.Map<ProductDTO>(updatedProduct);
		}

		public async Task DeleteAsync(int id)
		{
			await _productRepository.DeleteAsync(id);
		}
	}
}
