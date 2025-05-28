using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces;

public interface IUserService{
	Task<IList<User>> HandleListUser();
	Task<User> HandleCreateUser(UserViewModel model);
	bool HandleAuthenticateUser(LoginViewModel model);
	Task<User> HandleGetUser(string username);
	Task<bool> HandleValidUsername(NewPasswordViewModel model);
	Task<bool> HandleUpdatePassword(string username, string password);
}