namespace AgendaApi.Collections.ViewModels.Schedule;

public class SearchAvailableViewModel {
	public string EmployeeName { get; set; }
	public DateTime Initial { get; set; }
	public DateTime Final { get; set; }
	public int Skip { get; set; }
	public int Take { get; set; }
}