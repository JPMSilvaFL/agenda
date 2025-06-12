namespace AgendaApi.Models.Profiles;

public class Employee {
	public Guid Id { get; set; }
	public Guid IdRole { get; set; }
	public Role? FromRole { get; set; }
	public Guid IdPerson { get; set; }
	public Person? FromPerson { get; set; }
	public DateTime CreatedAt { get; set; }

	public Employee() { }

	public Employee(Guid idRole, Guid idPerson) {
		Id = Guid.NewGuid();
		IdRole = idRole;
		IdPerson = idPerson;
		CreatedAt = DateTime.UtcNow;
	}
}