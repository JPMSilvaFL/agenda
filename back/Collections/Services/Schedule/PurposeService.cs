using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Schedule;

public class PurposeService : IPurposeService {
	private readonly IPurposeRepository _purposeRepository;
	private readonly ILogActivityService _logActivityService;

	public PurposeService(IPurposeRepository purposeRepository,
		ILogActivityService logActivityService) {
		_purposeRepository = purposeRepository;
		_logActivityService = logActivityService;
	}

	public async Task<Purpose> HandleCreatePurpose(PurposeViewModel model) {
		var purpose = new Purpose(model.IdRole, model.Name, model.Description,
			model.Value, model.DurationInMinutes);
		await _purposeRepository.AddAsync(purpose);
		await _purposeRepository.SaveChangesAsync();
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreatePurpose, purpose.Id,
			$"Created purpose {purpose.Name} successfully"
		);
		return purpose;
	}

	public async Task<List<Purpose>> HandleGetPurpose(
		SearchPurposeViewModel model) {
		var result = await _purposeRepository.GetPurpose(model.Role, model.Name,
			model.Skip, model.Take);
		return result;
	}

	public async Task<Purpose?> HandleGetPurposeById(Guid idPurpose) {
		var purpose = await _purposeRepository.GetPurposeById(idPurpose);
		return purpose!;
	}
}