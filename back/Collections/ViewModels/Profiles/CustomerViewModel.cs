namespace AgendaApi.Collections.ViewModels.Profiles;

public class CustomerViewModel {
	public UserViewModel User { get; set; }

	public CustomerViewModel(UserViewModel user) {
		User = user;
	}
}