using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces.Profiles;

public interface ISecretaryService {
	Task<Secretary> HandleCreateSecretary(SecretaryViewModel secretary);
	Task<Secretary> HandleGetSecretaryById(Guid id);
}