using AutoMapper;
using FlightPlanR.Application.Services.User.Request;
using FlightPlanR.DataAccess.Entity;

namespace FlightPlanR.Application.Mappings;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<AddUserRequest, User>()
			.ForMember(src => src.Id, opt => opt.Ignore());
		CreateMap<UpdateUserRequest, User>()
			.ForMember(src => src.Id, opt => opt.Ignore());
	}
}