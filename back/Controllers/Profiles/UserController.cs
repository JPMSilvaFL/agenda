﻿using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class UserController : ControllerBase {
	private readonly IUserService _userService;

	public UserController(IUserService userService) {
		_userService = userService;
	}

	[HttpGet("api/v1/users/")]
	public async Task<ActionResult<List<User>>> GetUsers(
		[FromBody] SearchUserViewModel model) {
		var users = await _userService.HandleListUser();
		return Ok(new ResultViewModel<IList<User>>(users));
	}

	[HttpPost("api/v1/users/")]
	public async Task<IActionResult>
		CreateUser([FromBody] UserViewModel model) {
		if (!ModelState.IsValid)
			return Conflict(new ResultViewModel<Customer>(ModelState.Values
				.SelectMany(x => x.Errors)
				.Select(x => x.ErrorMessage)
				.ToList()));

		await _userService.HandleCreateUser(model);
		return Ok("User created Successfully.");
	}

	[HttpPost("api/v1/user/changepassword")]
	public async Task<IActionResult> ChangePasswordByUsername(
		[FromBody] ChangePasswordByUsernameViewModel model) {
		await _userService.HandleChangePassword(model);
		return Ok("Password changed successfully.");
	}
}