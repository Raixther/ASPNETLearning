using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers.DataTransfer;

using WebApp.Services.PersonService;

namespace WebApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	
	public class PersonsController : ControllerBase
	{
		private readonly IPersonsService _service;

		private readonly IMapper _mapper;
	
		public PersonsController(IPersonsService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet("/persons/{id}")]
		public IActionResult GetPersonById([FromRoute]int id)
		{
			var person = _service.GetPersonById(id);
			var result = _mapper.Map<PersonDTO>(person);
			return Ok(result);
		}
		[HttpGet("/persons/searchTerm/{name}")]
		[Authorize(Roles = "Admin")]
		public IActionResult GetPersonByName([FromRoute]string name)
		{
			var person = _service.GetPersonByName(name);
			var result = _mapper.Map<PersonDTO>(person);
			return Ok(result);
		}

		[HttpPost("/persons/{name}")]
		public IActionResult AddPerson([FromRoute] string name)
		{
			var result = _service.AddPerson(name);
			return Ok(result);
		}
		[HttpPut("/persons/{id}/{name}/")]
		public IActionResult UpdatePerson([FromRoute] int id, string name)
		{
			var result = _service.UpdatePerson(id, name);
			return Ok(result);
		}
		[HttpDelete("/persons/{id}")]
		public IActionResult DeletePerson(int id)
		{
			var result = _service.DeletePerson(id);
			return Ok(result);
		}
	}
}
