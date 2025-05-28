using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class PersonService : IPersonService{

	private readonly IPersonRepository _personRepository;

	public PersonService(IPersonRepository personRepository) {
		_personRepository = personRepository;
	}

	public async Task<Person> HandleCreatePerson(PersonViewModel model) {
		var person = new Person(model.FullName, model.Email, model.Document, model.Phone, model.Address, model.Type);
		await _personRepository.AddAsync(person);
		await _personRepository.SaveChangesAsync();
		return person;
	}

	public async Task<IList<Person>> HandleListPerson() {
		var persons = await _personRepository.GetAllAsync();
		return persons;
	}
}