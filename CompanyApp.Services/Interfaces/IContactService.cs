using CompanyApp.DTOs.CompanyDTOs;
using CompanyApp.DTOs.ContactDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Services.Interfaces
{
     public interface IContactService
     {
	   Task<ContactDto> GetContactByIdAsync(int? id);

	   Task<IEnumerable<ContactDto>> GetAllContactsAsync();

	   Task CreateContactAsync(CreateContactDto createContactDto);

	   Task DeleteContactAsync(int? id);

	   Task UpdateContactAsync(CreateContactDto createContactDto, int? id);
     }
}
