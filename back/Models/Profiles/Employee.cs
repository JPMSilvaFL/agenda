namespace AgendaApi.Models.Profiles;

public class Employee {
	public Guid Id { get; set; }
	public Guid IdRole { get; set; }
	public Role? FromRole { get; set; }
	public Guid IdUser { get; set; }
	public User? FromUser { get; set; }
	public DateTime CreatedAt { get; set; }

	public Employee() { }

	public Employee(Guid idRole, Guid idUser) {
		Id = Guid.NewGuid();
		IdRole = idRole;
		IdUser = idUser;
		CreatedAt = DateTime.UtcNow;
	}
}