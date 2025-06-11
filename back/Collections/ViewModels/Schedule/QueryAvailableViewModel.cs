namespace AgendaApi.Collections.ViewModels.Schedule;

public class QueryAvailableViewModel {
	public string NamePerson { get; set; }
	public DateTime InitialTime { get; set; }
	public DateTime FinalTime { get; set; }
	public char Status { get; set; }

	public QueryAvailableViewModel(string namePerson, DateTime initialTime,
		DateTime finalTime, char status) {
		NamePerson = namePerson;
		InitialTime = initialTime;
		FinalTime = finalTime;
		Status = status;
	}
}