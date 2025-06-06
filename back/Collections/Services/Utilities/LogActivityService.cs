using AgendaApi.Collections.Repositories.Interfaces.Utilities;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Models.Log;

namespace AgendaApi.Collections.Services.Utilities;

public class LogActivityService : ILogActivityService {
	private readonly ILogActivityRepository _logActivityRepository;

	public LogActivityService(ILogActivityRepository logActivityRepository) {
		_logActivityRepository = logActivityRepository;
	}

	public LogSuccess CreateLogSuccess(ELogCode code, string description) {
		return new LogSuccess(code, description);
	}

	public async Task CreateLog(Guid user, ELogType type, EAction action, ELogCode code, string description) {
		var create = new LogActivity(user, type, action, code, description);
		await _logActivityRepository.AddAsync(create);
		await _logActivityRepository.SaveChangesAsync();
	}
}