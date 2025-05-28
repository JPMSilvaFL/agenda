using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Collections.ViewModels.Profiles;

public class PersonViewModel {
	[Required]
	public string FullName { get; set; }
	[Required]
	public string Email { get; set; }
	[Required]
	public string Phone { get; set; }
	[Required]
	public string Document { get; set; }
	[Required]
	public string Type { get; set; }
	[Required]
	public string Address { get; set; }
}