using Microsoft.AspNetCore.Mvc;

namespace OrderEats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
