using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class LoginController : ControllerBase{

	private readonly ITokenService _tokenService;
	private readonly IUserService _userService;


	public LoginController(ITokenService tokenService, IUserService userService) {
		_tokenService = tokenService;
		_userService = userService;
	}

	[HttpPost("api/v1/login/")]
	public async Task<IActionResult> GeraTokenLogin([FromBody]LoginViewModel model) {
		var verification = _userService.HandleAuthenticateUser(model);
		if (verification) {
			var user = await _userService.HandleGetUser(model.Username);
			var token = await _tokenService.GenerateToken(user);
			return Ok(token);
		}
		return BadRequest(new ResultViewModel<User>("Erro ao gerar token"));
	}
}