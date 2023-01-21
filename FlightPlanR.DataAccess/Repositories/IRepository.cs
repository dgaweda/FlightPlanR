using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repositories;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> FindAllAsync();
    Task<TEntity?> FindByIdAsync(string id);
    Task<bool> InsertAsync<TRequest>(TRequest entity);
    Task<UpdateResult> UpdateAsync<TRequest>(string id, TRequest entity);
    Task<DeleteResult> RemoveAsync(string id);
}