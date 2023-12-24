using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Entities
{
    public class Country : BaseEntity
    {
	 [MaxLength(255)]
	 public string ?CountryName { get; set; }

	 [Required]
	 [ForeignKey("Company")]
	 public int CompanyId { get; set; }

	 public Company? Company { get; set; }

	 public List<Contact> ?Contact { get; set; }
    }
}
