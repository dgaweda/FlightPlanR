using FlightPlanR.DataAccess.Entity.Dictionary.Countries;

namespace FlightPlanR.DataAccess.Repositories.CountryRepository;

public interface IDictionaryRepository<TEntity> : IRepository<TEntity> where TEntity : BaseCountry
{
	Task<List<TResult>> GetCountriesByKey<TResult>(string key);
}