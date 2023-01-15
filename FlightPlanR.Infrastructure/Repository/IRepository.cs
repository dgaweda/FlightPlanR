using FlightPlanApi.Common;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repository;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(string flightPlanId);
    Task AddAsync(T flightPlan);
    Task UpdateAsync(string flightPlanId, T flightPlan);
    Task DeleteAsync(string flightPlanId);
}