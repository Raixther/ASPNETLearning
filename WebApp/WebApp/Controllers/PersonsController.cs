using Microsoft.AspNetCore.Mvc;

using WebApp.Controllers.Models;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonsController : ControllerBase
	{

		private readonly ILogger<PersonsController> _logger;


		private readonly IService<PersonDTO> _service;

		public PersonsController(ILogger<PersonsController> logger, IEntitiesRepository<PersonEntity> repository)
		{
			_logger = logger;
			
		}

		[HttpGet("persons/{id}")]
		public  IActionResult GetPerson()
		{
			throw new NotImplementedException();
		}

		[HttpGet("/persons/search?searchTerm={term} ")]
		public IActionResult GetPersonByName()
		{
			throw new NotImplementedException();
		}
		[HttpPost("/persons")]
		public  IActionResult AddPerson()
		{
			throw new NotImplementedException();
		}
		[HttpPut("/persons")]
		public  IActionResult UpdatePerson()
		{
			throw new NotImplementedException();
		}
		[HttpDelete("persons/{id}")]

		public IActionResult  DeletePerson()
		{
			throw new NotImplementedException();
		}

	}
}