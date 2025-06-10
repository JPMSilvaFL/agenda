namespace AgendaApi.Collections.ViewModels.Result;

public class JwtViewModel {
	public string Authorization { get; set; }

	public JwtViewModel(string authorization) {
		Authorization = authorization;
	}
}