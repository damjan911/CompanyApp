using CompanyApp.DTOs.CompanyDTOs;
using CompanyApp.DTOs.ContactDTOs;
using CompanyApp.Services.Implementations;
using CompanyApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;

		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult<ContactDto>> GetContactByIdAsync(int? id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest("Id can not be zero.");
				}

				if (id <= 0)
				{
					return BadRequest("Id can not be a negative number");
				}

				ContactDto contactDto = await _contactService.GetContactByIdAsync(id);

				return Ok(contactDto);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult<List<ContactDto>>> GetAllContacsAsync()
		{
			try
			{
				return Ok(await _contactService.GetAllContactsAsync());
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult> CreateContactAsync([FromBody] CreateContactDto contact)
		{
			try
			{
				if (contact == null || contact.ContactName == null || contact.JobTitle == null || contact.CompanyId == 0 || contact.CountryId == 0)
				{
					return BadRequest("Invalid input");
				}

				await _contactService.CreateContactAsync(contact);
				return StatusCode(StatusCodes.Status201Created, "Contact has been added");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult> DeleteContactAsync(int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest("Id can not be zero");
				}

				if (id <= 0)
				{
					return BadRequest("Id can not be a negative number");
				}

				await _contactService.DeleteContactAsync(id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpPatch("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult> UpdateContactAsync([FromBody] CreateContactDto createContactDto, int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest("Id can not be zero");
				}

				if (id <= 0)
				{
					return BadRequest("Id can not be a negative number");
				}

				await _contactService.UpdateContactAsync(createContactDto, id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}

		}
	}
}
