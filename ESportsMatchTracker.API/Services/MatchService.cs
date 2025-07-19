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
    public async Task InsertAsync(InsertMatchDto dto)
    {
        await matchRepository.InsertAsync(dto);
    }
    public async Task UpdateAsync(UpdateMatchDto dto)
    {
        await matchRepository.UpdateAsync(dto);
    }
}