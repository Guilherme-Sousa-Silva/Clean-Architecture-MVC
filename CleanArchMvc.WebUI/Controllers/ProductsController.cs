using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAsync(), "Id", "Name");
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if(ModelState.IsValid)
            {
                await _productService.CreateAsync(productDTO);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAsync(), "Id", "Name");
            }

            return View(productDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound($"Não foi possivel encontrar o produto pelo id: {id}");

            var categories = await _categoryService.GetAsync();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(productDTO);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAsync(), "Id", "Name");
            }

            return View(productDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound($"Não foi possivel encontrar o produto pelo id: {id}");

            var categories = await _categoryService.GetAsync();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
