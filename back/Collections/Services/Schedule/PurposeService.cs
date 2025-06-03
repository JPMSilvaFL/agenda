using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Schedule;

public class PurposeService : IPurposeService{

	private readonly IPurposeRepository _purposeRepository;

	public PurposeService(IPurposeRepository purposeRepository) {
		_purposeRepository = purposeRepository;
	}

	public async Task<Purpose> HandleCreatePurpose(PurposeViewModel model) {
		var purpose = new Purpose(model.IdRole, model.Name, model.Description, model.Value);
		await _purposeRepository.AddAsync(purpose);
		return purpose;
	}

	public async Task<List<Purpose>> HandleGetPurpose(SearchPurposeViewModel model) {
		var result = await _purposeRepository.GetPurpose(model.Role, model.Name, model.Skip, model.Take);
		return result;
	}
}