using ESportsMatchTracker.API.Models.ViewModels;
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
        
        return Ok(mathches.Select(x=> new MathResponse
        {
            Id = x.Id,
            Game = x.Game,
            Teams = x.Teams,
            Status = x.Status,
            Stage = x.Stage,
            Tournament = x.Tournament,
            StreamUrl = x.StreamUrl,
            MatchDetails = new MatchDetailsResponse()
            {
                Format = x.MatchDetailsDomain.Format,
                MapPool = x.MatchDetailsDomain.MapPool
            }
        }).ToList());
    }
}