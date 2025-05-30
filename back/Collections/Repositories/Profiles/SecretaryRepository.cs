using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Profiles;

public class SecretaryRepository : Repository<Secretary>, ISecretaryRepository {
	private readonly AgendaDbContext _context;

	public SecretaryRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}
}