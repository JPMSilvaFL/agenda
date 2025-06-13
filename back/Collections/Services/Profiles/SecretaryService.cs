using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class SecretaryService : ISecretaryService {
	private readonly ISecretaryRepository _secretaryRepository;
	private readonly ILogActivityService _logActivityService;

	public SecretaryService(ISecretaryRepository secretaryRepository,
		ILogActivityService logActivityService) {
		_secretaryRepository = secretaryRepository;
		_logActivityService = logActivityService;
	}

	public async Task<Secretary>
		HandleCreateSecretary(SecretaryViewModel model) {
		var secretary = new Secretary(model.IdEmployee);

		await _secretaryRepository.AddAsync(secretary);
		await _secretaryRepository.SaveChangesAsync();

		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreateSecretary,
			secretary.Id, "Created Secretary successfully.");
		return secretary;
	}
}