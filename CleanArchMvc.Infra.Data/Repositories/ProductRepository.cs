using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;
		public ProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IList<Product>> GetAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Product> CreateAsync(Product category)
		{
			await _context.Products.AddAsync(category);
			await _context.SaveChangesAsync();
			return category;
		}

		public async Task<Product> UpdateAsync(Product category)
		{
			_context.Products.Update(category);
			await _context.SaveChangesAsync();
			return category;
		}

		public async Task DeleteAsync(int id)
		{
			var productToDelete = await GetByIdAsync(id);
			_context.Products.Remove(productToDelete);
			await _context.SaveChangesAsync();
		}
	}
}
