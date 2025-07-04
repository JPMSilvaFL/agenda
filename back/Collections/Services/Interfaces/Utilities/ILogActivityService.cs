﻿using AgendaApi.Collections.Enum;

namespace AgendaApi.Collections.Services.Interfaces.Utilities;

public interface ILogActivityService {
	Task CreateLog(ELogType type, EAction action, ELogCode code, Guid objectId,
		string description);
}