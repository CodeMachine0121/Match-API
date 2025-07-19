using System.Text.Json.Serialization;

using ESportsMatchTracker.API.Models.Domains;

namespace ESportsMatchTracker.API.Models.Ddmains;

public class MatchDomain
{
    public int Id { get; set; }
    public required string Game { get; set; }
    public DateTime StartTime { get; set; }
    public required string Status { get; set; }
    public required string Stage { get; set; }
    public required string Tournament { get; set; }
    public required string StreamUrl { get; set; }
    public string? CurrentMap { get; set; }
    public string? Winner { get; set; }
    public List<string>? Teams { get; set; }
    public required MatchDetailDomain MatchDetails { get; set; }
    public Dictionary<string, int>? Score { get; set; }
    public List<MapScoreDomain>? MapScores { get; set; }
}