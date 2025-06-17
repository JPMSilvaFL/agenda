using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class AccessService : IAccessService {
	private readonly IAccessRepository _accessRepository;
	private readonly ILogActivityService _logActivityService;

	public AccessService(IAccessRepository accessRepository,
		ILogActivityService logActivityService) {
		_accessRepository = accessRepository;
		_logActivityService = logActivityService;
	}

	public async Task<Access> HandleCreateAccess(AccessViewModel model) {
		var access = new Access(model.Name);
		await _accessRepository.AddAsync(access);
		await _accessRepository.SaveChangesAsync();
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreateAccess, access.Id,
			$"Access {access.Name} created successfully");
		return access;
	}
}