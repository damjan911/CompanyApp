using CompanyApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.DataAccess
{
	public class CompanyAppDbContext : DbContext
	{
        public CompanyAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Company> Company { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Country> Country { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Company>()
				.HasMany(x => x.Contacts)
				.WithOne(x => x.Company)
				.HasForeignKey(x => x.CompanyId);

			modelBuilder.Entity<Country>()
				.HasMany(x => x.Contact)
				.WithOne(x => x.Country)
				.HasForeignKey(x => x.CountryId);


			modelBuilder.Entity<Contact>()
				.Property(x => x.ContactName)
				.IsRequired();

			modelBuilder.Entity<Contact>()
                .Property(x => x.JobTitle) 
				.IsRequired();



			

		}

	}

}
