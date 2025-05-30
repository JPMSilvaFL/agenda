using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Data;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Repositories.Schedule;

public class AvailableRepository : Repository<Available>, IAvailableRepository {
	private readonly AgendaDbContext _context;

	public AvailableRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}
}