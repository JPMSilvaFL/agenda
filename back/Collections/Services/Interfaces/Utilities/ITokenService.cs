using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;

namespace AgendaApi.Collections.Services.Interfaces.Utilities;

public interface ITokenService {
	Task<JwtViewModel> GenerateToken(LoginViewModel model);
}