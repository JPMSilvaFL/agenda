using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Collections.ViewModels.Schedule;
using AgendaApi.Data;
using AgendaApi.Models.Schedule;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Collections.Repositories.Schedule;

public class AvailableRepository : Repository<Available>, IAvailableRepository {
	private readonly AgendaDbContext _context;

	public AvailableRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}

	public async Task<List<QueryAvailableViewModel>?> SearchAvailable(
		SearchAvailableViewModel model) {
		var result = _context.Availables.AsQueryable();

		return await result
			.Include(a => a.FromEmployee)
			.ThenInclude(x => x!.FromUser)
			.ThenInclude(x => x!.FromPerson)
			.Where(x => x.Status == 'A')
			.Select(x => new QueryAvailableViewModel(
				x.FromEmployee!.FromUser!.FromPerson!.FullName,
				x.InitialTime,
				x.Status))
			.AsNoTracking()
			.Skip(model.Skip)
			.Take(model.Take)
			.ToListAsync();
	}

	public async Task<Available?> GetByEmployeeAndInitialTime(Guid employeeId,
		DateTime initialTime) {
		var available = await _context
			.Availables
			.FirstOrDefaultAsync(x =>
				x.IdEmployee == employeeId && x.InitialTime == initialTime);

		return available;
	}


	public async Task<Available> UpdateAvailableScheduled(Guid idAvailable,
		Guid idScheduled) {
		var availableScheduled =
			await _context.Availables.FindAsync(idAvailable);
		availableScheduled!.IdScheduled = idScheduled;
		return availableScheduled;
	}
}