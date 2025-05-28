using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Collections.ViewModels.Profiles;

public class NewPasswordViewModel {
	public string Username { get; set; }
	[Length(9,50, ErrorMessage = "Password must be between 9 and 50 characters")]
	public string Password { get; set; }
}