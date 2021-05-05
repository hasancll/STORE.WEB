using Microsoft.AspNetCore.Mvc;
using STORE.WEB.ApiService.Interfaces;
using STORE.WEB.CustomFilter;
using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.Controllers
{
    public class ProductModelController : Controller
    {
        private readonly IProductModelApiService _productModelApiService;
        public ProductModelController(IProductModelApiService productModelApiService)
        {
            _productModelApiService = productModelApiService;
        }
        [JwtAuthorize]
        public async Task<IActionResult> Index()
        {
            var models = await _productModelApiService.GetAllAsync().ConfigureAwait(false);
            return View(models);
        }
        public IActionResult AddProductModel()
        {
            return View();
        }
        [JwtAuthorize]
        [HttpPost]
        public async Task<IActionResult> AddProductModel(ProductModelDTO productModelDTO)
        {
            if (ModelState.IsValid)
            {
                await _productModelApiService.AddProductModelAsync(productModelDTO).ConfigureAwait(false);
                ModelState.AddModelError("", "Model başarıyla eklendi");
            }
            return View(productModelDTO);
        }
        [JwtAuthorize]
        public async Task<IActionResult> EditProductModel(int id)
        {

            return View(await _productModelApiService.GetByIdProductModelAsync(id).ConfigureAwait(false));
        }
        [JwtAuthorize]
        [HttpPost]
        public async Task<IActionResult> EditProductModel(ProductModelDTO productModelDTO)
        {
            if (ModelState.IsValid)
            {
                await _productModelApiService.UpdateModelAsync(productModelDTO).ConfigureAwait(false);
                //ViewBag.Status = "Model başarılı şekilde güncellendi";
                ModelState.AddModelError("", "Model başarılı bir şekilde güncellendi");
                //return RedirectToAction("EditProductModel", "ProductModel");
            }
            return View(productModelDTO);
        }
        [JwtAuthorize]
        public async Task<IActionResult> DeleteProductModel(int id)
        {
            await _productModelApiService.DeleteProductModelAsync(id).ConfigureAwait(false);
            return RedirectToAction("Index", "ProductModel");
        }

    }
}
