using Microsoft.AspNetCore.Mvc;
using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.Controllers
{
    public class SaleProductController : Controller
    {
        
        public IActionResult GetFilteredProduct(ProductDTO productDTO)
        { 
            if (productDTO.Barcode != null)
            {
                #region Views
                float gun = 30;
                float hafta = 30 / 7;
                float ay = 1;
                float gunlukIstatıstık = 12 / gun;
                float haftalıksIstatıstık = 12 / hafta;
                float aylıkIstatıstık = 12 / ay;
                ViewBag.Gunluk = gunlukIstatıstık;
                ViewBag.Haftalık = haftalıksIstatıstık;
                ViewBag.Aylık = aylıkIstatıstık;
                #endregion
            }
            else
            {
                ViewBag.Status = "Ürüne ait satış bulunmamaktadır.";
            }
            return View(productDTO);
        }

    }
}
