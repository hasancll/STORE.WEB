using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class ChangePasswordModelViewResource
    {
        [Required(ErrorMessage = "Email Alanı Boş Geçilemez!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez!")]
        [MinLength(4, ErrorMessage = "Şifre 4 karakterden az olmamalıdır.")]
        public string NewPassword { get; set; }
        public string CurrentPassword { get; set; }
    }
}
