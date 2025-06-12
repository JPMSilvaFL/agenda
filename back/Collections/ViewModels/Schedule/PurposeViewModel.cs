namespace AgendaApi.Collections.ViewModels.Schedule;

public class PurposeViewModel {
	public Guid IdRole { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public float Value { get; set; }
	public int DurationInMinutes { get; set; }
}