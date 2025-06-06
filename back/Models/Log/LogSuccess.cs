namespace AgendaApi.Models.Log;

public class LogSuccess {
	public ELogCode Code { get; set; }
	public string Description { get; set; }

	public LogSuccess(ELogCode code ,string description) {
		Code = code;
		Description = description;
	}
}