using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO Category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateAsync(Category);
                return RedirectToAction(nameof(Index));
            }
            return View(Category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDto = await _categoryService.GetByIdAsync(id);
            if (categoryDto == null)
                return NotFound($"Categoria não encontrada pelo id: {id}");

            return View(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.UpdateAsync(categoryDTO);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDTO);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDto = await _categoryService.GetByIdAsync(id);
            if (categoryDto == null)
                return NotFound($"Categoria não encontrada pelo id: {id}");

            return View(categoryDto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var categoryDto = await _categoryService.GetByIdAsync(id);
            if (categoryDto == null)
                return NotFound($"Categoria não encontrada pelo id: {id}");

            return View(categoryDto);
        }
    }
}
