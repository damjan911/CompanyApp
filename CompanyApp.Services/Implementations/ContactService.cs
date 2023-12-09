using CompanyApp.DataAccess.Interfaces;
using CompanyApp.Domain.Entities;
using CompanyApp.DTOs.ContactDTOs;
using CompanyApp.Mappers;
using CompanyApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyApp.Services.Implementations
{
	public class ContactService : IContactService
	{
		private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
			_contactRepository = contactRepository;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
		{
			Contact contactEntity = createContactDto.MapToContact();

			await _contactRepository.CreateAsync(contactEntity);
		}

		public async Task DeleteContactAsync(int? id)
		{
			await _contactRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ContactDto>> GetAllContactsAsync()
		{
			List<Contact> contact = await _contactRepository.GetAllAsync();

			if (contact == null)
			{
				throw new NotImplementedException("Contact is null.");
			}

			return contact.Select(contact => contact.MapToContactDto()).ToList();
		}

		public async Task<ContactDto> GetContactByIdAsync(int? id)
		{
			Contact contact = await _contactRepository.GetByIdAsync(id);

			if (contact == null)
			{
				throw new NotImplementedException("Contact is null.");
			}
             return contact.MapToContactDto();
		}

		public async Task UpdateContactAsync(CreateContactDto createContactDto, int? id)
		{
			Contact contactDb = await _contactRepository.GetByIdAsync(id);

			if(contactDb == null)
			{
				throw new NotImplementedException("Contact is null");
			}

			contactDb.ContactName = createContactDto.ContactName;
			contactDb.JobTitle = createContactDto.JobTitle;
			contactDb.CompanyId = createContactDto.CompanyId;
			contactDb.CountryId = createContactDto.CountryId;
		}
	}
}
