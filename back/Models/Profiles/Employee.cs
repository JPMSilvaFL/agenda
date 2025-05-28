namespace AgendaApi.Models.Profiles;

public class Employee {
	public Guid Id { get; private set; }
	public Guid IdRole { get; private set; }
	public Role? FromRole { get; private set; }
	public Guid IdPerson { get; private set; }
	public Person? FromPerson { get; set; }
	public DateTime CreatedAt { get; private set; }

	public Employee() { }

	public Employee(Guid idRole, Guid idPerson) {
		Id = Guid.NewGuid();
		IdRole = idRole;
		IdPerson = idPerson;
		CreatedAt = DateTime.UtcNow;
	}
}