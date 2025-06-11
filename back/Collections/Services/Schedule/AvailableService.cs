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
		var available = new Available(model.IdEmployee, model.InitialTime,
			model.FinalTime);
		await _availableRepository.AddAsync(available);
		await _availableRepository.SaveChangesAsync();
		return available;
	}

	public async Task<List<QueryAvailableViewModel>> HandleSearchAvailable(
		SearchAvailableViewModel model) {
		var result =
			await _availableRepository.SearchAvailable(model.Status, model.Skip,
				model.Take);
		return result;
	}
}