using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces.Utilities;

public interface IPasswordHashService {
	bool VerifyPassword(string password, string hash, User user);
	string HashPassword(string password);
}