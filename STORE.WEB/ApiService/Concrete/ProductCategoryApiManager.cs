using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
    public class ProductCategoryApiManager : IProductCategoryApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductCategoryApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> AddProductCategoryAsync(ProductCategoryDTO productCategoryDTO)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Post, "ProductCategory", productCategoryDTO);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<ProductCategoryDTO>>(request).GetAwaiter().GetResult();
                return response.Message;
            }
            else
            {
                return "Giriş yapmalısınız";
            }
        }
        public async Task DeleteProductCategoryAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Delete, $"ProductCategory/{id}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductCategoryDTO>>>(request).GetAwaiter().GetResult();
                
            }
        }
        public async Task<List<ProductCategoryDTO>> GetAllAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductCategory");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductCategoryDTO>>>(request).GetAwaiter().GetResult();
                if (response.Response != null)
                {
                    return response.Response;
                }


            }
            return null;
        }
        public async Task<ProductCategoryDTO> GetByIdProductCategoryAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, $"ProductCategory/{id}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<DTOs.ProductCategoryDTO>>(request).GetAwaiter().GetResult();
                if (response.Response!=null)
                {
                    return response.Response;
                }
            }
            return null;
        }
        public async Task<string> UpdateCategoryAsync(ProductCategoryDTO productCategoryDTO)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Put,"ProductCategory",productCategoryDTO);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<DTOs.ProductCategoryDTO>>(request).GetAwaiter().GetResult();
                return response.Message;
            }
            return "Giriş yapmalısınız";
        }
    }
}
