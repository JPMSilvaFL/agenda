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

	public async Task<List<QueryAvailableViewModel>> SearchAvailable(
		char status, int skip, int take) {
		var result = _context.Availables.AsQueryable();
		if (status is 'A' or 'F' or 'C')
			result = result.Where(a => a.Status == status);

		return await result
			.Include(a => a.FromEmployee)
			.ThenInclude(x => x!.FromPerson)
			.Select(x => new QueryAvailableViewModel(
				x.FromEmployee!.FromPerson!.FullName,
				x.InitialTime,
				x.Status))
			.AsNoTracking()
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}
}