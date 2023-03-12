using AutoMapper;
using FlightPlanR.Application.Common.Extensions;
using FlightPlanR.Application.Services.FlightPlan.Requests;
using FlightPlanR.Domain.Entities;

namespace FlightPlanR.Application.Common.Mappings;

public class FlightPlanProfile : Profile
{
	public FlightPlanProfile()
	{
		CreateMap<AddFlightPlanRequest, FlightPlan>()
			.IgnoreDestinationMember(src => src.Id);
		CreateMap<UpdateFlightPlanRequest, FlightPlan>()
			.IgnoreDestinationMember(src => src.Id);
	}
}