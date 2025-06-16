namespace AgendaApi.Models.Profiles;

public class User {
	public Guid Id { get; set; }
	public string Username { get; set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	public Person? FromPerson { get; set; }
	public Guid IdPerson { get; set; }
	public Guid IdAccess { get; set; }
	public Access? FromAccess { get; set; }
	public DateTime CreatedAt { get;  set; } =  DateTime.UtcNow;

	public User() { }

	public User(string username, string passwordHash, Guid idPerson,
		Guid idAccess) {
		Id = Guid.NewGuid();
		Username = username;
		PasswordHash = passwordHash;
		IdPerson = idPerson;
		IdAccess = idAccess;
		CreatedAt = DateTime.UtcNow;
	}
}