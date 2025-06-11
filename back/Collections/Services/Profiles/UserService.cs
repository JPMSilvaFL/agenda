using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Log;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class UserService : IUserService {
	private readonly IUserRepository _userRepository;
	private readonly IPasswordHashService _passwordHashService;
	private readonly IPersonService _personService;
	private readonly ILogActivityService _logActivityService;

	public UserService(
		IUserRepository userRepository,
		IPasswordHashService passwordHashService,
		IPersonService personService,
		ILogActivityService logActivityService) {
		_logActivityService = logActivityService;
		_userRepository = userRepository;
		_personService = personService;
		_passwordHashService = passwordHashService;
	}

	public async Task<IList<User>> HandleListUser() {
		return await _userRepository.GetAllAsync();
	}

	public async Task<User> HandleCreateUser(UserViewModel model) {
		var person = await _personService.HandleCreatePerson(
			new PersonViewModel(model.FullName,
				model.Email,
				model.Phone,
				model.Document,
				model.Type,
				model.Address));
		var user = new User(
			model.Username,
			model.Password,
			person.Id,
			model.IdAccess);
		var passwordHashed =
			_passwordHashService.HashPassword(user.PasswordHash);
		user.PasswordHash = passwordHashed;
		await _userRepository.AddAsync(user);
		await _userRepository.SaveChangesAsync();
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreateUser, user.Id, "User created sucessfully.");
		return user;
	}

	public async Task<bool> HandleAuthenticateUser(LoginViewModel model) {
		var user = await _userRepository.GetUser(model.Username);
		var verifyPassword =
			_passwordHashService.VerifyPassword(user.PasswordHash,
				model.Password, user);
		return verifyPassword;
	}

	public async Task<User> HandleGetUser(string username) {
		return await _userRepository.GetUser(username);
	}
}