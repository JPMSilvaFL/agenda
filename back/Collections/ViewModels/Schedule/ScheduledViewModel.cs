namespace AgendaApi.Collections.ViewModels.Schedule;

public class ScheduledViewModel {
	public Guid IdCustomer { get; set; }
	public Guid IdSecretary { get; set; }
	public Guid IdPurpose { get; set; }
	public Guid IdEmployee { get; set; }
	public DateTime InitialTime { get; set; }
}