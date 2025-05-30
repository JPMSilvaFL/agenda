using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Data;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Repositories.Schedule;

public class ScheduledRepository : Repository<Scheduled>, IScheduledRepository {
	private readonly AgendaDbContext _context;

	public ScheduledRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}
}