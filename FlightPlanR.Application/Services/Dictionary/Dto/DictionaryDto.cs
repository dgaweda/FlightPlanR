using FlightPlanR.DataAccess.Entity.Dictionary.Countries;

namespace FlightPlanR.Application.Services.Dictionary;

public record DictionaryDto(string CountryFormat, List<CountryDto> Countries);
