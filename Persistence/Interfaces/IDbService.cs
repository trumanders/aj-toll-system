namespace Persistence.Interfaces;

public interface IDbService
{
	public Task<List<TEntity>> AddAsync<TEntity, TDto>(List<TDto> dtos)
		where TEntity : class, IEntity
		where TDto : class;

	public Task<List<TDto>> GetAsync<TEntity, TDto>()
			where TEntity : class, IEntity
			where TDto : class;

	public Task<List<TDto>> GetAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
			where TEntity : class, IEntity
			where TDto : class;

	Task<bool> Update<TEntity, TDto>(Expression<Func<TEntity, bool>> expression, List<TDto> dtos)
	where TEntity : class, IEntity
	where TDto : class;

	public Task<bool> SaveChangesAsync();

	public Task<List<TDto>> GetWithExpressionAndIncludesAsync<TEntity, TDto>(
		Expression<Func<TEntity, bool>> filter,
		params Expression<Func<TEntity, object>>[] includes)
			where TEntity : class, IEntity
			where TDto : class;
}
