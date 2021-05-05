using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using STORE.WEB.ApiService.Interfaces;
using STORE.WEB.DTOs;
using STORE.WEB.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace STORE.WEB.ApiService.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> ChangePasswordUser(ChangePasswordModelViewResource changePasswordModelViewResource)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Post, "Authentication/ChangePassword", changePasswordModelViewResource);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<DTOs.ChangePasswordModelViewResource>>(request).GetAwaiter().GetResult();
                return true;
            }
            return false;

        }

        public void LogOut()
        {
            _httpContextAccessor.HttpContext.Session.Remove("token");
        }

        public async Task<bool> ResetPasswordMail(PasswordResetViewModelResource passwordResetViewModelResource)
        {
            var request =Helper.RequestHelper.HttpRequestMessage(HttpMethod.Post, "Authentication/ResetPassword", passwordResetViewModelResource);
            var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<PasswordResetViewModelResource>>(request).GetAwaiter().GetResult();
            if (response.Response!=null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SignIn(SignInViewModelResource signInViewModelResource)
        {
            var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Post, "Authentication/SignIn", signInViewModelResource);
            var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<AccessToken>>(request).GetAwaiter().GetResult();
            if (response.Response.Token!=null)
            {

                _httpContextAccessor.HttpContext.Session.SetString("token",response.Response.Token);

                return true;
            }
            else
            {
                return false;
            }
            
        }
        public async Task<UserViewModelResource> SignUp(UserViewModelResource userViewModelResource)
        {
            var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Post, "Authentication/SignUp", userViewModelResource);
            var response = Helper.RequestHelper.GetHttpResponseSingleAsync<DTOs.StoreResponseModel<UserViewModelResource>>(request).GetAwaiter().GetResult();
            if (response.Response.Email !=null)
            {
                return response.Response;
            }
            else
            {
                return null;
            }
           

        }
    }
}
