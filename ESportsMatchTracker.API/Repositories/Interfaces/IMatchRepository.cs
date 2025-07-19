using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Dtos;

namespace ESportsMatchTracker.API.Repositories.Interfaces;

public interface IMatchRepository
{
    Task<List<MatchDomain>> GetAllAsync();
    Task InsertAsync(InsertMatchDto dto);
    Task UpdateAsync(UpdateMatchDto dto);
}