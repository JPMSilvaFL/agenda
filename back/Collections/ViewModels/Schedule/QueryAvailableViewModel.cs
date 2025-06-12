namespace AgendaApi.Collections.ViewModels.Schedule;

public class QueryAvailableViewModel {
	public string NamePerson { get; set; }
	public DateTime InitialTime { get; set; }
	public char Status { get; set; }

	public QueryAvailableViewModel(string namePerson, DateTime initialTime,
		char status) {
		NamePerson = namePerson;
		InitialTime = initialTime;
		Status = status;
	}
}