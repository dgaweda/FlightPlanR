using FlightPlanR.Application.Common.Exceptions;
using FlightPlanR.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlightPlanR.Application.Common.Security.Attribute;

public class AuthorizeAttribute : System.Attribute, IAuthorizationFilter
{
	public void OnAuthorization(AuthorizationFilterContext context)
	{
		var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
		if (allowAnonymous)
			return;

		var user = (User)context.HttpContext.Items["User"];
		if (user is null)
			throw new IdentityException();
	}
}