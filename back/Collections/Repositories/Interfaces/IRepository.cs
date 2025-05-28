namespace AgendaApi.Collections.Repositories.Interfaces;

public interface IRepository<T> where T : class {
	Task<T> GetByIdAsync(Guid id); // Recuperar por ID
	Task<IList<T>> GetAllAsync(); // Recuperar todos os registros
	Task AddAsync(T entity); // Adicionar um novo
	void Update(T entity); // Atualizar um existente
	Task DeleteAsync(Guid id); // Deletar por ID
	void DeleteAll();
	Task SaveChangesAsync();
}