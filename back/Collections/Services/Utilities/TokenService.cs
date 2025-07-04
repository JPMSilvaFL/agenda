﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AgendaApi.Collections.Services.Utilities;

public class TokenService : ITokenService {
	private readonly AgendaDbContext _context;
	private readonly IUserService _userService;
	private readonly ILogActivityService _logActivityService;

	public TokenService(AgendaDbContext context, IUserService userService,
		ILogActivityService logActivityService) {
		_context = context;
		_userService = userService;
		_logActivityService = logActivityService;
	}

	public async Task<JwtViewModel> GenerateToken(LoginViewModel model) {
		var validateUser = await _userService.HandleAuthenticateUser(model);
		if (!validateUser)
			throw new InvalidUserException("Usuário Inválido.");

		var user = await _userService.HandleGetUserByUsername(model.Username);
		if (user == null)
			throw new UserNullException("User has a null value.");

		var userDb = await _context
			.Users
			.AsNoTracking()
			.Include(x => x.FromAccess)
			.FirstOrDefaultAsync(x => x.Id == user.Id);

		if (userDb == null) return new JwtViewModel(string.Empty);

		var tokenHandler = new JwtSecurityTokenHandler();

		var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

		var tokenDescriptor = new SecurityTokenDescriptor {
			Subject = new ClaimsIdentity([
				new Claim(ClaimTypes.Name, userDb.Username),
				new Claim("UserId", userDb.Id.ToString()),
				new Claim("AccessId", userDb.IdAccess.ToString()),
				new Claim(ClaimTypes.Role, userDb.FromAccess!.Name)
			]),
			Expires = DateTime.UtcNow.AddHours(6),
			SigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		var tokenGerado = tokenHandler.WriteToken(token);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.Login, userDb.Id, "User logged successfully.");
		return new JwtViewModel(tokenGerado);
	}

	public bool ValidateToken(string token) {
		var tokenHandler = new JwtSecurityTokenHandler();
		try {
			tokenHandler.ValidateToken(token, new TokenValidationParameters {
				ValidateIssuerSigningKey = true,
				IssuerSigningKey =
					new SymmetricSecurityKey(
						Encoding.ASCII.GetBytes(Configuration.JwtKey)),
				ValidateIssuer = false,
				ValidateAudience = false
			}, out _);
			return true;
		}
		catch {
			return false;
		}
	}
}