using ESportsMatchTracker.API.Models.Ddmains;

namespace ESportsMatchTracker.API.Services.Interfaces;

public interface IMatchService
{
    Task<List<MatchDomain>> GetMathches();
}