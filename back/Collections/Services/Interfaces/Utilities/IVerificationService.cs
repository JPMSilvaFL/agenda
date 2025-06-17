using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Interfaces.Utilities;

public interface IVerificationService {
	Task<Scheduled?> HandleVerificationScheduledIntegrity(
		ScheduledViewModel model);
}