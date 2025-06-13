using AgendaApi.Collections.Enum;
using AgendaApi.Models.Log;

namespace AgendaApi.Collections.Services.Interfaces.Utilities;

public interface ILogActivityService {
	Task CreateLog(ELogType type, EAction action, ELogCode code, Guid objectId,
		string description);
}