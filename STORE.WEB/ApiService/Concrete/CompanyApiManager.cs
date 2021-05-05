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
    public class CompanyApiManager:ICompanyApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CompanyApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddCompany(CompanyDTO companyDTO)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Post, "Company", companyDTO);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<CompanyDTO>>(request).GetAwaiter().GetResult();
            }
        }

        public async Task<List<CompanyDTO>> GetAllCompanies()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {

                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "Company");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<List<DTOs.CompanyDTO>>>(request).GetAwaiter().GetResult();
                if (response.Response != null)
                {
                    return response.Response;
                }


            }
            return null;
        }

        public async Task<CompanyDTO> GetByIdCompany(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, $"Company/{id}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<DTOs.CompanyDTO>>(request).GetAwaiter().GetResult();
                if (response.Response != null)
                {
                    return response.Response;
                }
            }
            return null;
        }

        public async Task UpdateCompany(CompanyDTO companyDTO)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Put, "Company", companyDTO);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<DTOs.CompanyDTO>>(request).GetAwaiter().GetResult();
            }
        }
    }
}
