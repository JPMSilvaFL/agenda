using AgendaApi.Models.Profiles;

namespace AgendaApi.Models.Schedule;

public class Purpose {
	public Guid Id { get; set; }
	public Guid IdRole { get; set; }
	public Role? FromRole { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public float Value { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }

	public Purpose() { }

	public Purpose(Guid idRole, string name, string description, float value) {
		Id = Guid.NewGuid();
		IdRole = idRole;
		Name = name;
		Description = description;
		Value = value;
		CreatedAt = DateTime.UtcNow;
	}
}