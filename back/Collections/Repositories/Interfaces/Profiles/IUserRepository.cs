using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Interfaces.Profiles;

public interface IUserRepository : IRepository<User> {
	Task<User> GetUser(string username);
	Task<bool> ValidUserByUsername(string username);
	Task<bool> UpdatePassword(string username, string password);


}