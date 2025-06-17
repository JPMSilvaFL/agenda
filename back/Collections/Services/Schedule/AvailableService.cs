using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Schedule;

public class AvailableService : IAvailableService {
	private readonly IAvailableRepository _availableRepository;
	private readonly ILogActivityService _logActivityService;
	private readonly IHttpContextAccessor _httpContextAccessor;


	public AvailableService(IAvailableRepository availableRepository,
		ILogActivityService logActivityService,
		IHttpContextAccessor httpContextAccessor) {
		_availableRepository = availableRepository;
		_logActivityService = logActivityService;
		_httpContextAccessor = httpContextAccessor;
	}

	public async Task<Available>
		HandleCreateAvailable(AvailableViewModel model) {
		Available? available = null;
		for (var x = model.InitialTime;
		     x < model.FinalTime;
		     x = x.AddMinutes(5)) {
			available = new Available(model.IdEmployee, x);
			var confirm =
				await _availableRepository.GetByEmployeeAndInitialTime(
					model.IdEmployee, x);
			if (confirm != null)
				throw new AvailableErrorException("Already alocated.");
			await _availableRepository.AddAsync(available);
		}

		await _availableRepository.SaveChangesAsync();
		if (available == null)
			throw new AvailableErrorException("Available is returning null");
		return available;
	}

	public async Task<bool> HandleUpdateAvailable(AvailableViewModel model,
		Guid idScheduled) {
		for (var x = model.InitialTime;
		     x < model.FinalTime;
		     x = x.AddMinutes(5)) {
			var available =
				await _availableRepository.GetByEmployeeAndInitialTime(
					model.IdEmployee, x);
			if (available != null && available.IdScheduled == null)
				available.IdScheduled = idScheduled;
		}

		await _availableRepository.SaveChangesAsync();
		return true;
	}

	public async Task<List<QueryAvailableViewModel>?> HandleSearchAvailable(
		SearchAvailableViewModel model) {
		var userIdClaim =
			_httpContextAccessor.HttpContext?.User.FindFirst("UserId");
		var result =
			await _availableRepository.SearchAvailable(model);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Get,
			ELogCode.SearchAvailable, Guid.Empty,
			"Success getting available list" + userIdClaim);
		return result;
	}

	public async Task<Available?> HandleGetAvailableByEmployeeAndInitialTime(
		Guid employee, DateTime initialTime) {
		var available =
			await _availableRepository.GetByEmployeeAndInitialTime(
				employee, initialTime);
		return available!;
	}
}