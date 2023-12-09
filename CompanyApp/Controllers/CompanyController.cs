using CompanyApp.DTOs.CompanyDTOs;
using CompanyApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService _companyService;

		public CompanyController(ICompanyService companyService)
		{
			_companyService = companyService;
		}


		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<CompanyDto>> GetCompanyByIdAsync(int? id)
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

				CompanyDto companyDto = await _companyService.GetCompanyByIdAsync(id);

				return Ok(companyDto);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult<List<CompanyDto>>> GetAllCompaniesAsync()
		{
			try
			{
				return Ok(await _companyService.GetAllCompaniesAsync());
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

		public async Task<ActionResult> CreateCompanyAsync([FromBody] CreateCompanyDto company)
		{
			try
			{
				if (company == null || company.CompanyName == null || company.Industry == null)
				{
					return BadRequest("Invalid input");
				}

				await _companyService.CreateCompanyAsync(company);
				return StatusCode(StatusCodes.Status201Created, "Company has been added");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult> DeleteCompanyAsync(int id)
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

				await _companyService.DeleteCompanyAsync(id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpPatch("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult> UpdateCompanyAsync([FromBody] CreateCompanyDto createCompanyDto, int id)
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

				await _companyService.UpdateCompanyAsync(createCompanyDto, id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}
	}
}
