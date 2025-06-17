using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class PersonService : IPersonService {
	private readonly IPersonRepository _personRepository;
	private readonly ILogActivityService _logActivityService;


	public PersonService(IPersonRepository personRepository,
		ILogActivityService logActivityService) {
		_personRepository = personRepository;
		_logActivityService = logActivityService;
	}

	public async Task<Person> HandleCreatePerson(PersonViewModel model) {
		if (await _personRepository.ConfirmUniqueKey(model.Document))
			throw new DuplicatePersonException(
				"A person with the same document already exists.");
		if (await _personRepository.ConfirmUniqueKey(model.Email))
			throw new DuplicatePersonException(
				"A person with the same email already exists.");
		var person = new Person(model.FullName, model.Email, model.Document,
			model.Phone, model.Address, model.Type);
		await _personRepository.AddAsync(person);
		await _personRepository.SaveChangesAsync();

		await _logActivityService
			.CreateLog(
				ELogType.Success,
				EAction.Saved,
				ELogCode.CreatePerson,
				person.Id,
				"Person created successfully.");
		return person;
	}

	public async Task<IList<Person>> HandleListPerson() {
		var persons = await _personRepository.GetAllAsync();
		return persons;
	}
}