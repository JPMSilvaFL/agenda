using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Collections.Services.Interfaces.Profiles;

public interface IEmployeeService {
	Task<Employee> HandleCreateEmployee(EmployeeViewModel model);
}