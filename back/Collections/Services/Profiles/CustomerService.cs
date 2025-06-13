using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Log;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class CustomerService : ICustomerService {
	private readonly ICustomerRepository _customerRepository;
	private readonly ILogActivityService _logActivityService;

	public CustomerService(ICustomerRepository customerRepository,
		ILogActivityService logActivityService) {
		_customerRepository = customerRepository;
		_logActivityService = logActivityService;
	}

	public async Task<Customer> HandleCreateCustomer(CustomerViewModel model) {
		var customer = new Customer(model.IdPerson);
		await _customerRepository.AddAsync(customer);
		await _customerRepository.SaveChangesAsync();
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created,
			ELogCode.CreateCustomer, customer.Id,
			$"Customer {customer.FromPerson.FullName} created Successfully");
		return customer;
	}

	public async Task<IList<Customer>> HandleListCustomer() {
		var customers = await _customerRepository.GetAllAsync();
		return customers;
	}
}