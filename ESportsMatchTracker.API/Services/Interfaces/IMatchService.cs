using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Dtos;

namespace ESportsMatchTracker.API.Services.Interfaces;

public interface IMatchService
{
    Task<List<MatchDomain>> GetMathches();
    Task InsertAsync(InsertMatchDto dto);
    Task UpdateAsync(UpdateMatchDto dto);
    Task DeleteAsync(int id);
}