using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class LoginController : ControllerBase {
	private readonly ITokenService _tokenService;

	public LoginController(ITokenService tokenService) {
		_tokenService = tokenService;
	}

	[HttpPost("api/v1/login/")]
	public async Task<IActionResult> GeraTokenLogin([FromBody] LoginViewModel model) {
		try {
			return Ok(await _tokenService.GenerateToken(model));
		}
		catch (InvalidUserException e) {
			return BadRequest(e.Message);
		}
	}
}