using Microsoft.AspNetCore.Mvc;
using Web_API_AspNet.Entity;
using Web_API_AspNet.DB;

namespace Web_API_AspNet.Controllers
{
	[ApiController]
	[Route("crud/person")]
	public class PersonController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

		private readonly ILogger<PersonController> _logger;

		public PersonController(ILogger<PersonController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> GetWeatherForecastGet()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}

		[HttpPost]
		public IActionResult Create(Person person)
		{
			if (person == null)
				return BadRequest();
			return Ok();
		}

	}
}