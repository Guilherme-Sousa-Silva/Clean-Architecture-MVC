using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
	public interface IProductRepository
	{
		Task<IList<Product>> GetAsync();
		Task<Product> GetByIdAsync(int id);
        //Task<Product> GetWithCategoryAsync(int id);
        Task<Product> CreateAsync(Product product);
		Task<Product> UpdateAsync(Product product);
		Task DeleteAsync(Product product);
	}
}
