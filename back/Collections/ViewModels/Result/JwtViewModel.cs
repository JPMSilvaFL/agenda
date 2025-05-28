namespace AgendaApi.Collections.ViewModels.Result;

public class JwtViewModel() {
	public string JwtKey { get; set; }

	public JwtViewModel(string jwt) : this() {
		JwtKey = jwt;
	}
}