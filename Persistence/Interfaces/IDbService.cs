
namespace Persistence.Interfaces;

public interface IDbService
{
	// Add
	public Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
		where TEntity : class
		where TDto : class;

	// Get all
	public Task<List<TDto>> GetAsync<TEntity, TDto>()
			where TEntity : class, IEntity
			where TDto : class;

	// Get with expression
	public Task<List<TDto>> GetAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
			where TEntity : class, IEntity
			where TDto : class;

	// Get one - MODIFY IF NEEDED - SingleOrDefaultAsync throws exception if not found, FirstOrDefaultAsync returns null
	public Task<TDto> FirstOrDefault<TEntity, TDto>(int id)
			where TEntity : class, IEntity
			where TDto : class;

	// Update
	public Task<bool> Update<TEntity, TDto>(int id, TDto dto)
			where TEntity : class, IEntity
			where TDto : class;

	// Delete
	public Task<bool> DeleteAsync<TEntity>(int id)
			where TEntity : class, IEntity;

	// Check if item exists
	public Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> exception)
		where TEntity : class, IEntity;

	public Task<bool> SaveChangesAsync();

	public string GetURIString<TEntity>(TEntity entity)
	where TEntity : class, IEntity
	{
		var node = typeof(TEntity).Name.ToLower(); // Entity name in lowercase (e.g., "vehicle")
		return $"/api/{node}s/{entity.Id}"; // Example: /api/vehicles/1
	}


	// MAY NOT BE NEEDED
	public void Include<TEntity>() where TEntity : class;
}
