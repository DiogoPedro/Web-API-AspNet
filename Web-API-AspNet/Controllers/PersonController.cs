using Microsoft.AspNetCore.Mvc;
using Web_API_AspNet.Entity;
using Web_API_AspNet.DB;
using Web_API_AspNet.Services;

namespace Web_API_AspNet.Controllers
{
	[ApiController]
	[Route("person/data")]
	public class PersonController : ControllerBase
	{
		private readonly PersonService _personService;
		public PersonController(PersonService personService)
		{
			_personService = personService;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Person person)
		{
			try
			{
				if (person == null)
				{
					return BadRequest("Object null");
				}

				var personDB = await _personService.CreateAsync(person);

				return Ok(personDB);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Ocorreu um erro interno no servidor: " + ex.Message);
			}
		}


	}
}