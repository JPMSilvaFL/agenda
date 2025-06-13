using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Interfaces.Schedule;

public interface IPurposeService {
	Task<Purpose> HandleCreatePurpose(PurposeViewModel model);
	Task<List<Purpose>> HandleGetPurpose(SearchPurposeViewModel model);
	Task<Purpose> HandleGetPurposeById(Guid idPurpose);
}