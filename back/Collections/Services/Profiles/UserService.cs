using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.Services.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Identity;

namespace AgendaApi.Collections.Services.Profiles;

public class UserService : IUserService{
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

		//var accessDatabase = await _accessRepository.GetByIdAsync(model.IdAccess);
		//var access = new Access(accessDatabase.Id , accessDatabase.Name, accessDatabase.CreatedAt);

		var user = new User(model.Username, model.Password, person, model.IdAccess);
		var passwordHashed = _passwordHashService.HashPassword(user.PasswordHash);
		user.PasswordHash = passwordHashed;
		await _userRepository.AddAsync(user);
		await _userRepository.SaveChangesAsync();
		return user;
	}

	public bool HandleAuthenticateUser(LoginViewModel model) {
		try {
			var user = _userRepository.GetUser(model.Username);
			var verifyPassword = _passwordHashService.VerifyPassword(user.Result.PasswordHash,model.Password, user);
			return verifyPassword;
		}
		catch {
			return false;
		}
	}

	public async Task<User> HandleGetUser(string username) {
		return await _userRepository.GetUser(username);
	}

	public async Task<bool> HandleValidUsername(NewPasswordViewModel model) {
		return await _userRepository.ValidUserByUsername(model.Username);
	}

	public async Task<bool> HandleUpdatePassword(string username, string password) {
		return await _userRepository.UpdatePassword(username, password);
	}
}