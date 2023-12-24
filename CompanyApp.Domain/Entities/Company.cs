using CompanyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Entities
{
     public class Company : BaseEntity
     {
	  [Required]
	  [MaxLength(255)]
	  public string CompanyName { get; set; }

      public List<Country> Countries { get; set; }

      public List<Contact> Contacts { get; set; }

      }
}
