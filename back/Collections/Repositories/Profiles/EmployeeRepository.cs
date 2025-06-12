using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Profiles;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository {
	private readonly AgendaDbContext _context;

	public EmployeeRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}
}