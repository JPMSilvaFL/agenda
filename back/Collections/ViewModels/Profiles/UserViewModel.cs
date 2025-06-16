using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Collections.ViewModels.Profiles;

public class UserViewModel {
	[Required(ErrorMessage = "Username is required")]
	[Length(6, 50,
		ErrorMessage = "Username must be between 6 and 50 characters")]
	public string Username { get; set; } = null!;

	[Required(ErrorMessage = "Password is required")]
	[Length(9, 50,
		ErrorMessage = "Password must be between 9 and 50 characters")]
	public string Password { get; set; } = null!;

	public PersonViewModel Person { get; set; }
	public Guid IdAccess { get; set; }
}