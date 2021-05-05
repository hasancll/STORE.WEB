using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.ApiService.Interfaces
{
    public interface ISaleProductApiService
    {
        Task<SoldProductDTO> GetProductFilter(SaleFilter saleFilter);
    }
}
