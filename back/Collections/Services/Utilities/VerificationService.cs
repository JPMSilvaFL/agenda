using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Profiles;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Utilities;

public class VerificationService : IVerificationService {
	private readonly IScheduledService _scheduledService;
	private readonly ILogActivityService _logActivityService;
	private readonly IAvailableService _availableService;
	private readonly IPurposeService _purposeService;
	private readonly ISecretaryService _secretaryService;

	public VerificationService(IScheduledService scheduledService,
		ILogActivityService logActivityService,
		IAvailableService availableService,
		IPurposeService purposeService,
		ISecretaryService  secretaryService) {
		_scheduledService = scheduledService;
		_logActivityService = logActivityService;
		_availableService = availableService;
		_purposeService = purposeService;
		_secretaryService = secretaryService;
	}

	public async Task<Scheduled>? HandleVerificationScheduledIntegrity(ScheduledViewModel model) {
		var secretary =
			await _secretaryService.HandleGetSecretaryById(model.IdSecretary);
		if (secretary == null)
			throw new SecretaryNullException("Secretary not found");

		var purpose =
			await _purposeService.HandleGetPurposeById(model.IdPurpose);
		if (purpose == null)
			throw new PurposeNullException("Purpose not found.");

		var scheduled = new Scheduled(model.IdCustomer, model.IdSecretary, model.IdPurpose);
		return scheduled;
	}
}