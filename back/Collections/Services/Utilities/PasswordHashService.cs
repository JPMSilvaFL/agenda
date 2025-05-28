using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Identity;

namespace AgendaApi.Collections.Services.Utilities;

public class PasswordHashService : IPasswordHashService{
	public bool VerifyPassword(string password, string hash, Task<User> user) {
		var hasher = new PasswordHasher<object>();
		return hasher.VerifyHashedPassword(user.Result, password, hash) == PasswordVerificationResult.Success;
	}
	public string HashPassword(string password) {
		var hasher = new PasswordHasher<User>();
		var result = hasher.HashPassword(null, password);
		return result;
	}
}