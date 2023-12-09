using CompanyApp.DataAccess.Interfaces;
using CompanyApp.Domain.Entities;
using CompanyApp.DTOs.CountryDTOs;
using CompanyApp.Mappers;
using CompanyApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Services.Implementations
{
	public class CountryService : ICountryService
	{
		private readonly IRepository<Country> _countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
			_countryRepository = countryRepository;
        }
        public async Task CreateCountryAsync(CreateCountryDto createCountryDto)
		{
			Country countryEntity = createCountryDto.MapToCountry();

			await _countryRepository.CreateAsync(countryEntity);
		}

		public async Task DeleteCountryAsync(int? id)
		{
			await _countryRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync()
		{
			List<Country> country = await _countryRepository.GetAllAsync();

			if(country == null)
			{
				throw new NotImplementedException("Country is null.");
			}

			return country.Select(country => country.MapToCountryDto()).ToList();
		}

		public async Task<CountryDto> GetCountryByIdAsync(int? id)
		{
			Country country = await _countryRepository.GetByIdAsync(id);

			if(country == null)
			{
				throw new NotImplementedException("Country is null.");
			}

			return country.MapToCountryDto();
		}

		public async Task UpdateCountryAsync(CreateCountryDto createCountryDto, int? id)
		{
			Country countryDb = await _countryRepository.GetByIdAsync(id);

			if( countryDb == null)
			{
				throw new NotImplementedException("Country is null");
			}

			countryDb.CountryName = createCountryDto.CountryName;
		}
	}
}
