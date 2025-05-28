using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AgendaApi.Collections.Services.Profiles;

public class TokenService : ITokenService{
	private readonly AgendaDbContext _context;

	public TokenService(AgendaDbContext context) {
		_context = context;
	}

	public async Task<ResultViewModel<JwtViewModel>> GenerateToken(User user) {
		var userDb = await _context
			.Users
			.AsNoTracking()
			.Include(x => x.FromAccess)
			.Include(x => x.FromPerson)
			.FirstOrDefaultAsync();

		if(userDb == null) return new ResultViewModel<JwtViewModel>("Error in pushing user from database");

		var tokenHandler = new JwtSecurityTokenHandler();

		var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

		var tokenDescriptor = new SecurityTokenDescriptor {
			Subject = new ClaimsIdentity([
				new Claim(ClaimTypes.Name, user.Username),
				new Claim("PessoaId", user.IdPerson.ToString()),
				new Claim("PerfilAcessoId", user.IdAccess.ToString()),
				new Claim(ClaimTypes.Role, userDb.FromAccess!.Name),
				new Claim(ClaimTypes.Email, userDb.FromPerson!.Email)
			]),
			Expires = DateTime.UtcNow.AddHours(6),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		var tokenGerado = tokenHandler.WriteToken(token);
		var tokenObj = new JwtViewModel(tokenGerado);
		return (new ResultViewModel<JwtViewModel>(tokenObj));
	}
}