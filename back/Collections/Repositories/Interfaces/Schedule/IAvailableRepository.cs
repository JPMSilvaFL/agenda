﻿using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Repositories.Interfaces.Schedule;

public interface IAvailableRepository : IRepository<Available> {
	Task<List<QueryAvailableViewModel>?> SearchAvailable(
		SearchAvailableViewModel model);

	Task<Available> UpdateAvailableScheduled(Guid idAvailable,
		Guid idScheduled);

	Task<Available?> GetByEmployeeAndInitialTime(Guid employeeId,
		DateTime initialTime);
}