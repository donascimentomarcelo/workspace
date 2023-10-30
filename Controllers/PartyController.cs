using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartyController : ControllerBase
{
    public PartyController()
    {

    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok("");
    }

}
