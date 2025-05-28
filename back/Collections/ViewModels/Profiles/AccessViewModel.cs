using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Collections.ViewModels.Profiles;

public class AccessViewModel {
	[Required(ErrorMessage = "Name is required")]
	[Length(5,50, ErrorMessage = "Name must be between 5 and 50 characters")]
	public string Name { get; set; } = null!;
}