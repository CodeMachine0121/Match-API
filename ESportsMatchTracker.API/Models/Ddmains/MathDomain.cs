using System.Text.Json.Serialization;

namespace ESportsMatchTracker.API.Models.Ddmains;

public class MathDomain
{
    public int Id { get; set; }
    public required string Game { get; set; }

    public required List<string> Teams { get; set; }
    public DateTime StartTime { get; set; }
    public required string Status { get; set; }
    public required string Stage { get; set; }
    public required string Tournament { get; set; }
    public required string StreamUrl { get; set; }
    public string? CurrentMap { get; set; } // Only present in live matches
    public Dictionary<string, int>? Score { get; set; } // Present in live and ended matches
    public List<MapScoreDomain>? MapScores { get; set; } // Present in live and ended matches
    public string? Winner { get; set; } // Only present in ended matches
    public required MatchDetailsDomain MatchDetailsDomain { get; set; }
}