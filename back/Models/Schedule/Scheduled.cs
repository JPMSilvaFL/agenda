using AgendaApi.Models.Profiles;

namespace AgendaApi.Models.Schedule;

public class Scheduled {
	public Guid Id { get; set; }
	public Guid IdAvailable { get; set; }
	public Available? FromAvailable { get; set; }
	public Guid IdCustomer { get; set; }
	public Customer? FromCustomer { get; set; }
	public Guid IdSecretary { get; set; }
	public Secretary? FromSecretary { get; set; }
	public Guid IdPurpose { get; set; }
	public Purpose? FromPurpose { get; set; }
	public bool Status { get; set; }
	public DateTime CreatedAt { get; set; }

	public Scheduled() { }

	public Scheduled(Guid idAvailable, Guid idCustomer, Guid idSecretary, Guid idPurpose) {
		Id = Guid.NewGuid();
		IdAvailable = idAvailable;
		IdCustomer = idCustomer;
		Status = false;
		IdSecretary = idSecretary;
		IdPurpose = idPurpose;
		CreatedAt = DateTime.UtcNow;
	}
}