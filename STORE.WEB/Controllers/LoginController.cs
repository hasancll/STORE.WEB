using Microsoft.AspNetCore.Mvc;
using STORE.WEB.ApiService.Concrete;
using STORE.WEB.ApiService.Interfaces;
using STORE.WEB.CustomFilter;
using STORE.WEB.DTOs;
using STORE.WEB.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace STORE.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModelViewResource changePasswordModelViewResource)
        {
           bool status= await _authService.ChangePasswordUser(changePasswordModelViewResource).ConfigureAwait(false);
            if (ModelState.IsValid)
            {
               
                if (status == true)
                {
                    ViewBag.Status = "Şifre değiştirme işlemi başarılı bir şekilde gerçekleşti";
                }
                else
                {

                    ViewBag.Status = "Eski şifre veya email yanlıştır.";
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModelResource signInViewModelResource)
        {
            if (ModelState.IsValid)
            {
                if(await _authService.SignIn(signInViewModelResource))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Yanlış");
                }
                
            }
            return View(signInViewModelResource);

        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModelResource userViewModelResource)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.SignUp(userViewModelResource).ConfigureAwait(false) != null)
                {
                    ModelState.AddModelError("", "Kayıt işlemi başarılı");
                }
                else
                {
                    ModelState.AddModelError("", "Aynı Kullanıcı adı yada email kayıtlıdır.");
                }
            }
          
            return View(userViewModelResource);
        }
        public async Task<IActionResult> ResetPassword()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(PasswordResetViewModelResource passwordResetViewModelResource)
        {
            if (ModelState.IsValid)
            {
                await _authService.ResetPasswordMail(passwordResetViewModelResource).ConfigureAwait(false);
                ViewBag.Status = "E-Posta gönderilmiştir.Mailinizi kontrol ediniz";
            }
            else
            {
                ViewBag.Status = "Geçersiz bir e-posta adresi girdiniz";
            }
            return View();
        }

    }
}
