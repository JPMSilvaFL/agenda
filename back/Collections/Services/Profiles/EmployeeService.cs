using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class EmployeeService : IEmployeeService {
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IPersonService _personService;
	private readonly ILogActivityService _logActivityService;

	public EmployeeService(IEmployeeRepository employeeRepository,
		IPersonService personService, ILogActivityService logActivityService) {
		_employeeRepository = employeeRepository;
		_personService = personService;
		_logActivityService = logActivityService;
	}

	public async Task<Employee> HandleCreateEmployee(
		EmployeeViewModel model) {
		var person = await _personService.HandleCreatePerson(model.Person);
		var employee = new Employee(model.IdRole, person.Id);
		await _employeeRepository.AddAsync(employee);
		await _employeeRepository.SaveChangesAsync();
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreateEmployee, employee.Id,
			$"Employee {person.FullName} created successfully.");
		return employee;
	}
}