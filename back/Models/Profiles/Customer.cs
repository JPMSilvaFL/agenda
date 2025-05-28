namespace AgendaApi.Models.Profiles;

public class Customer {
	public Guid Id { get; private set; }
	public Person? FromPerson { get; set; }
	public Guid IdPerson { get; private set; }
	public DateTime CreatedAt { get; private set; }

	public Customer() { }

	public Customer(Guid idPerson) {
		Id = Guid.NewGuid();
		IdPerson = idPerson;
		CreatedAt = DateTime.UtcNow;
	}
}