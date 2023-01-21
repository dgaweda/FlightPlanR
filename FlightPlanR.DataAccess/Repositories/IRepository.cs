using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repository;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> FindAllAsync();
    Task<TEntity?> FindByIdAsync(string id);
    Task<bool> InsertAsync(TEntity entity);
    Task<UpdateResult> UpdateAsync(string id, TEntity entity);
    Task<DeleteResult> RemoveAsync(string id);
}