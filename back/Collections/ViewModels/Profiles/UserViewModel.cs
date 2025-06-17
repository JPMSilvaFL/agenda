using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Collections.ViewModels.Profiles;

public class UserViewModel {
	public UserViewModel(PersonViewModel person, Guid idAccess, string username,
		string password) {
		Person = person;
		IdAccess = idAccess;
		Username = username;
		Password = password;
	}

	[Required(ErrorMessage = "Username is required")]
	[Length(6, 50,
		ErrorMessage = "Username must be between 6 and 50 characters")]
	public string Username { get; set; }

	[Required(ErrorMessage = "Password is required")]
	[Length(9, 50,
		ErrorMessage = "Password must be between 9 and 50 characters")]
	public string Password { get; set; }

	public PersonViewModel Person { get; set; }
	public Guid IdAccess { get; set; }
}