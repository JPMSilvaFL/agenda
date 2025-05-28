using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces;

public interface ITokenService {
	Task<ResultViewModel<JwtViewModel>> GenerateToken(User user);
}