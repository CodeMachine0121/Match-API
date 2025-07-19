using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Repositories.Interfaces;

namespace ESportsMatchTracker.API.Repositories;

public class MatchRepository() : IMatchRepository
{
    public async Task<List<MathDomain>> GetAllAsync()
    {
        return [];
    }
}