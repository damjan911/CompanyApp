using CompanyApp.DataAccess.Interfaces;
using CompanyApp.Domain.Entities;
using CompanyApp.DTOs.CompanyDTOs;
using CompanyApp.Mappers;
using CompanyApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompanyApp.Services.Implementations
{
	public class CompanyService : ICompanyService
	{
		private readonly IRepository<Company> _companyRepository;

		public CompanyService(IRepository<Company> companyRepository)
		{
			_companyRepository = companyRepository;
		}

		public async Task CreateCompanyAsync(CreateCompanyDto createCompanyDto)
		{
			Company companyEntity = createCompanyDto.MapToCompany();

			await _companyRepository.CreateAsync(companyEntity);
		}

		public async Task DeleteCompanyAsync(int? id)
		{
			await _companyRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync()
		{
			List<Company> company = await _companyRepository.GetAllAsync();

			if (company == null)
			{
				throw new NotImplementedException("Company is null.");
			}

			return company.Select(company => company.MapToCompanyDto()).ToList();
		}

		public async Task<CompanyDto> GetCompanyByIdAsync(int? id)
		{
			
			Company company = await _companyRepository.GetByIdAsync(id);

			if (company == null)
			{
				throw new NotImplementedException("Company is null.");
			}

			return company.MapToCompanyDto();
			
		}

		public async Task UpdateCompanyAsync(CreateCompanyDto createCompanyDto, int? id)
		{
			Company companyDb = await _companyRepository.GetByIdAsync(id);

			if (companyDb == null)
			{
				throw new NotImplementedException("Company is null");
			}

			companyDb.CompanyName = createCompanyDto.CompanyName;
			companyDb.Industry = createCompanyDto.Industry;
		}
	}
}
