using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces.Profiles;

public interface IUserService {
	Task<IList<User>> HandleListUser();
	Task<User> HandleCreateUser(UserViewModel model);
	Task<bool> HandleAuthenticateUser(LoginViewModel model);
	Task<User> HandleGetUserByUsername(string username);
	Task<User> HandleGetUserById(Guid id);
}