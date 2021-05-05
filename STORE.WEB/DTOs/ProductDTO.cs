using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class ProductDTO:BaseDTO
    {
        public String Description { get; set; }
        [Required(ErrorMessage ="Barcode Alanı Boş Geçilemez!")]
        public String Barcode { get; set; }
        [Required(ErrorMessage = "Kod Boş Geçilemez!")]
        public String ProductCode { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual ProductCategoryDTO ProductCategoryDTO { get; set; }
        public int ProductColorId { get; set; }
        public virtual ProductColorDTO ProductColorDTO { get; set; }
        public int ProductSizeId { get; set; }
        public virtual ProductSizeDTO ProductSizeDTO { get; set; }
        public int ProductModelId { get; set; }
        public virtual ProductModelDTO ProductModelDTO { get; set; }
        public int ProductStockId { get; set; }
        public virtual ProductStockDTO ProductStockDTO { get; set; }
        [Required(ErrorMessage = "Geliş Fiyatı Boş Geçilemez!")]
        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "Satış Fiyatı Boş Geçilemez!")]
        public decimal UnitPrice { get; set; }
        public decimal ProfitPrice { get; set; }
    }
}
