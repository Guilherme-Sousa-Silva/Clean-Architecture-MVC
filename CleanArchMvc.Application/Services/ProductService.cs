using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Handlers;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Services
{
	public class ProductService : IProductService
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public ProductService(IMediator mediator, IMapper mapper)
		{
            _mediator = mediator;
            _mapper = mapper;
		}

		public async Task<IList<ProductDTO>> GetAsync()
		{
			var productsQuery = new GetProductsQuery();
			if (productsQuery == null)
			{
				throw new ApplicationException($"Não foi possível carregar a entidade.");
			}

			var result = await _mediator.Send(productsQuery);
			return _mapper.Map<IList<ProductDTO>>(result);
		}

		public async Task<ProductDTO> GetByIdAsync(int id)
		{
            var product = new GetProductByIdQuery(id);
            if (product == null)
            {
                throw new ApplicationException($"Não foi possível carregar a entidade.");
            }
			var result = _mediator.Send(product);
			return _mapper.Map<ProductDTO>(result);
		}

		public async Task<ProductDTO> CreateAsync(ProductDTO productDTO)
		{
            var productCommand = _mapper.Map<ProductCreatCommand>(productDTO);
			var createdProduct = await _mediator.Send(productCommand);
			return _mapper.Map<ProductDTO>(createdProduct);
		}

		public async Task<ProductDTO> UpdateAsync(ProductDTO productDTO)
		{
            var productCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            var updatedProduct = await _mediator.Send(productCommand);
            return _mapper.Map<ProductDTO>(updatedProduct);
		}

		public async Task DeleteAsync(int id)
		{
			var productCommand = new ProductRemoveCommand(id);
			await _mediator.Send(productCommand);
		}
	}
}
