using CompanyApp.DTOs.ContactDTOs;
using CompanyApp.DTOs.CountryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Services.Interfaces
{
     public interface ICountryService
     {
	  Task<CountryDto> GetCountryByIdAsync(int? id);

	  Task<IEnumerable<CountryDto>> GetAllCountriesAsync();

	  Task CreateCountryAsync(CreateCountryDto createCountryDto);

	  Task DeleteCountryAsync(int? id);

	  Task UpdateCountryAsync(CreateCountryDto createCountryDto, int? id);
     }
}
