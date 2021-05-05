using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class CompanyDTO:BaseDTO
    {
        [Required(ErrorMessage = "Ad Alanı Boş Geçilemez!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Adres Alanı Boş Geçilemez!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Numara Alanı Boş Geçilemez!")]
        public string Number { get; set; }
    }
}
