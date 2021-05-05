using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.ApiService.Interfaces
{
    public interface IProductApiService
    {
        Task<ProductDTO> AddProductAsync(ProductDTO productDTO);
        Task<ProductDTO> GetByBarcodeProductAsync(string barcode);
        Task UpdateProductAsync(ProductDTO productDTO);
        Task<ProductDTO> GetByIdProduct(int id);
        void DeleteByProductAsync(int id);
    }
}
