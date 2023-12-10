using CompanyApp.Domain.Entities;
using CompanyApp.DTOs.CompanyDTOs;
using CompanyApp.DTOs.ContactDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Mappers
{
    public static class ContactMapper
    {
	 public static ContactDto MapToContactDto(this Contact contact)
	 {
		return new ContactDto()
		{
			ContactName = contact.ContactName,
			JobTitle = contact.JobTitle,
			Company = contact.Company == null? new CompanyDto() : contact.Company.MapToCompanyDto()
		};
	 }

	  public static Contact MapToContact(this CreateContactDto createContactDto)
	  {
		 return new Contact()
		 {
			  ContactName = createContactDto.ContactName,
			  JobTitle = createContactDto.JobTitle,
			  CompanyId = createContactDto.CompanyId
		 };
	  }
    }
}
