using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Profiles;

public class CustomerService : ICustomerService {

	private readonly ICustomerRepository _customerRepository;

	public CustomerService(ICustomerRepository customerRepository) {
		_customerRepository = customerRepository;
	}
	public async Task<Customer> HandleCreateCustomer(CustomerViewModel model) {
		var customer = new Customer(model.IdPerson);
		await _customerRepository.AddAsync(customer);
		await _customerRepository.SaveChangesAsync();
		return customer;
	}

	public async Task<IList<Customer>> HandleListCustomer() {
		var customers = await _customerRepository.GetAllAsync();
		return customers;
	}
}