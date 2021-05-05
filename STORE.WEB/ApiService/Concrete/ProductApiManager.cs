using Microsoft.AspNetCore.Http;
using STORE.WEB.ApiService.Interfaces;
using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace STORE.WEB.ApiService.Concrete
{
    public class ProductApiManager : IProductApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Post, "Product", productDTO);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<ProductDTO>>(request).GetAwaiter().GetResult();
                if (response.Response.Barcode != null)
                {
                    return productDTO;
                }
            }
            return null;
        }

        public void DeleteByProductAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Delete, $"Product/{id}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<ProductDTO>>(request).GetAwaiter().GetResult();
                
            }

        }

        public async Task<ProductDTO> GetByBarcodeProductAsync(string barcode)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, $"Product/Barcode/{barcode}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<ProductDTO>>(request).GetAwaiter().GetResult();
                if (response.Response != null)
                {
                    return response.Response;
                }
            }
            return null;
        }

        public async Task<ProductDTO> GetByIdProduct(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, $"Product/{id}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<ProductDTO>>(request).GetAwaiter().GetResult();
                if (response.Response != null)
                {
                    return response.Response;
                }
            }
            return null;
        }
        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Put, "Product", productDTO);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<DTOs.ProductDTO>>(request).GetAwaiter().GetResult();
            }
        }
    }
}
