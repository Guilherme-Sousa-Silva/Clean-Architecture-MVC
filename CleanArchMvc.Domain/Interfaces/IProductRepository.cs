﻿using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
	public interface IProductRepository
	{
		Task<IList<Product>> GetAsync();
		Task<Product> GetByIdAsync(int id);
		Task<Product> CreateAsync(Product category);
		Task<Product> UpdateAsync(Product category);
		Task DeleteAsync(int id);
	}
}
