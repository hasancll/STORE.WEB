﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class ReceiptDTO:BaseDTO
    {
        public int ReceiptPaymentId { get; set; }
        public virtual ReceiptPaymentDTO ReceiptPaymentDTO { get; set; }
        public IEnumerable<SoldProductDTO> SoldProductDTO { get; set; }
    }
}
