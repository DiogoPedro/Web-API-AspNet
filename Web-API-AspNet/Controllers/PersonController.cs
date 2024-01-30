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

		[HttpGet]
		public async Task<IActionResult> ReadAll()
		{
            try
			{
                var persons = await _personService.ReadAllAsync();

                return Ok(persons);
            }
            catch (Exception ex)
			{
                return StatusCode(500, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> ReadId(string id)
		{
            try
			{
                var person = await _personService.ReadAsync(id);

                if (person == null)
				{
                    return NotFound("Person not found");
                }

                return Ok(person);
            }
            catch (Exception ex)
			{
                return StatusCode(500, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
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

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Update(string id, [FromBody] Person person)
		{
            try
			{
				if (person == null)
				{
                    return BadRequest("Object null");
                }

                if (String.IsNullOrEmpty(id))
				{
					if (person?.Id != null)
					{
						id = person.Id;
					}
					else
					{
						return BadRequest("Object null and Id");
					}

                }

                var personDB = await _personService.ReadAsync(id);

                if (personDB == null)
				{
                    return NotFound("Person not found");
                }

                personDB.Name = person.Name;
                personDB.Age = person.Age;
                personDB.Address = person.Address;
                personDB.City = person.City;
                personDB.Country = person.Country;

                await _personService.UpdateAsync(id, personDB);

                return Ok(personDB);
            }
            catch (Exception ex)
			{
                return StatusCode(500, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(string id, [FromBody] Person person)
		{
            try
			{
                if (String.IsNullOrEmpty(id))
                {
                    if (person?.Id != null)
                    {
                        id = person.Id;
                    }
                    else
                    {
                        return BadRequest("Object Id null or Id");
                    }
                }

                var personDB = await _personService.ReadAsync(id);

				if (personDB == null)
				{
					return NotFound("Person not found");
				}

				await _personService.DeleteAsync(id);

				return Ok("Person deleted");
            }
            catch (Exception ex)
			{
                return StatusCode(500, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
		}

	}
}