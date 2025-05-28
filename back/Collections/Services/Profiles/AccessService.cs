using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class AccessService : IAccessService{
	private readonly IAccessRepository _accessRepository;

	public AccessService(IAccessRepository accessRepository) {
		_accessRepository = accessRepository;
	}
	
	public async Task<Access> HandleCreateAccess(AccessViewModel model) {
		var access = new Access(model.Name);
		await _accessRepository.AddAsync(access);
		await _accessRepository.SaveChangesAsync();
		return access;
	}
}