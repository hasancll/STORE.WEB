using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Polly;
using STORE.WEB.ApiService.Interfaces;
using STORE.WEB.CustomFilter;
using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace STORE.WEB.Controllers
{
    public class ProductController : Controller
    {       
        private readonly IProductApiService _productCategoryApiService;
        private readonly IProductCategoryApiService _dene;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductController(IProductApiService productApiService, IProductCategoryApiService dene, IHttpContextAccessor httpContextAccessor)
        {
            _productCategoryApiService = productApiService;
            _dene = dene;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [JwtAuthorize]
        public IActionResult AddProduct()
        {
            #region Viewbag
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductCategory");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductCategoryDTO>>>(request).GetAwaiter().GetResult();
            var request2 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductSize");
            request2.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response2 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductSizeDTO>>>(request2).GetAwaiter().GetResult();
            var request3 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductModel");
            request3.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response3 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request3).GetAwaiter().GetResult();
            var request4 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductColor");
            request4.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response4 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request4).GetAwaiter().GetResult();
            var Categories = new List<SelectListItem>();
            var sizes = new List<SelectListItem>();
            var Models = new List<SelectListItem>();
            var Colors = new List<SelectListItem>();
            foreach (var item in response.Response)
            {
                Categories.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Categories = Categories;
            foreach (var item in response2.Response)
            {
                sizes.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.sizes = sizes;
            foreach (var item in response3.Response)
            {
                Models.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Models = Models;
            foreach (var item in response4.Response)
            {
                Colors.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Colors = Colors;
            #endregion

            return View();
        }
        [JwtAuthorize]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            #region Viewbag
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductCategory");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductCategoryDTO>>>(request).GetAwaiter().GetResult();
            var request2 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductSize");
            request2.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response2 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductSizeDTO>>>(request2).GetAwaiter().GetResult();
            var request3 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductModel");
            request3.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response3 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request3).GetAwaiter().GetResult();
            var request4 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductColor");
            request4.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response4 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request4).GetAwaiter().GetResult();
            var Categories = new List<SelectListItem>();
            var sizes = new List<SelectListItem>();
            var Models = new List<SelectListItem>();
            var Colors = new List<SelectListItem>();
            foreach (var item in response.Response)
            {
                Categories.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Categories = Categories;
            foreach (var item in response2.Response)
            {
                sizes.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.sizes = sizes;
            foreach (var item in response3.Response)
            {
                Models.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Models = Models;
            foreach (var item in response4.Response)
            {
                Colors.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Colors = Colors;
            #endregion
            var product = await _productCategoryApiService.AddProductAsync(productDTO).ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                if (product != null)
                {
                    ViewBag.Status = "Ürün ekleme işlemi başarılı şekilde gerçekleşti";
                    return RedirectToAction("AddProduct", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Bu barkod numarasına ait ürün daha önceden eklenmiş durumdadır.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Ürün ekleme işlemi başarısız lütfen bilgileri tekrar kontrol ediniz");
            }
            return View(productDTO);
        }
        [JwtAuthorize]
        public IActionResult GetByBarcodeProduct()
        {
           
            return View();
            
        }
        [JwtAuthorize]
        [HttpGet]
        public async Task<IActionResult> GetByBarcodeProduct(string barcode)
        {
            int gun = 10;
            int gelen = 10;
            int sonuc = gun / gelen;
            ViewBag.Sayı = sonuc;
            return View(await _productCategoryApiService.GetByBarcodeProductAsync(barcode).ConfigureAwait(false));
        }
        [JwtAuthorize]
        public IActionResult DeleteProduct(int id)
        {
            _productCategoryApiService.DeleteByProductAsync(id);
            return RedirectToAction("GetByBarcodeProduct", "Product");
        }
        [JwtAuthorize]
        public async Task<IActionResult> EditProduct(int id)
        {
            #region Viewbag
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductCategory");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductCategoryDTO>>>(request).GetAwaiter().GetResult();
            var request2 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductSize");
            request2.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response2 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductSizeDTO>>>(request2).GetAwaiter().GetResult();
            var request3 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductModel");
            request3.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response3 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request3).GetAwaiter().GetResult();
            var request4 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductColor");
            request4.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response4 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request4).GetAwaiter().GetResult();
            var Categories = new List<SelectListItem>();
            var sizes = new List<SelectListItem>();
            var Models = new List<SelectListItem>();
            var Colors = new List<SelectListItem>();
            foreach (var item in response.Response)
            {
                Categories.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Categories = Categories;
            foreach (var item in response2.Response)
            {
                sizes.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.sizes = sizes;
            foreach (var item in response3.Response)
            {
                Models.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Models = Models;
            foreach (var item in response4.Response)
            {
                Colors.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Colors = Colors;
            #endregion

            return View(await _productCategoryApiService.GetByIdProduct(id).ConfigureAwait(false));
        }
        [JwtAuthorize]
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductDTO productDTO)
        {
            #region Viewbag
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductCategory");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductCategoryDTO>>>(request).GetAwaiter().GetResult();
            var request2 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductSize");
            request2.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response2 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductSizeDTO>>>(request2).GetAwaiter().GetResult();
            var request3 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductModel");
            request3.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response3 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request3).GetAwaiter().GetResult();
            var request4 = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductColor");
            request4.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response4 = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request4).GetAwaiter().GetResult();
            var Categories = new List<SelectListItem>();
            var sizes = new List<SelectListItem>();
            var Models = new List<SelectListItem>();
            var Colors = new List<SelectListItem>();
            foreach (var item in response.Response)
            {
                Categories.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Categories = Categories;
            foreach (var item in response2.Response)
            {
                sizes.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.sizes = sizes;
            foreach (var item in response3.Response)
            {
                Models.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Models = Models;
            foreach (var item in response4.Response)
            {
                Colors.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Colors = Colors;
            #endregion

            if (ModelState.IsValid)
            {
                await _productCategoryApiService.UpdateProductAsync(productDTO).ConfigureAwait(false);
                ViewBag.Status = "Ürün başarılı bir şekilde güncellendi";
                return RedirectToAction("GetByBarcodeProduct", "Product");                
            }
            else
            {
                ModelState.AddModelError("", "Ürün güncelleme işlemi başarısız oldu lütfen bilgileri kontrol ediniz.");
            }
            return View(productDTO);

        }
    }
}
