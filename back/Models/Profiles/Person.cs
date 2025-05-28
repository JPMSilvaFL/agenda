using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Models.Profiles;

public class Person {
	public Guid Id { get; private set; }
	public bool Status { get; set; } = true;
	[Length(3,100)]
	public string FullName { get; set; } = string.Empty;
	[Length(10,100)]
	public string Email { get; set; } = string.Empty;
	[Length(11,14)]
	public string Document { get; set; } = string.Empty;
	[MaxLength(1)]
	public string Type { get; set; } = string.Empty;
	[MaxLength(13)]
	public string Phone { get; set; } = string.Empty;
	[Length(10, 100)]
	public string Address { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime? UpdatedAt { get; set; }

	public Person() { }

	public Person(string fullName, string email, string document, string phone, string address, string type) {
		Id = Guid.NewGuid();
		FullName = fullName;
		Email = email;
		Type = type;
		Document = document;
		Phone = phone;
		Address = address;
	}
}