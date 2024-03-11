using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
	public interface ICategoryService
	{
		Task<IList<CategoryDTO>> GetAsync();
		Task<CategoryDTO> GetByIdAsync(int id);
		Task<CategoryDTO> CreateAsync(CategoryDTO categoryDTO);
		Task<CategoryDTO> UpdateAsync(CategoryDTO categoryDTO);
		Task<CategoryDTO> DeleteAsync(int id);
	}
}
