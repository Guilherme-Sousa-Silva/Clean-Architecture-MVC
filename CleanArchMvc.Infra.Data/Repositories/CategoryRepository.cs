using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _context;

		public CategoryRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IList<Category>> GetAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<Category> GetByIdAsync(int id)
		{
			return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Category> CreateAsync(Category category)
		{
			await _context.AddAsync(category);
			await _context.SaveChangesAsync();
			return category;
		}

		public async Task<Category> UpdateAsync(Category category)
		{
			_context.Update(category);
			await _context.SaveChangesAsync();
			return category;
		}

		public async Task DeleteAsync(int id)
		{
			var categoryToDelete = await GetByIdAsync(id);
			_context.Remove(categoryToDelete);
			await _context.SaveChangesAsync();
		}
	}
}
