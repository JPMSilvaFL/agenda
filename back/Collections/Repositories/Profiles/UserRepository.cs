using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Utilities;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Collections.Repositories.Profiles;

public class UserRepository : Repository<User>, IUserRepository{

	private readonly AgendaDbContext _context;

	public UserRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}
	public async Task<User> GetUser(string username) {
		var user = await _context
			.Users
			.FirstOrDefaultAsync(x => x.Username == username);
		return user;
	}

	public async Task<bool> ValidUserByUsername(string username) {
		return await _context.Users.AnyAsync(x => x.Username == username);
	}

	public async Task<bool> UpdatePassword(string username, string password) {
		var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
		if (user == null) return false;
		user.PasswordHash = password;
		Update(user);
		await SaveChangesAsync();
		return true;
	}
}