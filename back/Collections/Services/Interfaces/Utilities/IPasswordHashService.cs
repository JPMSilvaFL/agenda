using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces.Utilities;

public interface IPasswordHashService {
	bool VerifyPassword(string password, string hash, Task<User> user);
	string HashPassword(string password);
}