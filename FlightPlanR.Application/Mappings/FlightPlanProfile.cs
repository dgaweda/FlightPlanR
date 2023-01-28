using AutoMapper;
using FlightPlanR.Application.Services.FlightPlan.Requests;
using FlightPlanR.DataAccess.Entity;

namespace FlightPlanR.Application.Mappings;

public class FlightPlanProfile : Profile
{
	public FlightPlanProfile()
	{
		CreateMap<AddFlightPlanRequest, FlightPlan>()
			.ForMember(src => src.Id, opt => opt.Ignore());
		CreateMap<UpdateFlightPlanRequest, FlightPlan>()
			.ForMember(src => src.Id, opt => opt.Ignore());
	}
}