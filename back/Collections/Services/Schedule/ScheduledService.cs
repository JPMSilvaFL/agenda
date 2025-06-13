using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Schedule;

public class ScheduledService : IScheduledService {
	private readonly IScheduledRepository _scheduledRepository;
	private readonly ILogActivityService _logActivityService;
	private readonly IAvailableService _availableService;
	private readonly IPurposeService _purposeService;

	public ScheduledService(IScheduledRepository scheduledRepository,
		ILogActivityService logActivityService,
		IAvailableService availableService,
		IPurposeService purposeRepository) {
		_scheduledRepository = scheduledRepository;
		_logActivityService = logActivityService;
		_availableService = availableService;
		_purposeService = purposeRepository;
	}

	public async Task<Scheduled> HandleScheduled(ScheduledViewModel model) {
		var scheduled = new Scheduled(model.IdCustomer, model.IdSecretary,
			model.IdPurpose);

		var purpose =
			await _purposeService.HandleGetPurposeById(model.IdPurpose);

		if (purpose == null)
			throw new PurposeNullException("Purpose has a null value.");

		await _scheduledRepository.AddAsync(scheduled);
		await _scheduledRepository.SaveChangesAsync();
		await _availableService.HandleUpdateAvailable(
			new AvailableViewModel(model.IdEmployee, model.InitialTime,
				model.InitialTime.AddMinutes(purpose.DurationInMinutes)),
			scheduled.Id);

		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreateSchedule, scheduled.Id,
			"Successfully created scheduled.");

		return scheduled;
	}
}