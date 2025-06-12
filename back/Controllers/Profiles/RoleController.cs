using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.ViewModels.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class RoleController : ControllerBase {
	private readonly IRoleService _roleService;

	public RoleController(IRoleService roleService) {
		_roleService = roleService;
	}

	[HttpPost("api/v1/role")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult>
		CreateRole([FromBody] RoleViewModel model) {
		await _roleService.HandleCreateRole(model);
		return Ok("Role created successfully.");
	}
}