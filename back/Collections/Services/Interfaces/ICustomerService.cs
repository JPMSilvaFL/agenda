using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces;

public interface ICustomerService {
	Task<Customer> HandleCreateCustomer(CustomerViewModel model);
	Task<IList<Customer>> HandleListCustomer();
}