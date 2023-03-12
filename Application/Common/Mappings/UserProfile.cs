using AutoMapper;
using FlightPlanR.Application.Services.User.Request;
using FlightPlanR.Domain.Entities;

namespace FlightPlanR.Application.Common.Mappings;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<UpdateUserRequest, User>()
			.ForMember(src => src.Id, opt => opt.Ignore());
	}
}