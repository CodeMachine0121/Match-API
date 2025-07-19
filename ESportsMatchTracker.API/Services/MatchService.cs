using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Dtos;
using ESportsMatchTracker.API.Repositories.Interfaces;
using ESportsMatchTracker.API.Services.Interfaces;

namespace ESportsMatchTracker.API.Services;

public class MatchService(IUnitOfWork unitOfWork) : IMatchService
{
    public async Task<List<MatchDomain>> GetMathches()
    {
        var matchDomains = await unitOfWork.MatchRepository().GetAllAsync();
        await unitOfWork.SaveChangesAsync();
        return matchDomains;
    }
    public async Task InsertAsync(InsertMatchDto dto)
    {
        await unitOfWork.MatchRepository().InsertAsync(dto);
        await unitOfWork.SaveChangesAsync();
    }
    public async Task UpdateAsync(UpdateMatchDto dto)
    {
        await unitOfWork.MatchRepository().UpdateAsync(dto);
        await unitOfWork.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        await unitOfWork.MatchRepository().DeleteAsync(id);
        await unitOfWork.SaveChangesAsync();
    }
}