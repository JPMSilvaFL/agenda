using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Services.Interfaces.Schedule;

public interface IScheduledService {
	Task<Scheduled> HandleScheduled(ScheduledViewModel model);
}