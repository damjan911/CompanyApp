using CompanyApp.Domain.Enums;
using CompanyApp.DTOs.CompanyDTOs;
using CompanyApp.DTOs.CountryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.DTOs.ContactDTOs
{
	public class CreateContactDto
	{
		public string ContactName { get; set; }

		public JobTitle JobTitle { get; set; }

		public int CompanyId { get; set; }

		public int CountryId { get; set; }
	}
}
