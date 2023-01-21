using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers.Base;

[Route("api/v1/[controller]/")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
    
}