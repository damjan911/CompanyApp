using CompanyApp.DTOs.ContactDTOs;
using CompanyApp.DTOs.CountryDTOs;
using CompanyApp.Services.Implementations;
using CompanyApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class CountryController : ControllerBase
     {
	  private readonly ICountryService _countryService;

      public CountryController(ICountryService countryService)
      {
	   _countryService = countryService;
      }

      [HttpGet("{id:int}")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      
      public async Task<ActionResult<CountryDto>> GetCountryByIdAsync(int? id)
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

		  CountryDto countryDto = await _countryService.GetCountryByIdAsync(id);

		  return Ok(countryDto);
           }
      
	     catch (Exception)
	     {
			return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
	     }
      }

	  [HttpGet]
	  [ProducesResponseType(StatusCodes.Status200OK)]
	  [ProducesResponseType(StatusCodes.Status500InternalServerError)]

	  public async Task<ActionResult<List<CountryDto>>> GetAllCountriesAsync()
	  {
		 try
		 {
			return Ok(await _countryService.GetAllCountriesAsync());
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

	     public async Task<ActionResult> CreateContriesAsync([FromBody] CreateCountryDto country)
	     {
		   try
		   {
			if(country == null || country.CountryName == null)
			{
				return BadRequest("Invalid input");
			}

			 await _countryService.CreateCountryAsync(country);
			 return StatusCode(StatusCodes.Status201Created, "Country has been added");
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

		public async Task<ActionResult> DeleteCountryAsync(int id)
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

			    await _countryService.DeleteCountryAsync(id);

			    return StatusCode(StatusCodes.Status204NoContent,"The Country with this Id doesn't exist");
		    }
		    catch (Exception ex)
		     {
			    Console.WriteLine(ex.ToString());
                            return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		     }
		 }

		[HttpPatch("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult> UpdateCountryAsync([FromBody] CreateCountryDto createCountryDto, int id)
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

			      await _countryService.UpdateCountryAsync(createCountryDto, id);

			      return Ok();
		      }
		      catch (Exception)
		      {
			     return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		      }

		}
	 }
   }
