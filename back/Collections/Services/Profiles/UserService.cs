using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
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
		var verification =
			await _userRepository.GetUser(model.Username);
		if (verification != null)
			throw new UserDuplicateKeyException("Username already exists!");

		var person = await _personService.HandleCreatePerson(
			new PersonViewModel(model.Person.FullName,
				model.Person.Email,
				model.Person.Phone,
				model.Person.Document,
				model.Person.Type,
				model.Person.Address));

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
		if (user == null)
			return false;
		var verifyPassword =
			_passwordHashService.VerifyPassword(user.PasswordHash,
				model.Password, user);
		return verifyPassword;
	}

	public async Task<User?> HandleGetUserByUsername(string username) {
		return await _userRepository.GetUser(username);
	}

	public async Task<User?> HandleGetUserById(Guid id) {
		return await _userRepository.GetByIdAsync(id);
	}

	public async Task HandleChangePassword(
		ChangePasswordByUsernameViewModel model) {
		var user = await _userRepository.GetUser(model.Username);
		if (user == null)
			throw new UserNullException("User not found!");
		user.PasswordHash = _passwordHashService.HashPassword(model.Password);
		await _userRepository.SaveChangesAsync();
	}
}