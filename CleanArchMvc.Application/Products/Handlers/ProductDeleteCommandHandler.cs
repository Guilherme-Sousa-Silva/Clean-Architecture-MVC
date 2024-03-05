using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductDeleteCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var productToRemove = await _productRepository.GetByIdAsync(request.Id);

            if (productToRemove == null)
            {
                throw new ApplicationException($"Erro ao encontrar entidade");
            }
            else
            {
                await _productRepository.DeleteAsync(request.Id);
                return productToRemove;
            }
        }
    }
}
