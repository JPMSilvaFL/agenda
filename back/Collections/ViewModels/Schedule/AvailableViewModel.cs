namespace AgendaApi.Collections.ViewModels.Schedule;

public class AvailableViewModel {
	public AvailableViewModel(Guid idEmployee, DateTime initialTime,
		DateTime finalTime) {
		IdEmployee = idEmployee;
		InitialTime = initialTime;
		FinalTime = finalTime;
	}

	public Guid IdEmployee { get; set; }
	public DateTime InitialTime { get; set; }
	public DateTime FinalTime { get; set; }
}