using CompanyApp.DataAccess.Interfaces;
using CompanyApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.DataAccess.Implementations
{
     public class ContactRepository : IRepository<Contact>
     {
	 private readonly CompanyAppDbContext _context;

         public ContactRepository(CompanyAppDbContext context)
         {
	     _context = context;
         }

         public async Task CreateAsync(Contact entity)
	 {
		await _context.Contact.AddAsync(entity);
		await _context.SaveChangesAsync();
	 }

	 public async Task DeleteAsync(int? id)
	 {
		Contact contactDb = await GetByIdAsync(id);

			_context.Remove(contactDb);

			await _context.SaveChangesAsync();
		}

	  public List<Contact> FilterContacts (int countryId, int companyId)
	  {
	      if(companyId == 0 && countryId == 0)
	      {
		   return _context.Contact.ToList();
	      }

	      if(companyId == 0)
	      {
			List<Contact> contactDb = _context.Contact.Where(x=>x.CountryId == countryId).ToList();
			return contactDb;
	      }

	      if (countryId == 0)
	      {
		    List<Contact> companyDb = _context.Contact.Where(x => x.CompanyId == companyId).ToList();
		    return companyDb;
	      }

		List<Contact> contacts = _context.Contact.Where(x=>x.CompanyId == companyId && x.CountryId == countryId).ToList();

		return contacts;
  
		}

		public async Task<List<Contact>> GetAllAsync()
		{
			return await _context.Contact.ToListAsync();
		}

		public async Task<Contact> GetByIdAsync(int? id)
		{
			return await _context.Contact.FirstOrDefaultAsync(x=>x.Id == id);
		}

		public async Task UpdateAsync(Contact entity)
		{
			_context.Contact.Update(entity);
			await UpdateAsync(entity);
		}
	}
}
