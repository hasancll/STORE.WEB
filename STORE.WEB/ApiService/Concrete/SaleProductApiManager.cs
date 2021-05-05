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
    public class SaleProductApiManager : ISaleProductApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SaleProductApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<SoldProductDTO> GetProductFilter(SaleFilter saleFilter)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {

                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Post, "SaleProduct",saleFilter);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<SoldProductDTO>>(request).GetAwaiter().GetResult();
                //response.Response.SoldAmount bu üründen toplam kaöç tane satılmış butada geliyor. anladınmıoke

                if (response.Response != null)
                {
                    //return response.Response;
                }
            }
            return null;
        }
    }
}
