using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces;

public interface IPersonService {
	Task<Person> HandleCreatePerson(PersonViewModel model);
	Task<IList<Person>> HandleListPerson();
}