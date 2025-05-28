using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class UserController : ControllerBase {

	private readonly IUserService _userService;
	private readonly IPasswordHashService _passwordHashService;
	public UserController(IUserService userService, IPasswordHashService passwordHashService) {
		_userService = userService;
		_passwordHashService = passwordHashService;
	}

	[HttpGet("api/v1/users/")]
	public async Task<ActionResult<List<User>>> GetUsers() {
		var users = await _userService.HandleListUser();
		return Ok(users);
	}
	[HttpPost("api/v1/users/")]
	public async Task<IActionResult> CreateUser([FromBody]UserViewModel model) {
		if(!ModelState.IsValid)
			return BadRequest(new ResultViewModel<User>(ModelState.Values
				.SelectMany(x=>x.Errors)
				.Select(x=>x.ErrorMessage)
				.ToList()));

		var result = await _userService.HandleCreateUser(model);
		return Ok(new ResultViewModel<User>(result));
	}

	[HttpPost("api/v1/users/forgot")]
	public async Task<IActionResult> ForgotPassword([FromBody]NewPasswordViewModel model) {
		if(!ModelState.IsValid)
			return BadRequest(new ResultViewModel<User>(ModelState.Values
				.SelectMany(x=>x.Errors)
				.Select(x=>x.ErrorMessage)
				.ToList()));

		if (await _userService.HandleValidUsername(model) == false) return BadRequest(new ResultViewModel<User>("Username invalido"));

		var newPasswordHashed = _passwordHashService.HashPassword(model.Password);
		var passwordUpdated = await _userService.HandleUpdatePassword(model.Username, newPasswordHashed);
		if(!passwordUpdated) return BadRequest(new ResultViewModel<User>("Error in updating password in database"));
		return Ok("Password updated successfully.");
	}
}