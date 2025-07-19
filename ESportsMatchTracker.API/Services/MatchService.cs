using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Dtos;
using ESportsMatchTracker.API.Repositories.Interfaces;
using ESportsMatchTracker.API.Services.Interfaces;

namespace ESportsMatchTracker.API.Services;

public class MatchService(IUnitOfWork unitOfWork) : IMatchService
{
    public async Task<List<MatchDomain>> GetMathches()
    {
        return await unitOfWork.MatchRepository().GetAllAsync();
    }
    public async Task InsertAsync(InsertMatchDto dto)
    {
        await unitOfWork.MatchRepository().InsertAsync(dto);
    }
    public async Task UpdateAsync(UpdateMatchDto dto)
    {
        await unitOfWork.MatchRepository().UpdateAsync(dto);
    }
    public async Task DeleteAsync(int id)
    {
        await unitOfWork.MatchRepository().DeleteAsync(id);
    }
}