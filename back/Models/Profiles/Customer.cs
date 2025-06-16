namespace AgendaApi.Models.Profiles;

public class Customer {
	public Guid Id { get; private set; }
	public User? FromUser { get; set; }
	public Guid IdUser { get; private set; }
	public DateTime CreatedAt { get; private set; }

	public Customer() { }

	public Customer(Guid idUser) {
		Id = Guid.NewGuid();
		IdUser = idUser;
		CreatedAt = DateTime.UtcNow;
	}
}