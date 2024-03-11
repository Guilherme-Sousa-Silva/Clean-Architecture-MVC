using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Repositories;

namespace CleanArchMvc.Application.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		public async Task<IList<CategoryDTO>> GetAsync()
		{
			var categories = await _categoryRepository.GetAsync();
			return _mapper.Map<IList<CategoryDTO>>(categories);
		}

		public async Task<CategoryDTO> GetByIdAsync(int id)
		{
			var product = await _categoryRepository.GetByIdAsync(id);
			return _mapper.Map<CategoryDTO>(product);
		}

		public async Task<CategoryDTO> CreateAsync(CategoryDTO categoryDTO)
		{
			var category = _mapper.Map<Category>(categoryDTO);
			var createdCategory = await _categoryRepository.CreateAsync(category);
			return _mapper.Map<CategoryDTO>(createdCategory);
		}

		public async Task<CategoryDTO> UpdateAsync(CategoryDTO categoryDTO)
		{
			var category = _mapper.Map<Category>(categoryDTO);
			var updatedCategory = await _categoryRepository.UpdateAsync(category);
			return _mapper.Map<CategoryDTO>(updatedCategory);
		}

		public async Task<CategoryDTO> DeleteAsync(int id)
		{
			var categoryToDelete = await GetByIdAsync(id);
			await _categoryRepository.DeleteAsync(id);

			return categoryToDelete;
        }
	}
}
