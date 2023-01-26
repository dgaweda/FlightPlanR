using FlightPlanApi.Common.Exceptions;
using FlightPlanR.DataAccess.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Security.Attribute;

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