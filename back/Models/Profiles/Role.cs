namespace AgendaApi.Models.Profiles;

public class Role {
	public Guid Id { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public DateTime CreatedAt { get; private set; }

	public Role() { }

	public Role(string name, string description) {
		Id = Guid.NewGuid();
		Name = name;
		Description = description;
		CreatedAt = DateTime.UtcNow;
	}
}