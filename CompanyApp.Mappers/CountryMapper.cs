using CompanyApp.Domain.Entities;
using CompanyApp.DTOs.CountryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Mappers
{
	public static class CountryMapper
	{
		public static CountryDto MapToCountryDto (this Country country)
		{
			return new CountryDto()
			{
				CountryName = country.CountryName,
			};
		}

		public static Country MapToCountry (this CreateCountryDto createCountryDto)
		{
			return new Country()
			{
				CountryName = createCountryDto.CountryName
			};
		}
	}
}
