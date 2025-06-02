using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Data;
using AgendaApi.Models.Schedule;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Collections.Repositories.Schedule;

public class PurposeRepository : Repository<Purpose>, IPurposeRepository{
	private readonly AgendaDbContext _context;
	public PurposeRepository(AgendaDbContext context) : base(context) {
		_context = context;
	}

	public async Task<List<Purpose>> GetPurpose(string? role, string? name, int skip, int take) {
		var result = _context.Purposes.AsQueryable();


		return await result
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}
}