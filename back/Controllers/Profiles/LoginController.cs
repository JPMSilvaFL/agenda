using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class LoginController : ControllerBase {
	private readonly ITokenService _tokenService;

	public LoginController(ITokenService tokenService) {
		_tokenService = tokenService;
	}

	[HttpPost("api/v1/login/")]
	public async Task<IActionResult> GeraTokenLogin(
		[FromBody] LoginViewModel model) {
		try {
			return Ok(await _tokenService.GenerateToken(model));
		}
		catch (InvalidUserException e) {
			return BadRequest(e.Message);
		}
	}

	[HttpPost("api/v1/login/validatetoken")]
	public IActionResult ValidateToken(
		[FromBody] string token) {
		var confirm = _tokenService.ValidateToken(token);
		return Ok(confirm);
	}
}