using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class EmployeeController : ControllerBase {
	private readonly IEmployeeService _employeeService;

	public EmployeeController(IEmployeeService employeeService) {
		_employeeService = employeeService;
	}

	[HttpPost("api/v1/employee")]
	public async Task<IActionResult> CreateEmployee(
		[FromBody] EmployeeViewModel model) {
		await _employeeService.HandleCreateEmployee(model);
		return Ok("Employee created successfully.");
	}
}