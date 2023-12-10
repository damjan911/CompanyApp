using CompanyApp.Domain.Entities;
using CompanyApp.DTOs.CompanyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Mappers
{
     public static class CompanyMapper
     {
	  public static CompanyDto MapToCompanyDto (this Company company)
	  {
		return new CompanyDto()
		{
			CompanyName = company.CompanyName,
			Industry = company.Industry
		};
	  }

	  public static Company MapToCompany (this CreateCompanyDto createCompanyDto)
	  {
		return new Company()
		{
			CompanyName = createCompanyDto.CompanyName,
			Industry = createCompanyDto.Industry,
		};
	  }
     }
}
