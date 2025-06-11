using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Schedule;

public class PurposeController : ControllerBase {
	private readonly IPurposeService _purposeService;

	public PurposeController(IPurposeService purposeService) {
		_purposeService = purposeService;
	}

	[HttpPost("api/v1/purpose")]
	public async Task<IActionResult> CreatePurpose(
		[FromBody] PurposeViewModel model) {
		var result = await _purposeService.HandleCreatePurpose(model);
		return Ok(new ResultViewModel<Purpose>(result));
	}

	[HttpGet("api/v1/purpose")]
	public async Task<IActionResult> GetPurposes(
		[FromBody] SearchPurposeViewModel model) {
		var result = await _purposeService.HandleGetPurpose(model);

		var viewModel = result.Select(p => new QueryPurposeViewModelAux {
			Name = p.Name,
			Role = p.FromRole!.Name,
			Description = p.Description,
			CreatedAt = p.CreatedAt,
			UpdatedAt = p.UpdatedAt
		}).ToList();
		return Ok(new QueryPurposeViewModel(viewModel));
	}
}