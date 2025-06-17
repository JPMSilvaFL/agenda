namespace AgendaApi.Collections.ViewModels.Profiles;

public class LoginViewModel {
	public string Username { get; set; }
	public string Password { get; set; }

	public LoginViewModel(string username, string password) {
		Username = username;
		Password = password;
	}
}