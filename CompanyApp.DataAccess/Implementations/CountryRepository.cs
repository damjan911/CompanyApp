using CompanyApp.DataAccess.Interfaces;
using CompanyApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.DataAccess.Implementations
{
     public class CountryRepository : IRepository<Country>
     {
	 private readonly CompanyAppDbContext _dbContext;

     public CountryRepository(CompanyAppDbContext dbContext)
     {
	  _dbContext = dbContext;
     }

     public async Task CreateAsync (Country entity)
     {
	  await _dbContext.Country.AddAsync(entity);
	  await _dbContext.SaveChangesAsync();
     }


     public async Task DeleteAsync(int? id)
     {
	   Country countryDb = await GetByIdAsync(id);

			_dbContext.Remove(countryDb);

			await _dbContext.SaveChangesAsync();

		}

     public async Task<List<Country>> GetAllAsync()
     {
	  return await _dbContext.Country.ToListAsync();
     }

     public async Task<Country> GetByIdAsync(int? id)
     {
          return await _dbContext.Country.FirstOrDefaultAsync(x => x.Id == id);
     }

     public async Task UpdateAsync(Country entity)
      {
	  _dbContext.Country.Update(entity);
	  await _dbContext.SaveChangesAsync();
      }
      
     }
}
