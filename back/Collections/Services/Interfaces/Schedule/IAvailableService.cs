using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Interfaces.Schedule;

public interface IAvailableService {
	Task<Available> HandleCreateAvailable(AvailableViewModel model);

	Task<bool>
		HandleUpdateAvailable(AvailableViewModel model, Guid idScheduled);

	Task<List<QueryAvailableViewModel>?> HandleSearchAvailable(
		SearchAvailableViewModel model);

	Task<Available?> HandleGetAvailableByEmployeeAndInitialTime(
		Guid employee, DateTime initialTime);
}