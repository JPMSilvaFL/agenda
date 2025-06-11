using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Collections.Repositories.Profiles;

public class PersonRepository : Repository<Person>, IPersonRepository {
	private readonly AgendaDbContext _context;

	public PersonRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}

	public async Task<bool> ConfirmUniqueKey(string key) {
		var persons =
			await _context.Persons.FirstOrDefaultAsync(x =>
				x.Document == key || x.Email == key);
		if (persons == null) return false;
		return true;
	}
}