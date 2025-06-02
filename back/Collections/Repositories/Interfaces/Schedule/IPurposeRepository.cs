using AgendaApi.Models.Schedule;

namespace AgendaApi.Collections.Repositories.Interfaces.Schedule;

public interface IPurposeRepository : IRepository<Purpose> {
	Task<List<Purpose>> GetPurpose(string? role, string? name, int skip, int take);
}