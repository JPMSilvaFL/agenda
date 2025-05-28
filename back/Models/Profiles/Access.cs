namespace AgendaApi.Models.Profiles;

public class Access {
	public Guid Id { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public DateTime CreatedAt { get; set; }

	public Access() { }

	public Access(string name) {
		Id = Guid.NewGuid();
		Name = name;
		CreatedAt = DateTime.UtcNow;
	}

	public Access(Guid id, string name, DateTime createdAt) {
		Id = id;
		Name = name;
		CreatedAt = createdAt;
	}
}