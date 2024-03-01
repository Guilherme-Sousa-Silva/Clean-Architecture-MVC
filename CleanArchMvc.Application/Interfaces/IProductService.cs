using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
	public interface IProductService
	{
		Task<IList<ProductDTO>> GetAsync();
		Task<ProductDTO> GetByIdAsync(int id);
		Task<ProductDTO> CreateAsync(ProductDTO productDTO);
		Task<ProductDTO> UpdateAsync(ProductDTO productDTO);
		Task DeleteAsync(int id);
	}
}
