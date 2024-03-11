﻿using CleanArchMvc.Domain.Entities;
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
            return await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

		//public async Task<Product> GetWithCategoryAsync(int id)
		//{
		//	return await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
		//}

        public async Task<Product> CreateAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task<Product> UpdateAsync(Product product)
		{
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task DeleteAsync(Product product)
		{
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
		}
	}
}
