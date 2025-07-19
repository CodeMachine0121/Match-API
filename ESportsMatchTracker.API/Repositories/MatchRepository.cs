using System.Text.Json;

using ESportsMatchTracker.API.Data;
using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Domains;
using ESportsMatchTracker.API.Models.Dtos;
using ESportsMatchTracker.API.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace ESportsMatchTracker.API.Repositories;

public class MatchRepository(ESportsDbContext dbContext) : IMatchRepository
{
    /// <summary>
    ///     獲取所有比賽，並將其從資料庫實體轉換為領域模型。
    /// </summary>
    /// <returns>一個領域模型的集合。</returns>
    public async Task<List<MatchDomain>> GetAllAsync()
    {
        var domains = await dbContext.Matches
            .Select(entity => entity.ToMatchDomain())
            .ToListAsync();
        return domains;
    }
    public Task InsertAsync(InsertMatchDto dto)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync(UpdateMatchDto dto)
    {
        throw new NotImplementedException();
    }
}
