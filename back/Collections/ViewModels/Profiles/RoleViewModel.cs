namespace AgendaApi.Collections.ViewModels.Profiles;

public class RoleViewModel {
	public RoleViewModel(string name, string description) {
		Name = name;
		Description = description;
	}

	public string Name { get; set; }
	public string Description { get; set; }
}