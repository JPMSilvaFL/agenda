using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class AccessController : ControllerBase{

	private readonly IAccessService _accessService;

	public AccessController(IAccessService accessService) {
		_accessService = accessService;
	}

	[HttpPost("api/v1/access/")]
	public async Task<IActionResult> CreateAccess([FromBody]AccessViewModel model) {
		if(!ModelState.IsValid)
			return BadRequest(new ResultViewModel<Access>(ModelState.Values
				.SelectMany(x=>x.Errors)
				.Select(x=>x.ErrorMessage)
				.ToList()));
		var result = await _accessService.HandleCreateAccess(model);
		return Ok(new ResultViewModel<Access>(result));
	}
	
}