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
        dbContext.Matches.Add(dto.ToEntity());
        // 移除 SaveChangesAsync，让 UnitOfWork 统一提交
        return Task.CompletedTask;
    }
    public Task UpdateAsync(UpdateMatchDto dto)
    {
        var entity = dbContext.Matches.FirstOrDefault(m => m.Id == dto.Id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Match with ID {dto.Id} not found.");
        }
        entity.UpdateFromDto(dto);
        dbContext.Update(entity);
        // 移除 SaveChangesAsync，让 UnitOfWork 统一提交
        return Task.CompletedTask;
    }
    public Task DeleteAsync(int id)
    {
        var entity = dbContext.Matches.FirstOrDefault(m => m.Id == id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Match with ID {id} not found.");
        }
        dbContext.Matches.Remove(entity);
        // 移除 SaveChangesAsync，让 UnitOfWork 统一提交
        return Task.CompletedTask;
    }
}
