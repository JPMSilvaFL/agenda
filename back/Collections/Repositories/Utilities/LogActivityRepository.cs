using AgendaApi.Collections.Repositories.Interfaces.Utilities;
using AgendaApi.Data;
using AgendaApi.Models.Utilities;

namespace AgendaApi.Collections.Repositories.Utilities;

public class LogActivityRepository : Repository<LogActivity>,
	ILogActivityRepository {
	private readonly AgendaDbContext _context;

	public LogActivityRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}
}