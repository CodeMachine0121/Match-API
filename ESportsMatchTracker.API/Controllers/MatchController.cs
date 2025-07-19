using Microsoft.AspNetCore.Mvc;

namespace ESportsMatchTracker.API.Controllers;

[ApiController]
[Route("api/v1/{contorller}")]
public class MatchController: ControllerBase
{
    public IActionResult GetMatches()
    {
        return Ok();
    }
}