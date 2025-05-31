using AgendaApi.Models.Profiles;

namespace AgendaApi.Models.Schedule;

public class Available {
	public Guid Id { get; set; }

	public Guid? IdScheduled { get; set; }
	public Scheduled? FromScheduled { get; set; }

	public Guid IdEmployee { get; set; }
	public Employee? FromEmployee { get; set; }
	public DateTime InitialTime { get; set; }
	public DateTime FinalTime { get; set; }
	public char Status { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }

	public Available() { }

	public Available(Guid idEmployee, DateTime initialTime, DateTime finalTime) {
		Id = Guid.NewGuid();
		IdEmployee = idEmployee;
		InitialTime = initialTime;
		FinalTime = finalTime;
		Status = 'A';
		CreatedAt = DateTime.UtcNow;
	}
}