using AgendaApi.Models.Log;

namespace AgendaApi.Collections.Services.Interfaces.Utilities;

public interface ILogActivityService {
	LogSuccess CreateLogSuccess(ELogCode code, string description);
	Task CreateLog(Guid user, ELogType type, EAction action, ELogCode code, string description);
}