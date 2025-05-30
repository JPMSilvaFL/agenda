using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class PersonController : ControllerBase {
	

	private readonly IPersonService _personService;

	public PersonController(IPersonService personService) {
		_personService = personService;
	}

	[HttpPost("api/v1/fakeperson")]
	public async Task<IActionResult> FakeCreatePerson([FromBody] PersonVWTest model) {
		foreach (var person in model.People) {
			var result = await _personService.HandleCreatePerson(person);
		}

		return Ok(new ResultViewModel<PersonVWTest>(model));
	}

	[HttpPost("api/v1/persons/")]
	public async Task<IActionResult> CreatePerson([FromBody]PersonViewModel model) {
		if(!ModelState.IsValid)
			return BadRequest(new ResultViewModel<Customer>(ModelState.Values
				.SelectMany(x=>x.Errors)
				.Select(x=>x.ErrorMessage)
				.ToList()));
		var result = await _personService.HandleCreatePerson(model);
		return Ok(new ResultViewModel<Person>(result));
	}

	[HttpGet("api/v1/persons")]
	public async Task<ActionResult<List<Person>>> GetPersons() {
		var persons = await _personService.HandleListPerson();
		return Ok(new ResultViewModel<IList<Person>>(persons));
	}
}