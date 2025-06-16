using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class EmployeeService : IEmployeeService {
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IUserService _userService;
	private readonly ILogActivityService _logActivityService;

	public EmployeeService(IEmployeeRepository employeeRepository,
		IUserService userService, ILogActivityService logActivityService) {
		_employeeRepository = employeeRepository;
		_userService = userService;
		_logActivityService = logActivityService;
	}

	public async Task<Employee> HandleCreateEmployee(
		EmployeeViewModel model) {
		var user = model.User == null
			? await _userService.HandleGetUserById(model.IdUser.Value)
			: await _userService.HandleCreateUser(model.User ??
			                                      throw new ArgumentException(
				                                      "Dados do usuário são obrigatórios para criação."));


		var employee = new Employee(model.IdRole, user.Id);
		await _employeeRepository.AddAsync(employee);
		await _employeeRepository.SaveChangesAsync();
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreateEmployee, employee.Id,
			$"Employee created successfully.");
		return employee;
	}
}