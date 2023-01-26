using FlightPlanApi.Common.Configuration;
using FlightPlanR.DataAccess.Entity.Dictionary.Countries;
using FlightPlanR.DataAccess.Repositories.CountryRepository;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repositories.DictionaryRepository;

public class DictionaryRepository<TEntity> : Repository<TEntity>, IDictionaryRepository<TEntity> where TEntity : BaseCountry
{
	private static readonly string _collectionName = "countries";
	
	public DictionaryRepository(IOptions<MongoConfiguration> configuration) 
		: base(configuration, _collectionName)
	{
	}

	public async Task<List<TResult>> GetCountriesByKey<TResult>(string key)
	{
		var documents = await GetCollection(_collectionName).Find(Builders<BsonDocument>.Filter.Eq("Key", key)).ToListAsync();

		if (documents is null) return new List<TResult>();

		var countries = new List<TResult>();
		countries.AddRange(documents.Select(document => BsonSerializer.Deserialize<TResult>(document)));

		return countries;
	}
}