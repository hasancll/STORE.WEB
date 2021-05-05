using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class UserViewModelResource
    {
        [Required(ErrorMessage = "*Kullanıcı adı boş geçilmemelidir.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "*Email alanı boş geçilmemelidir.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*Şifre alanı boş bırakılmamalıdır.")]
        [MinLength(4,ErrorMessage ="Şifre 4 karakterden az olmamalıdır.")]
        public string Password { get; set; }
    }
}
