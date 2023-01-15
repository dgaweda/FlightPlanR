using FlightPlanApi.Models;

namespace FlightPlanR.DataAccess.Repository;

public class FlightPlanRepository : IRepository<FlightPlan>
{
    public Task<List<FlightPlan>> GetAllAsync()
    {
        var collection = GetCollection()
    }

    public Task<FlightPlan> GetByIdAsync(string flightPlanId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(FlightPlan flightPlan)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string flightPlanId, FlightPlan flightPlan)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string flightPlanId)
    {
        throw new NotImplementedException();
    }
}