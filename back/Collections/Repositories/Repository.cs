using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Collections.Repositories;

public class Repository<T> : IRepository<T> where T : class {
	private readonly AgendaDbContext _context;
	private readonly DbSet<T> _dbSet;

	public Repository(AgendaDbContext context) {
		_context = context;
		_dbSet = context.Set<T>();
	}

	public async Task<T> GetByIdAsync(Guid id) {
		return (await _dbSet.FindAsync(id))!;
	}

	public async Task<IList<T>> GetAllAsync() {
		return await _dbSet
			.AsNoTracking()
			.ToListAsync();
	}

	public async Task AddAsync(T entity) {
		await _dbSet.AddAsync(entity);
	}

	public void Update(T entity) {
		_dbSet.Update(entity);
	}

	public async Task DeleteAsync(Guid id) {
		var entity = await _dbSet.FindAsync(id);
		if (entity != null) _dbSet.Remove(entity);
	}

	public void DeleteAll() {
		_dbSet.RemoveRange(_dbSet);
	}

	public async Task SaveChangesAsync() {
		await _context.SaveChangesAsync();
	}
}