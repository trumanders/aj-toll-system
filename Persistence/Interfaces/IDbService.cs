
namespace Persistence.Interfaces;

public interface IDbService
{
	// Add	
	public Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
		where TEntity : class, IEntity
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
	public Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
			where TEntity : class, IEntity
			where TDto : class;

	// Update
	public bool Update<TEntity, TDto>(int id, TDto dto)
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
	where TEntity : class, IEntity;
}
