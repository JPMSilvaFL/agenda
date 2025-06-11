using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Repositories.Interfaces.Schedule;

public interface IAvailableRepository : IRepository<Available> {
	Task<List<QueryAvailableViewModel>> SearchAvailable(char status, int skip,
		int take);
}