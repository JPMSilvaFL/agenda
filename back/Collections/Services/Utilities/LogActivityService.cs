using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Repositories.Interfaces.Utilities;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Models.Log;

namespace AgendaApi.Collections.Services.Utilities;

public class LogActivityService : ILogActivityService {
	private readonly ILogActivityRepository _logActivityRepository;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public LogActivityService(ILogActivityRepository logActivityRepository,
		IHttpContextAccessor httpContextAccessor) {
		_logActivityRepository = logActivityRepository;
		_httpContextAccessor = httpContextAccessor;
	}


	public async Task CreateLog(ELogType type, EAction action, ELogCode code,
		Guid objectId,
		string description) {
		var userIdClaim =
			_httpContextAccessor.HttpContext?.User.FindFirst("UserId");
		var userId =
			Guid.Parse(userIdClaim != null
				? userIdClaim.Value
				: "0868DBC1-5684-40B0-A74D-5EE22EA80974");
		if (userId == Guid.Empty)
			throw new Exception("Usuário não autenticado.");
		var create = new LogActivity(userId, type, action, code, objectId,
			description);
		await _logActivityRepository.AddAsync(create);
		await _logActivityRepository.SaveChangesAsync();
	}
}