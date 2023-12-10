using CompanyApp.Domain.Entities;
using CompanyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.DTOs.CompanyDTOs
{
    public class CreateCompanyDto
    {
	public string CompanyName { get; set; }

	public Industry Industry { get; set; }

    }
}
