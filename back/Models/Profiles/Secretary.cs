namespace AgendaApi.Models.Profiles;

public class Secretary {
	public Guid Id { get; set; }
	public Guid IdEmployee { get; set; }
	public Person? FromEmployee { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }

	public Secretary() { }

	public Secretary(Guid idEmployee) {
		Id= Guid.NewGuid();
		IdEmployee = idEmployee;
		CreatedAt = DateTime.UtcNow;
	}
}