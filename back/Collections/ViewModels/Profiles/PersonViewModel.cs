using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Collections.ViewModels.Profiles;

public class PersonViewModel {
	[Required] public string FullName { get; set; }
	[Required] public string Email { get; set; }
	[Required] public string Phone { get; set; }
	[Required] public string Document { get; set; }
	[Required] public string Type { get; set; }
	[Required] public string Address { get; set; }

	public PersonViewModel(string fullName, string email, string phone,
		string document, string type,
		string address) {
		FullName = fullName;
		Email = email;
		Phone = phone;
		Document = document;
		Type = type;
		Address = address;
	}
}