using CompanyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.DataAccess.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(int? id);

		Task<List<T>> GetAllAsync();

		Task CreateAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(int? id);
	}
}
