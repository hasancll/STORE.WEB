using Microsoft.AspNetCore.Mvc;
using STORE.WEB.ApiService.Interfaces;
using STORE.WEB.CustomFilter;
using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using X.PagedList;

namespace STORE.WEB.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryApiService _productCategoryApiService;

        public ProductCategoryController(IProductCategoryApiService productCategoryApiService)
        {
            _productCategoryApiService = productCategoryApiService;
        }
        [JwtAuthorize]
        public async Task<IActionResult> Index()
        {
            var model = await _productCategoryApiService.GetAllAsync().ConfigureAwait(false);
            return View(model);
        }
        [JwtAuthorize]
        public IActionResult AddProductCategory()
        {
            return View();
        }
        [JwtAuthorize]
        [HttpPost]
        public async Task<IActionResult> AddProductCategory(ProductCategoryDTO productCategoryDTO)
        {
            if (ModelState.IsValid)
            {                
                ViewBag.Status = await _productCategoryApiService.AddProductCategoryAsync(productCategoryDTO).ConfigureAwait(false);             
            }
            return View(productCategoryDTO);
        }
        [JwtAuthorize]
        public async Task<IActionResult> EditProductCategory(int id)
        {
            return View(await _productCategoryApiService.GetByIdProductCategoryAsync(id).ConfigureAwait(false));
        }
        [JwtAuthorize]
        [HttpPost]
        public async Task<IActionResult> EditProductCategory(ProductCategoryDTO productCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _productCategoryApiService.UpdateCategoryAsync(productCategoryDTO).ConfigureAwait(false);
                return RedirectToAction("Index", "ProductCategory");
            }
            return View(productCategoryDTO);
        }
        [JwtAuthorize]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            await _productCategoryApiService.DeleteProductCategoryAsync(id).ConfigureAwait(false);
            return RedirectToAction("Index", "ProductCategory");
        }
    }
}
