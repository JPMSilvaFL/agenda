namespace AgendaApi.Collections.ViewModels.Schedule;

public class PurposeViewModel {
	public PurposeViewModel(Guid idRole, string name, string description,
		float value, int durationInMinutes) {
		IdRole = idRole;
		Name = name;
		Description = description;
		Value = value;
		DurationInMinutes = durationInMinutes;
	}

	public Guid IdRole { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public float Value { get; set; }
	public int DurationInMinutes { get; set; }
}