using AgendaApi.Collections.Enum;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Models.Utilities;

public class LogActivity {
	public int Id { get; set; }
	public Guid User { get; set; }
	public User? FromUser { get; set; }
	public ELogType Type { get; set; }
	public EAction Action { get; set; }
	public ELogCode Code { get; set; }
	public Guid? ObjectId { get; set; }
	public string Description { get; set; }
	public DateTime CreatedAt { get; set; }

	public LogActivity() { }

	public LogActivity(Guid user, ELogType type, EAction action, ELogCode code,
		Guid objectId, string description) {
		Type = type;
		User = user;
		Action = action;
		Code = code;
		ObjectId = objectId;
		Description = description;
		CreatedAt = DateTime.UtcNow;
	}
}