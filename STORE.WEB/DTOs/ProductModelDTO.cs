using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class ProductModelDTO : BaseDTO
    {
        [Required(ErrorMessage = "Ad Alanı Boş Geçilemez!")]
        public string Name { get; set; }
    }
}
