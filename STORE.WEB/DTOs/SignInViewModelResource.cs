using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class SignInViewModelResource
    {
        [Required(ErrorMessage ="Kullanıcı adı alanı bpş bıraklımaz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        public string Password { get; set; }
    }
}
