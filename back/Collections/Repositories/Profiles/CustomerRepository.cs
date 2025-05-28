using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Profiles;

public class CustomerRepository : Repository<Customer>, ICustomerRepository {
	public CustomerRepository(AgendaDbContext context) : base(context) { }
}