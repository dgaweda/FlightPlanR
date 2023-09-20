using System.Collections.ObjectModel;
using MongoDB.Driver;

namespace FlightPlanR.Application.Common.Interfaces;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> FindAllAsync();
    Task<TEntity?> FindByIdAsync(string id);
    Task<string> InsertAsync(TEntity entity);
    Task<UpdateResult> UpdateAsync(string id, TEntity entity);
    Task<DeleteResult> RemoveAsync(string id);
    Task<BulkWriteResult<TEntity>> UpsertManyAsync(List<TEntity> entities);
}