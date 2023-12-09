using CompanyApp.DataAccess;
using CompanyApp.DataAccess.Implementations;
using CompanyApp.DataAccess.Interfaces;
using CompanyApp.Domain.Entities;
using CompanyApp.Services.Implementations;
using CompanyApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Helpers
{
    public static class DependencyInjectionHelper
    {
	public static void InjectDbContext(this IServiceCollection services)
	{
	    services.AddDbContext<CompanyAppDbContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLServer;Database=CompanyDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
	}

	public static void InjectRepositories(this IServiceCollection services)
	{
		services.AddTransient<IRepository<Company>,CompanyRepository>();
		services.AddTransient<IRepository<Contact>,ContactRepository>();
		services.AddTransient<IRepository<Country>,CountryRepository>();
	}

	public static void InjectServices(this IServiceCollection services)
	{
		services.AddTransient<ICompanyService, CompanyService>();
		services.AddTransient<IContactService, ContactService>();
		services.AddTransient<ICountryService, CountryService>();
	}
    }
}
