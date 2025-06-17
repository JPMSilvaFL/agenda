using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Utilities;

public class VerificationService : IVerificationService {
	private readonly IAvailableService _availableService;
	private readonly IPurposeService _purposeService;
	private readonly ISecretaryService _secretaryService;

	public VerificationService(IAvailableService availableService,
		IPurposeService purposeService,
		ISecretaryService secretaryService) {
		_availableService = availableService;
		_purposeService = purposeService;
		_secretaryService = secretaryService;
	}

	public async Task<Scheduled?> HandleVerificationScheduledIntegrity(
		ScheduledViewModel model) {
		var secretary =
			await _secretaryService.HandleGetSecretaryById(model.IdSecretary);
		if (secretary == null)
			throw new SecretaryNullException("Secretary not found");

		var purpose =
			await _purposeService.HandleGetPurposeById(model.IdPurpose);
		if (purpose == null)
			throw new PurposeNullException("Purpose not found.");

		var durationInMinutes = purpose.DurationInMinutes;

		for (var x = model.InitialTime;
		     x < model.InitialTime.AddMinutes(durationInMinutes);
		     x = x.AddMinutes(5)) {
			var available =
				await _availableService
					.HandleGetAvailableByEmployeeAndInitialTime(
						model.IdEmployee, x);
			if (available == null)
				throw new AvailableErrorException("No Available registered");
			if (available.IdScheduled != null)
				throw new ScheduledException("Scheduled already scheduled");
		}

		var scheduled = new Scheduled(model.IdCustomer, model.IdSecretary,
			model.IdPurpose);
		return scheduled;
	}
}