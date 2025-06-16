namespace AgendaApi.Collections.ViewModels.Profiles;

public class EmployeeViewModel {
	public Guid IdRole { get; set; }
	public Guid? IdUser { get; set; }
	public UserViewModel? User { get; set; }
}