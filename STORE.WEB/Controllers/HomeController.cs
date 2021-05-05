using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using STORE.WEB.ApiService.Interfaces;
using STORE.WEB.CustomFilter;
using STORE.WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace STORE.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductCategoryApiService _productCategoryApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IProductCategoryApiService productCategoryApiService,IHttpContextAccessor httpContextAccessor)
        {
            _productCategoryApiService = productCategoryApiService;
            _httpContextAccessor = httpContextAccessor;
        }
        [JwtAuthorize]
        public async Task<IActionResult> Index()
        {
            
            return View();
        }
        [JwtAuthorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
