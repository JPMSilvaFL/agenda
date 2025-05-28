using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces;

public interface IAccessService {
	Task<Access> HandleCreateAccess(AccessViewModel model);
}