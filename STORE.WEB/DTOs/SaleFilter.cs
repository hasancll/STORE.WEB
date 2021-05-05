using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class SaleFilter
    {
        [Required(ErrorMessage = "Barkod alanı boş bırakılamaz.")]
        public String Barcode { get; set; }
        public DateTime? LowDate { get; set; }
        public DateTime? TopDate { get; set; }
    }
}
