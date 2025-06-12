using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces.Profiles;

public interface IRoleService {
	Task<Role> HandleCreateRole(RoleViewModel model);
}