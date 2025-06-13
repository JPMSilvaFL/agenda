using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.ViewModels.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

[ApiController]
public class SecretaryController : ControllerBase {
	private readonly ISecretaryService _secretaryService;

	public SecretaryController(ISecretaryService secretaryService) {
		_secretaryService = secretaryService;
	}

	[HttpPost("api/v1/secretary")]
	public async Task<IActionResult> CreateSecretary(
		[FromBody] SecretaryViewModel model) {
		await _secretaryService.HandleCreateSecretary(model);
		return Ok("Secretary created successfully.");
	}
}