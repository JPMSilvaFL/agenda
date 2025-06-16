using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Schedule;

[ApiController]
public class AvailableController : ControllerBase {
	private readonly IAvailableService _availableService;

	public AvailableController(IAvailableService service) {
		_availableService = service;
	}

	[HttpPost("api/v1/available")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateAvailable(
		[FromBody] AvailableViewModel model) {
		var result = await _availableService.HandleCreateAvailable(model);
		return Ok(new ResultViewModel<Available>(result));
	}

	[HttpGet("api/v1/available")]
	public async Task<IActionResult> SearchAvailables(
		SearchAvailableViewModel model) {
		var result = await _availableService.HandleSearchAvailable(model);
		return Ok(new ResultViewModel<List<QueryAvailableViewModel>>(result));
	}
}