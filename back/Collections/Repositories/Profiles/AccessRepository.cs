using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Profiles;

public class AccessRepository : Repository<Access>, IAccessRepository {
	public AccessRepository(AgendaDbContext context) : base(context) {
		
	}
	
}