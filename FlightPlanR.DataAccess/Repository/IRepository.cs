namespace FlightPlanR.DataAccess.Repository;

public interface IRepository<T>
{
    Task<List<T>> FindAllAsync();
    Task<T> FindByIdAsync(string flightPlanId);
    Task InsertAsync(T flightPlan);
    Task UpdateAsync(string flightPlanId, T flightPlan);
    Task RemoveAsync(string flightPlanId);
}