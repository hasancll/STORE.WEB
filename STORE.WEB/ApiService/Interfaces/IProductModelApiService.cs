using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.ApiService.Interfaces
{
    public interface IProductModelApiService
    {
        Task<List<ProductModelDTO>> GetAllAsync();
        Task AddProductModelAsync(ProductModelDTO productModelDTO);
        Task<ProductModelDTO> GetByIdProductModelAsync(int id);
        Task UpdateModelAsync(ProductModelDTO productModelDTO);
        Task DeleteProductModelAsync(int id);
    }
}
