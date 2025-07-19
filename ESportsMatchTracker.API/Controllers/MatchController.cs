using ESportsMatchTracker.API.Models.Dtos;
using ESportsMatchTracker.API.Models.ViewModels;
using ESportsMatchTracker.API.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace ESportsMatchTracker.API.Controllers;

[ApiController]
[Route("api/v1/{contorller}")]
public class MatchController(IMatchService matchService) : ControllerBase
{
    [HttpGet("all")]
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
            MatchDetails = x.MatchDetails.ToResponse(),
        }).ToList());
    }
    public async Task<IActionResult> InsertAsync(InsertMatchRequest request)
    {
        await matchService.InsertAsync(request.ToDto());
        return Created();
    }
}