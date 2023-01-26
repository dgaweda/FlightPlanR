using Microsoft.AspNetCore.Mvc;
using Security.Attribute;

namespace FlightPlanApi.Controllers.Base;

[Route("api/[controller]/")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
    
}