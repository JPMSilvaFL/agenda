using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.ViewModels.Schedule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Schedule;

[ApiController]
public class ScheduledController : ControllerBase {
	private readonly IScheduledService _scheduledService;

	public ScheduledController(IScheduledService scheduledService) {
		_scheduledService = scheduledService;
	}

	[HttpPost("api/v1/scheduled")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> ToSchedule(
		[FromBody] ScheduledViewModel model) {
		await _scheduledService.HandleScheduled(model);
		return Ok("Scheduled!");
	}
}