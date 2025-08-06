
using AutoMapper;
using Common.DTO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Persistence.Services;

public class DbService : IDbService
{
	private readonly Context _db;
	private readonly IMapper _mapper;
	public DbService(Context db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}

	// Add
	public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
		where TEntity : class, IEntity
		where TDto : class
	{
		// DTO -> Entity
		var entity = _mapper.Map<TEntity>(dto);

		await _db.Set<TEntity>().AddAsync(entity);
		return entity;
	}

	// Add
	public async Task<List<TEntity>> AddAsync<TEntity, TDto>(List<TDto> dtos)
		where TEntity : class, IEntity
		where TDto : class
	{
		var entities = _mapper.Map<List<TEntity>>(dtos);

		await _db.Set<TEntity>().AddRangeAsync(entities);
		return entities;
	}

	// Get all
	public async Task<List<TDto>> GetAsync<TEntity, TDto>()
		where TEntity : class, IEntity
		where TDto : class
	{
		IQueryable<TEntity> query = _db.Set<TEntity>();

		if (typeof(TEntity) == typeof(SimulatedVehicleApiData)
			&& typeof(TDto) == typeof(SimulatedVehicleApiDataDTO))
		{
			// Eagerly include VehicleType
			query = (IQueryable<TEntity>)((IQueryable<SimulatedVehicleApiData>)query)
				.Include(x => x.VehicleType);
		}

		var entities = await query.ToListAsync();
		return _mapper.Map<List<TDto>>(entities);
	}

	//public async Task<List<TDto>> GetWithIncludesAsync<TEntity, TDto>(params Expression<Func<TEntity, object>>[] includes)
	//	where TEntity : class, IEntity
	//	where TDto : class
	//{
	//	IQueryable<TEntity> query = _db.Set<TEntity>();

	//	foreach (var include in includes)
	//	{
	//		query = query.Include(include);
	//	}

	//	var entities = await query.ToListAsync();

	//	return _mapper.Map<List<TDto>>(entities);
	//}

	// Get with expression
	public async Task<List<TDto>> GetAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
		where TEntity : class, IEntity
		where TDto : class
	{
		var entities = await _db.Set<TEntity>().Where(expression).ToListAsync();
		return _mapper.Map<List<TDto>>(entities);
	}

	public async Task<List<TDto>> GetWithExpressionAndIncludesAsync<TEntity, TDto>(
		Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
			where TEntity : class, IEntity
			where TDto : class
	{
		IQueryable<TEntity> query = _db.Set<TEntity>();

		if (filter != null)
		{
			query = query.Where(filter);
		}

		foreach (var include in includes)
		{
			query = query.Include(include);
		}

		var entities = await query.ToListAsync();
		return _mapper.Map<List<TDto>>(entities);
	}


	//public async Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
	//	where TEntity : class, IEntity
	//	where TDto : class
	//{
	//	var entity = await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
	//	if (entity is null)
	//	{
	//		throw new Exception("Entity not found");
	//	}
	//	return _mapper.Map<TDto>(entity);
	//}

	// Update
	//public bool Update<TEntity, TDto>(int id, TDto dto)
	//	where TEntity : class, IEntity
	//	where TDto : class
	//{
	//	var entity = _mapper.Map<TEntity>(dto);

	//	if (id != entity.Id)
	//	{
	//		return false;
	//	}
	//	_db.Set<TEntity>().Update(entity);

	//	return true;
	//}

	//public bool Update<TEntity, TDto>(List<TDto> dtos)
	//	where TEntity : class, IEntity
	//	where TDto : class
	//{
	//	var entities = _mapper.Map<List<TEntity>>(dtos);

	//	_db.Set<TEntity>().UpdateRange(entities);

	//	return true;
	//}

	public async Task<bool> Update<TEntity, TDto>(Expression<Func<TEntity, bool>> expression, List<TDto> dtos)
	where TEntity : class, IEntity
	where TDto : class
	{
		var entities = await _db.Set<TEntity>().Where(expression).ToListAsync();

		if (entities.Count != dtos.Count) return false;
		if (entities.Any(e => e is null)) return false;

		for (int i = 0; i < entities.Count; i++)
		{
			_mapper.Map(dtos[i], entities[i]);
		}

		_db.Set<TEntity>().UpdateRange(entities);

		return true;
	}

	// Delete
	//public async Task<bool> DeleteAsync<TEntity>(int id)
	//	where TEntity : class, IEntity
	//{
	//	var entity = await SingleAsync<TEntity>(e => e.Id.Equals(id));
	//	if (entity is null)
	//	{
	//		return false;
	//	}
	//	_db.Remove(entity);
	//	return true;
	//}

	// Check if at least one item is found
	//public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> exception)
	//	where TEntity : class, IEntity
	//{
	//	return await _db.Set<TEntity>().AnyAsync(exception);
	//}

	public async Task<bool> SaveChangesAsync()
	{
		return await _db.SaveChangesAsync() >= 0;
	}

	//public string GetURIString<TEntity>(TEntity entity)
	//	where TEntity : class, IEntity
	//{
	//	throw new NotImplementedException();
	//}

	//private async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
	//	where TEntity : class, IEntity
	//{
	//	var entity = await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
	//	if (entity is null)
	//	{
	//		throw new Exception("Entity not found");
	//	}
	//	return entity;
	//}
}
