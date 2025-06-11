using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class UserService : IUserService {
	private readonly IUserRepository _userRepository;
	private readonly IAccessRepository _accessRepository;
	private readonly IPasswordHashService _passwordHashService;

	public UserService(IUserRepository userRepository, IAccessRepository accessRepository, IPasswordHashService passwordHashService) {
		_userRepository = userRepository;
		_accessRepository = accessRepository;
		_passwordHashService = passwordHashService;
	}

	public async Task<IList<User>> HandleListUser() {
		return await _userRepository.GetAllAsync();
	}

	public async Task<User> HandleCreateUser(UserViewModel model) {
		var person = new Person(model.FullName, model.Email, model.Document, model.Phone, model.Address, model.Type);

		var user = new User(model.Username, model.Password, person, model.IdAccess);
		var passwordHashed = _passwordHashService.HashPassword(user.PasswordHash);
		user.PasswordHash = passwordHashed;
		await _userRepository.AddAsync(user);
		await _userRepository.SaveChangesAsync();
		return user;
	}

	public async Task<bool> HandleAuthenticateUser(LoginViewModel model) {
		var user = await _userRepository.GetUser(model.Username);
		var verifyPassword = _passwordHashService.VerifyPassword(user.PasswordHash, model.Password, user);
		return verifyPassword;
	}

	public async Task<User> HandleGetUser(string username) {
		return await _userRepository.GetUser(username);
	}
}