namespace AgendaApi.Models.Profiles;

public class Secretary {
	public Guid Id { get; set; }
	public Guid IdPerson { get; set; }
	public Person? FromPerson { get; set; }
	public DateTime CreatedAt { get; set; }

	public Secretary() { }

	public Secretary(Guid idPerson) {
		Id= Guid.NewGuid();
		IdPerson = idPerson;
		CreatedAt = DateTime.UtcNow;
	}
}