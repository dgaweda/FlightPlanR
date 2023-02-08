using FlightPlanR.Application.Common.Security.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers.Base;

[Route("api/[controller]/")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
    
}