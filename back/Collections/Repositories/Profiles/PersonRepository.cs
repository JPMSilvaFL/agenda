using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Profiles;

public class PersonRepository : Repository<Person>, IPersonRepository {
	public PersonRepository(AgendaDbContext context) : base(context) { }
}