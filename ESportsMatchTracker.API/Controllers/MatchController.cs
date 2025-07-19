using ESportsMatchTracker.API.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace ESportsMatchTracker.API.Controllers;

[ApiController]
[Route("api/v1/{contorller}")]
public class MatchController(IMatchService matchService) : ControllerBase
{
    public async Task<IActionResult> GetMatches()
    {
        var mathches = await matchService.GetMathches();
        return Ok(new List<Models.ViewModels.MathResponse>());
    }
}