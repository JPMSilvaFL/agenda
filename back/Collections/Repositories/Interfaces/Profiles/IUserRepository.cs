using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Interfaces.Profiles;

public interface IUserRepository : IRepository<User> {
	Task<User> GetUser(string username);
	
}