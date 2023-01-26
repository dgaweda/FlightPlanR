using FlightPlanApi.Common.Extensions;
using FlightPlanR.Application.Services.Dictionary.Request;
using FlightPlanR.DataAccess.Entity.Dictionary.Countries;
using FlightPlanR.DataAccess.Repositories.CountryRepository;

namespace FlightPlanR.Application.Services.Dictionary;

public class DictionaryService : IDictionaryService
{
	private readonly IDictionaryRepository<BaseCountry> _dictionaryRepository;

	public DictionaryService(IDictionaryRepository<BaseCountry> dictionaryRepository)
	{
		_dictionaryRepository = dictionaryRepository;
	}

	public async Task<List<CountryA2>> GetCountriesA2()
	{
		return await _dictionaryRepository.GetCountriesByKey<CountryA2>("CountryA2");
	}
	
	public async Task<List<CountryA3>> GetCountriesA3()
	{
		return await _dictionaryRepository.GetCountriesByKey<CountryA3>("CountryA3");
	}

	public async Task<List<CountryEN>> GetCountriesEN()
	{
		return await _dictionaryRepository.GetCountriesByKey<CountryEN>("CountryEN");
	}
	
	public async Task<List<CountrySE>> GetCountriesSE()
	{
		return await _dictionaryRepository.GetCountriesByKey<CountrySE>("CountrySE");
	}

	public async Task<List<DictionaryDto>> GetCountries()
	{
		var result = await _dictionaryRepository.FindAllAsync().ThrowIfOperationFailed();

		return result.GroupBy(x => x.Discriminator)
			.Select(x => new DictionaryDto(
				x.Key,
				x.Select(data => new CountryDto(data.CountryId, data.Value)).ToList())
			)
			.ToList();
	}

	public async Task AddCountryDictionary(AddCountryDictionaryRequest request)
	{
		await _dictionaryRepository.InsertAsync(request).ThrowIfOperationFailed();
	}
}