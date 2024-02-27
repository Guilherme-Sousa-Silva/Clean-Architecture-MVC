using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
	internal interface ICategoryRepository
	{
		Task<IList<Category>> GetAsync();
		Task<Category> GetByIdAsync(int id);
		Task<Category> CreateAsync(Category category);
		Task<Category> UpdateAsync(Category category);
		Task<Category> DeleteAsync(Category category);
	}
}
