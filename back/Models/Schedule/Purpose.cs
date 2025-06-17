using AgendaApi.Models.Profiles;

namespace AgendaApi.Models.Schedule;

public class Purpose {
	public Guid Id { get; set; }
	public Guid IdRole { get; set; }
	public Role? FromRole { get; set; }
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public float Value { get; set; }
	public int DurationInMinutes { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }

	public Purpose() { }

	public Purpose(Guid idRole, string name, string description, float value,
		int durationInMinutes) {
		Id = Guid.NewGuid();
		IdRole = idRole;
		Name = name;
		Description = description;
		Value = value;
		DurationInMinutes = durationInMinutes;
		CreatedAt = DateTime.UtcNow;
	}
}