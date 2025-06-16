namespace AgendaApi.Models.Profiles;

public class Access {
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;

	public Access() { }

	public Access(string name) {
		Id = Guid.NewGuid();
		Name = name;
	}

	public Access(Guid id, string name, DateTime createdAt) {
		Id = id;
		Name = name;
		CreatedAt = createdAt;
	}
}