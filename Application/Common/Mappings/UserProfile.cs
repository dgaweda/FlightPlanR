using AutoMapper;
using FlightPlanR.Application.Common.Extensions;
using FlightPlanR.Application.Services.User.Request;
using FlightPlanR.Domain.Entities;

namespace FlightPlanR.Application.Common.Mappings;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<UpdateUserRequest, User>()
			.IgnoreDestinationMember(src => src.Id);
	}
}