﻿using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class CustomerController : ControllerBase {
	private readonly ICustomerService _customerService;

	public CustomerController(ICustomerService customerService) {
		_customerService = customerService;
	}

	[HttpPost("api/v1/customers/")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateCustomer(
		[FromBody] CustomerViewModel model) {
		if (!ModelState.IsValid)
			return BadRequest(new ResultViewModel<Customer>(ModelState.Values
				.SelectMany(x => x.Errors)
				.Select(x => x.ErrorMessage)
				.ToList()));

		var result = await _customerService.HandleCreateCustomer(model);
		return Ok(new ResultViewModel<Customer>(result));
	}
}