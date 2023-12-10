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
	public class CompanyRepository : IRepository<Company>
	{
		private readonly CompanyAppDbContext _context;

		public CompanyRepository(CompanyAppDbContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(Company entity)
		{
			await _context.Company.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int? id)
		{
			Company companyDb = await GetByIdAsync(id);

			_context.Remove(companyDb);

			await _context.SaveChangesAsync();

		}

		public async Task<List<Company>> GetAllAsync()
		{
			return await _context.Company.ToListAsync();
		}

		public async Task<Company> GetByIdAsync(int? id)
		{
			return await _context.Company.FirstOrDefaultAsync(x => x.Id == id);
		}


		public async Task UpdateAsync(Company entity)
		{
			_context.Company.Update(entity);
			await _context.SaveChangesAsync();
		}
	}

}

