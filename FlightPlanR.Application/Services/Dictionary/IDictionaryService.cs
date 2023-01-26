using FlightPlanR.Application.Services.Dictionary.Request;
using FlightPlanR.DataAccess.Entity.Dictionary.Countries;

namespace FlightPlanR.Application.Services.Dictionary;

public interface IDictionaryService
{
	Task<List<CountryA2>> GetCountriesA2();
	Task<List<CountryA3>> GetCountriesA3();
	Task<List<CountryEN>> GetCountriesEN();
	Task<List<CountrySE>> GetCountriesSE();
	Task<List<DictionaryDto>> GetCountries();

	Task AddCountryDictionary(AddCountryDictionaryRequest request);
}