using System.Text.Json;

using ESportsMatchTracker.API.Data;
using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Domains;
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
        // 1. 從資料庫獲取原始的 Entity 集合
        var entities = await dbContext.Matches.ToListAsync();

        // 2. 使用 LINQ 的 .Select() 方法進行轉換 (Mapping)
        var domains = await dbContext.Matches
            .Select(entity => ToMatchDomain(entity))
            .ToListAsync();

        // 3. 回傳轉換後的 Domain 物件集合
        return domains;
    }
    private static MatchDomain ToMatchDomain(Match entity)
    {

        return new MatchDomain
        {
            // --- 直接對應的簡單屬性 ---
            Id = entity.Id,
            Game = entity.Game,
            StartTime = entity.StartTime,
            Status = entity.Status,
            Stage = entity.Stage,
            Tournament = entity.Tournament,
            StreamUrl = entity.StreamUrl,
            CurrentMap = entity.CurrentMap,
            Winner = entity.Winner,

            // --- 執行反序列化來填充複雜屬性 ---

            // 反序列化 TeamsJson 成為 List<string>
            Teams = JsonSerializer.Deserialize<List<string>>(entity.TeamsJson),

            // 組合 MatchDetailDomain 物件
            MatchDetails = new MatchDetailDomain
            {
                Format = entity.Format, // 直接從 entity 取得
                MapPool = JsonSerializer.Deserialize<List<string>>(entity.MapPoolJson)
            },

            // 反序列化 ScoreJson，並處理可能為 null 的情況
            Score = entity.ScoreJson != null
                ? JsonSerializer.Deserialize<Dictionary<string, int>>(entity.ScoreJson)
                : null,

            // 反序列化 MapScoresJson，並處理可能為 null 的情況
            MapScores = entity.MapScoresJson != null
                ? JsonSerializer.Deserialize<List<MapScoreDomain>>(entity.MapScoresJson)
                : null
        };
    }
}
