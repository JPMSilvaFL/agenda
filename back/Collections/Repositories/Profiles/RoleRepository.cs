using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Profiles;

public class RoleRepository : Repository<Role>, IRoleRepository {
	private readonly AgendaDbContext _context;

	public RoleRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}
}