using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Interfaces.Profiles;

public interface IPersonRepository : IRepository<Person> {
	Task<bool> ConfirmUniqueKey(string key);
}