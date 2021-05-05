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
    public class ProductModelApiManager : IProductModelApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductModelApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AddProductModelAsync(ProductModelDTO productModelDTO)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Post, "ProductModel", productModelDTO);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<ProductModelDTO>>(request).GetAwaiter().GetResult();
            }
        }

        public async Task DeleteProductModelAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Delete, $"ProductModel/{id}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request).GetAwaiter().GetResult();

            }
        }

        public async Task<List<ProductModelDTO>> GetAllAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {

                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "ProductModel");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.ProductModelDTO>>>(request).GetAwaiter().GetResult();
                if (response.Response != null)
                {
                    return response.Response;
                }
            }            
            return null;
        }

        public async Task<ProductModelDTO> GetByIdProductModelAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, $"ProductModel/{id}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<DTOs.ProductModelDTO>>(request).GetAwaiter().GetResult();
                if (response.Response != null)
                {
                    return response.Response;
                }
            }
            return null;
        }

        public async Task UpdateModelAsync(ProductModelDTO productModelDTO)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Put, "ProductModel", productModelDTO);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<DTOs.ProductModelDTO>>(request).GetAwaiter().GetResult();
            }
            // return null;
        }
    }
}
