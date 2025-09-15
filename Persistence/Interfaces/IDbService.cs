using Business.Interfaces;

namespace Persistence.Interfaces;

public interface IDbService
{
	public Task<List<TBusinessModel>> AddAsync<TEntity, TBusinessModel>(List<TBusinessModel> models)
		where TEntity : class, IEntity
		where TBusinessModel : class, IBusinessModel;

	public Task<List<TBusinessModel>> GetAsync<TEntity, TBusinessModel>()
		where TEntity : class, IEntity
		where TBusinessModel : class, IBusinessModel;

	public Task<List<TBusinessModel>> GetAsync<TEntity, TBusinessModel>(Expression<Func<TEntity, bool>> expression)
		where TEntity : class, IEntity
		where TBusinessModel : class, IBusinessModel;

	Task<bool> Update<TEntity, TBusinessModel>(Expression<Func<TEntity, bool>> expression, List<TBusinessModel> dtos)
		where TEntity : class, IEntity
		where TBusinessModel : class, IBusinessModel;

	public Task<bool> SaveChangesAsync();

	public Task<List<TBusinessModel>> GetWithExpressionAndIncludesAsync<TEntity, TBusinessModel>(
		Expression<Func<TEntity, bool>> filter,
		params Expression<Func<TEntity, object>>[] includes
	)
		where TEntity : class, IEntity
		where TBusinessModel : class, IBusinessModel;
}
