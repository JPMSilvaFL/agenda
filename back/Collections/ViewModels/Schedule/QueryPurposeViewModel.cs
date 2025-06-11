namespace AgendaApi.Collections.ViewModels.Schedule;

public class QueryPurposeViewModel {
	public List<QueryPurposeViewModelAux> list { get; set; } = new();

	public QueryPurposeViewModel(IEnumerable<QueryPurposeViewModelAux> model) {
		list.AddRange(model);
	}
}

public class QueryPurposeViewModelAux {
	public string Name { get; set; }
	public string Description { get; set; }
	public float Value { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
	public string Role { get; set; }

	public QueryPurposeViewModelAux() { }

	public QueryPurposeViewModelAux(string Name, string Description,
		float Value, DateTime CreatedAt, DateTime? UpdatedAt, string Role) {
		this.Name = Name;
		this.Description = Description;
		this.Value = Value;
		this.CreatedAt = CreatedAt;
		this.UpdatedAt = UpdatedAt;
		this.Role = Role;
	}
}