using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Interfaces.Schedule;

public interface IAvailableService {
	Task<Available> HandleCreateAvailable(AvailableViewModel model);
	Task<List<QueryAvailableViewModel>> HandleSearchAvailable(SearchAvailableViewModel model);
}