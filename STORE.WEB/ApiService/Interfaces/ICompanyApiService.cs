using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.ApiService.Interfaces
{
    public interface ICompanyApiService
    {
        Task AddCompany(CompanyDTO companyDTO);
        Task<List<CompanyDTO>> GetAllCompanies();
        Task UpdateCompany(CompanyDTO companyDTO);
        Task<CompanyDTO> GetByIdCompany(int id);
    }
}
