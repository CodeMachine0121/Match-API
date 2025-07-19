using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Domains;
using ESportsMatchTracker.API.Models.Dtos;

/// <summary>
/// 代表 "Matches" 資料庫表格。
/// 這是我們唯一的資料表，它包含了所有資訊。
/// </summary>
[Table("Matches")]
public class Match
{
    /// <summary>
    /// 主鍵 (Primary Key)。
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("game")]
    public string Game { get; set; }

    /// <summary>
    /// 對於 List<string>，最簡單的方法是將其序列化為 JSON 字串儲存。
    /// 資料庫欄位類型會是 NVARCHAR(MAX) 或 JSON。
    /// </summary>
    [Column("teams_json")]
    public string TeamsJson { get; set; } // 原本是 List<string> Teams

    [Column("start_time")]
    public DateTime StartTime { get; set; }

    [Column("status")]
    public string Status { get; set; }

    [Column("stage")]
    public string Stage { get; set; }

    [Column("tournament_name")]
    public string Tournament { get; set; }

    [Column("stream_url")]
    public string StreamUrl { get; set; }

    // --- 處理巢狀物件 MatchDetails ---
    // MatchDetails 的屬性會被直接放到 Matches 表格中。

    [Column("format")]
    public string Format { get; set; } // 來自 MatchDetails.Format

    /// <summary>
    /// MapPool 同樣序列化為 JSON 字串。
    /// </summary>
    [Column("map_pool_json")]
    public string MapPoolJson { get; set; } // 來自 MatchDetails.MapPool

    // --- 處理其他狀態的欄位 ---

    /// <summary>
    /// Dictionary<string, int> 也序列化為 JSON 字串。
    /// 例如: "{ \"Team Alpha\": 2, \"Team Omega\": 0 }"
    /// </summary>
    [Column("overall_score_json")]
    public string? ScoreJson { get; set; } // 原本是 Dictionary<string, int>? Score

    /// <summary>
    /// 整個 MapScore 列表同樣序列化為 JSON 字串。
    /// </summary>
    [Column("map_scores_json")]
    public string? MapScoresJson { get; set; } // 原本是 List<MapScore>? MapScores

    [Column("current_map")]
    public string? CurrentMap { get; set; }

    [Column("winner_team_name")]
    public string? Winner { get; set; }
    
    [Column("created_by")]
    [Required]
    public string CreatedBy { get; set; }
    
    [Column("created_on")]
    [Required]
    public DateTime CreatedOn { get; set; }
    
    [Column("modified_by")]
    [Required]
    public string? ModifiedBy { get; set; }
    
    [Column("modified_on")]
    [Required]
    public DateTime ModifiedOn { get; set; }
    
    public MatchDomain ToMatchDomain()
    {

        return new MatchDomain
        {
            // --- 直接對應的簡單屬性 ---
            Id = Id,
            Game = Game,
            StartTime = StartTime,
            Status = Status,
            Stage = Stage,
            Tournament = Tournament,
            StreamUrl = StreamUrl,
            CurrentMap = CurrentMap,
            Winner = Winner,

            // --- 執行反序列化來填充複雜屬性 ---

            // 反序列化 TeamsJson 成為 List<string>
            Teams = JsonSerializer.Deserialize<List<string>>(TeamsJson),

            // 組合 MatchDetailDomain 物件
            MatchDetails = new MatchDetailDomain
            {
                Format = Format, // 直接從 entity 取得
                MapPool = JsonSerializer.Deserialize<List<string>>(MapPoolJson)
            },

            // 反序列化 ScoreJson，並處理可能為 null 的情況
            Score = ScoreJson != null
                ? JsonSerializer.Deserialize<Dictionary<string, int>>(ScoreJson)
                : null,

            // 反序列化 MapScoresJson，並處理可能為 null 的情況
            MapScores = MapScoresJson != null
                ? JsonSerializer.Deserialize<List<MapScoreDomain>>(MapScoresJson)
                : null
        };
    }
    public void UpdateFromDto(UpdateMatchDto dto)
    {
        Game = dto.Game;
        TeamsJson = dto.TeamsJson;
        StartTime = dto.StartTime;
        Status = dto.Status;
        Stage = dto.Stage;
        Tournament = dto.Tournament;
        StreamUrl = dto.StreamUrl;
        Format = dto.Format;
        MapPoolJson = dto.MapPoolJson;
        ScoreJson = dto.ScoreJson;
        MapScoresJson = dto.MapScoresJson;
        CurrentMap = dto.CurrentMap;
        Winner = dto.Winner;

        // 更新操作員和修改時間
        ModifiedBy = dto.Operator;
        ModifiedOn = DateTime.UtcNow;
    }
}
