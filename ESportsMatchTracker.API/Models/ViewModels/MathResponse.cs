using System.Text.Json.Serialization;

namespace ESportsMatchTracker.API.Models.ViewModels;

public class MathResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("game")]
    public string Game { get; set; }

    [JsonPropertyName("teams")]
    public List<string> Teams { get; set; }

    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("stage")]
    public string Stage { get; set; }

    [JsonPropertyName("tournament")]
    public string Tournament { get; set; }

    [JsonPropertyName("streamUrl")]
    public string StreamUrl { get; set; }

    [JsonPropertyName("currentMap")]
    public string? CurrentMap { get; set; } // Only present in live matches

    [JsonPropertyName("score")]
    public Dictionary<string, int>? Score { get; set; } // Present in live and ended matches

    [JsonPropertyName("mapScores")]
    public List<MapScoreResponse>? MapScores { get; set; } // Present in live and ended matches

    [JsonPropertyName("winner")]
    public string? Winner { get; set; } // Only present in ended matches

    [JsonPropertyName("matchDetails")]
    public MatchDetailsResponse MatchDetails { get; set; }
}