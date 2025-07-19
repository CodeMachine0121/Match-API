using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Dtos;
using ESportsMatchTracker.API.Repositories.Interfaces;
using ESportsMatchTracker.API.Services.Interfaces;

namespace ESportsMatchTracker.API.Services;

public class MatchService(IMatchRepository matchRepository) : IMatchService
{
    public async Task<List<MatchDomain>> GetMathches()
    {
        return await matchRepository.GetAllAsync();
    }
    public Task InsertAsync(InsertMatchDto dto)
    {
        throw new NotImplementedException();
    }
}