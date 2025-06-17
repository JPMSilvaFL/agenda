using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class CustomerService : ICustomerService {
	private readonly ICustomerRepository _customerRepository;
	private readonly ILogActivityService _logActivityService;
	private readonly IPersonService _personService;
	private readonly IUserService _userService;

	public CustomerService(ICustomerRepository customerRepository,
		ILogActivityService logActivityService,
		IPersonService personService,
		IUserService userService) {
		_personService = personService;
		_customerRepository = customerRepository;
		_logActivityService = logActivityService;
		_userService = userService;
	}

	public async Task<Customer> HandleCreateCustomer(CustomerViewModel model) {
		await _personService.HandleCreatePerson(model.User.Person);
		var user = await _userService.HandleCreateUser(model.User);
		var customer = new Customer(user.Id);
		await _customerRepository.AddAsync(customer);
		await _customerRepository.SaveChangesAsync();
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreateCustomer, customer.Id,
			$"Customer created Successfully");
		return customer;
	}

	public async Task<IList<Customer>> HandleListCustomer() {
		var customers = await _customerRepository.GetAllAsync();
		return customers;
	}
}