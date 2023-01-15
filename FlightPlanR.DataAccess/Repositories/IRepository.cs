using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repository;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> FindAllAsync();
    Task<TEntity?> FindByIdAsync(string flightPlanId);
    Task<bool> InsertAsync(TEntity flightPlan);
    Task<UpdateResult> UpdateAsync(TEntity flightPlan);
    Task<DeleteResult> RemoveAsync(string flightPlanId);
}