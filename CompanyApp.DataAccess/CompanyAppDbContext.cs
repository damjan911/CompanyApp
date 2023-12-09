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
		.Property(x=>x.JobTitle) 
		.IsRequired();

                modelBuilder.Entity<Contact>()
                 .Property(x => x.JobTitle) 
		 .IsRequired();

		modelBuilder.Entity<Company>().HasData(new Company
		{
		    Id = 1,
		    CompanyName = "ABC Corporation",
		    Industry = Domain.Enums.Industry.Technology
		});

		modelBuilder.Entity<Company>().HasData(new Company
		{
		     Id = 2,
		     CompanyName = "XYZ Ltd",
		     Industry = Domain.Enums.Industry.Finance
		});

		modelBuilder.Entity<Company>().HasData(new Company
		{
		     Id = 3,
		     CompanyName = "TechFab Solutions",
		     Industry = Domain.Enums.Industry.Manufacturing
		});

		modelBuilder.Entity<Company>().HasData(new Company
		{
		     Id = 4,
		     CompanyName = "RoadMasters Automotive",
		     Industry = Domain.Enums.Industry.Transportation
		});

		modelBuilder.Entity<Contact>().HasData(new Contact
		{
		     Id = 1,
		     ContactName = "John Doe",
		     JobTitle = Domain.Enums.JobTitle.Software_Engineer,
		     CompanyId = 1,
		     CountryId = 2

		});

		modelBuilder.Entity<Contact>().HasData(new Contact
		{
		      Id = 2,
		      ContactName = "Jane Smith",
		      JobTitle = Domain.Enums.JobTitle.Logistics_Coordinator,
		      CompanyId = 2,
		      CountryId = 1

		});

		modelBuilder.Entity<Contact>().HasData(new Contact
		{
		      Id = 3,
		      ContactName = "Bob Johnson",
		      JobTitle = Domain.Enums.JobTitle.Financial_Analyst,
		      CompanyId = 3,
		      CountryId = 4

		});

		modelBuilder.Entity<Contact>().HasData(new Contact
		{
		      Id = 4,
		      ContactName = "Martin Peterson",
		      JobTitle = Domain.Enums.JobTitle.Production_Supervisor,
		      CompanyId = 4,
		      CountryId = 3

		});

		modelBuilder.Entity<Country>().HasData(new Country
		{
		      Id=1,
		      CountryName = "Germany"
		});

		modelBuilder.Entity<Country>().HasData(new Country
		{
		       Id = 2,
		       CountryName = "France"
		});

		modelBuilder.Entity<Country>().HasData(new Country
		{
		       Id = 3,
		       CountryName = "Poland"
		});


	        modelBuilder.Entity<Country>().HasData(new Country
		{
		        Id = 4,
			CountryName = "Swedan"
		});
  
		}

	}

}
