using System.Text.Json;

using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Dtos;
using ESportsMatchTracker.API.Repositories.Interfaces;

using Microsoft.Extensions.Caching.Memory;

namespace ESportsMatchTracker.API.Repositories.Caches;

public class MatchRepositoryCache(IMemoryCache memoryCache, IMatchRepository repository) : IMatchRepository
{
    private const string CacheKeyForMatchAll = "match-all";

    public async Task<List<MatchDomain>> GetAllAsync()
    {
        if (memoryCache.TryGetValue(CacheKeyForMatchAll, out string? matchesString) && matchesString != null)
        {
            return JsonSerializer.Deserialize<List<MatchDomain>>(matchesString)!;
        }
        var matches = await repository.GetAllAsync();
        memoryCache.Set(CacheKeyForMatchAll, JsonSerializer.Serialize(matches), TimeSpan.FromMinutes(5));
        return matches;
    }
    public async Task InsertAsync(InsertMatchDto dto)
    {
        memoryCache.Remove(CacheKeyForMatchAll);
        await repository.InsertAsync(dto);
    }
    public async Task UpdateAsync(UpdateMatchDto dto)
    {
        memoryCache.Remove(CacheKeyForMatchAll);
        await repository.UpdateAsync(dto);
    }
    public async Task DeleteAsync(int id)
    {
        memoryCache.Remove(CacheKeyForMatchAll);
        await repository.DeleteAsync(id);
    }
}