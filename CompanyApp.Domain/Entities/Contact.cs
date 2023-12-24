using CompanyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Entities
{
    public class Contact : BaseEntity
    {
	 [Required]
	 [MaxLength(255)]
	 public string ContactName { get; set; }

	 [Required]
	 [MaxLength(255)]
	 public JobTitle JobTitle { get; set; }

	 [Required]
	 [ForeignKey("Company")]
	 public int CompanyId { get; set; }

	 public Company? Company { get; set; }

	 public Country ?Country { get; set; }

	 [Required]
	 [ForeignKey("Country")]
	 public int CountryId { get; set; }
   }
}
