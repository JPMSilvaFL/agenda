using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Log;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class RoleService : IRoleService {
	private readonly IRoleRepository _roleRepository;
	private readonly ILogActivityService _logActivityService;

	public RoleService(IRoleRepository roleRepository,
		ILogActivityService logActivityService) {
		_roleRepository = roleRepository;
		_logActivityService = logActivityService;
	}

	public async Task<Role> HandleCreateRole(RoleViewModel model) {
		var role = new Role(model.Name, model.Description);
		await _roleRepository.AddAsync(role);
		await _roleRepository.SaveChangesAsync();
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreateRole, role.Id,
			$"Role {role.Name} created successfully.");
		return role;
	}
}