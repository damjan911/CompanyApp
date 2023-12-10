using CompanyApp.DTOs.CompanyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Services.Interfaces
{
     public interface ICompanyService
     {
	  Task<CompanyDto> GetCompanyByIdAsync(int? id);

	  Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync();

	  Task CreateCompanyAsync(CreateCompanyDto createCompanyDto);

	  Task DeleteCompanyAsync(int? id);

	  Task UpdateCompanyAsync(CreateCompanyDto createCompanyDto, int? id);
     }
}
