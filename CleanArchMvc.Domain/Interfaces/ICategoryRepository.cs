using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
	public interface ICategoryRepository
	{
		Task<IList<Category>> GetAsync();
		Task<Category> GetByIdAsync(int id);
		Task<Category> CreateAsync(Category category);
		Task<Category> UpdateAsync(Category category);
		Task DeleteAsync(int id);
	}
}
