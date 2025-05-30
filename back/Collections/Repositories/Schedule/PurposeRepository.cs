using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Data;
using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Repositories.Schedule;

public class PurposeRepository : Repository<Purpose>, IPurposeRepository{
	private readonly AgendaDbContext _context;

	public PurposeRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}
}