namespace AgendaApi.Collections.ViewModels.Schedule;

public class QueryPurposeViewModel {
	public List<QueryPurposeViewModelAux> list { get; set; } = new();

	public QueryPurposeViewModel(IEnumerable<QueryPurposeViewModelAux> model) {
		list.AddRange(model);
	}
}

public class QueryPurposeViewModelAux {
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public float Value { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
	public string Role { get; set; } = null!;

	public QueryPurposeViewModelAux() { }

	public QueryPurposeViewModelAux(string name, string description,
		float value, DateTime createdAt, DateTime? updatedAt, string role) {
		Name = name;
		Description = description;
		Value = value;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		Role = role;
	}
}