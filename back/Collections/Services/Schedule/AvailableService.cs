using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Schedule;

public class AvailableService : IAvailableService {
	private readonly IAvailableRepository _availableRepository;

	public AvailableService(IAvailableRepository availableRepository) {
		_availableRepository = availableRepository;
	}

	public async Task<Available>
		HandleCreateAvailable(AvailableViewModel model) {
		Available? available = null;
		for (var x = model.InitialTime;
		     x < model.FinalTime;
		     x = x.AddMinutes(5)) {
			if (await _availableRepository.GetByEmployeeAndInitialTime(
				    model.IdEmployee, x) != null)
				throw new AvailableErrorException("Already alocated.");
			available = new Available(model.IdEmployee, x);
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

	public async Task<List<QueryAvailableViewModel>> HandleSearchAvailable(
		SearchAvailableViewModel model) {
		var result =
			await _availableRepository.SearchAvailable(model.Status, model.Skip,
				model.Take);
		return result;
	}

	public async Task<Available>? HandleGetAvailableByEmployeeAndInitialTime(
		Guid employee, DateTime initialTime) {
		var available =
			await _availableRepository.GetByEmployeeAndInitialTime(
				employee, initialTime);
		return available;
	}
}