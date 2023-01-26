using FlightPlanApi.Controllers.Base;
using FlightPlanR.Application.Services.Dictionary;
using FlightPlanR.Application.Services.Dictionary.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers;

public class DictionaryController : BaseController
{
	private readonly IDictionaryService _dictionaryService;
	public DictionaryController(IDictionaryService dictionaryService)
	{
		_dictionaryService = dictionaryService;
	}

	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> GetCountries()
	{
		var result = await _dictionaryService.GetCountries();
		return Ok(result);
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> AddDictionary(AddCountryDictionaryRequest request)
	{
		await _dictionaryService.AddCountryDictionary(request);
		return Ok();
	}
}