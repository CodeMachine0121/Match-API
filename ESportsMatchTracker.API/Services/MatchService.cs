using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Repositories.Interfaces;
using ESportsMatchTracker.API.Services.Interfaces;

namespace ESportsMatchTracker.API.Services;

public class MatchService(IMatchRepository matchRepository) : IMatchService
{
    public async Task<List<MathDomain>> GetMathches()
    {
        return await matchRepository.GetAllAsync();
    }
}