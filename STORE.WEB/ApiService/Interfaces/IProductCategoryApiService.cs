using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.ApiService.Interfaces
{
    public interface IProductCategoryApiService
    {
        Task<List<ProductCategoryDTO>> GetAllAsync();
        Task<string> AddProductCategoryAsync(ProductCategoryDTO productCategoryDTO);
        Task<ProductCategoryDTO> GetByIdProductCategoryAsync(int id);
        Task<string> UpdateCategoryAsync(ProductCategoryDTO productCategoryDTO);
        Task DeleteProductCategoryAsync(int id);

    }
}
