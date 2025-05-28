namespace AgendaApi.Models.Profiles;

public class User {
	public Guid Id { get; private set; }
	public string Username { get; private set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	public Person? FromPerson { get; private set; }
	public Guid IdPerson { get; private set; }
	public Guid IdAccess { get; private set; }
	public Access? FromAccess { get; private set; }
	public DateTime CreatedAt { get; private set; }

	public User() { }

	public User(string username, string passwordHash, Person person, Guid idAccess) {
		Id = Guid.NewGuid();
		Username=username;
		PasswordHash=passwordHash;
		FromPerson = person;
		IdPerson = person.Id;
		IdAccess = idAccess;
		CreatedAt = DateTime.UtcNow;
	}


}