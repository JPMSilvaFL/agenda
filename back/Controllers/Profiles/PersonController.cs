using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AgendaApi.Controllers.Profiles;

public class PersonController : ControllerBase {
	private readonly IPersonService _personService;
	public PersonController(IPersonService personService) {
		_personService = personService;
	}

	[HttpPost("api/v1/persons/")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreatePerson([FromBody] PersonViewModel model) {
		if (!ModelState.IsValid)
			return BadRequest(new ResultViewModel<Customer>(ModelState.Values
				.SelectMany(x => x.Errors)
				.Select(x => x.ErrorMessage)
				.ToList()));
		try {
			var result = await _personService.HandleCreatePerson(model);
			return Ok("Pessoa criada com sucesso!");
		}
		catch (DuplicatePersonException e) {
			return BadRequest(new ResultViewModel<Person>(e.Message));
		}
		catch (SqlException e) {
			return NotFound(new ResultViewModel<Person>(e.Message));
		}
		catch (Exception e) {
			Console.WriteLine(e);
			return BadRequest(new ResultViewModel<Person>("erro encontrado"));
		}
	}
}