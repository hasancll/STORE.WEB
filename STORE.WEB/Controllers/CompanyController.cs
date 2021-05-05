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
    public class CompanyController : Controller
    {
        private readonly ICompanyApiService _companyApiService;
        public CompanyController(ICompanyApiService companyApiService)
        {
            _companyApiService = companyApiService;
        }
        [JwtAuthorize]
        public async Task<IActionResult> Index()
        {

            return View(await _companyApiService.GetAllCompanies().ConfigureAwait(false));
        }
        [JwtAuthorize]
        public IActionResult AddCompany()
        {
            return View();
        }
        [JwtAuthorize]
        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyDTO companyDTO)
        {
            if (ModelState.IsValid)
            {
                await _companyApiService.AddCompany(companyDTO).ConfigureAwait(false);
                ModelState.AddModelError("", "Kurum başarıyla eklendi");
            }
            return View(companyDTO);
        }
        [JwtAuthorize]
        public async Task<IActionResult> EditCompany(int id)
        {
            return View(await _companyApiService.GetByIdCompany(id).ConfigureAwait(false));
        }
        [JwtAuthorize]
        [HttpPost]
        public async Task<IActionResult> EditCompany(CompanyDTO companyDTO)
        {
            if (ModelState.IsValid)
            {
                await _companyApiService.UpdateCompany(companyDTO).ConfigureAwait(false);
                ModelState.AddModelError("", "Kurum başarıyla güncellendi");
            }
            return View(companyDTO);
        }
    }
}
