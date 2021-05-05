using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class ProductStockDTO:BaseDTO
    {
        
        public int StockAmount { get; set; }
    }
}
