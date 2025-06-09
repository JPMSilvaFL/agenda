using System.Security.Claims;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Log;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class PersonController : ControllerBase {
	

	private readonly IPersonService _personService;
	private readonly ILogActivityService _logActivityService;

	public PersonController(IPersonService personService, ILogActivityService logActivityService) {
		_personService = personService;
		_logActivityService = logActivityService;
	}

	[HttpPost("api/v1/fakeperson")]
	public async Task<IActionResult> FakeCreatePerson([FromBody] PersonVWTest model) {
		foreach (var person in model.People) {
			var result = await _personService.HandleCreatePerson(person);
		}

		return Ok(new ResultViewModel<PersonVWTest>(model));
	}

	[HttpPost("api/v1/persons/")]
	[Authorize(Roles = "Admin")]

	public async Task<IActionResult> CreatePerson([FromBody]PersonViewModel model) {
		if(!ModelState.IsValid)
			return BadRequest(new ResultViewModel<Customer>(ModelState.Values
				.SelectMany(x=>x.Errors)
				.Select(x=>x.ErrorMessage)
				.ToList()));
		try {
			var result = await _personService.HandleCreatePerson(model);
			var logSuccess = _logActivityService.CreateLogSuccess(ELogCode.CreatePerson, "Person "+result.Id+" created successfully.");

			var userIdClaim = User.FindFirst("UserId");
			if (userIdClaim == null)
				return Unauthorized(new ResultViewModel<Person>("UserId claim not found."));

			var userId = Guid.Parse(userIdClaim.Value);


			await _logActivityService
				.CreateLog(userId,
					ELogType.Success,
					EAction.Saved,
					logSuccess.Code,
					logSuccess.Description);
			return Ok(new ResultViewModel<Person>(result));
		}
		catch (Exception e) {
			Console.WriteLine(e);
			return BadRequest(new ResultViewModel<Person>("erro encontrado"));
		}
	}

	[HttpGet("api/v1/persons")]
	public async Task<ActionResult<List<Person>>> GetPersons() {
		var persons = await _personService.HandleListPerson();
		return Ok(new ResultViewModel<IList<Person>>(persons));
	}
}