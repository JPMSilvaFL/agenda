using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Schedule;

[ApiController]
public class ScheduledController : ControllerBase {
	[HttpPost("api/v1/scheduled")]
	public async Task<IActionResult> ToSchedule() { }
}