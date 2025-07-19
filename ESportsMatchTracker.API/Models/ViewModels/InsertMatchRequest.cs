using System.Text.Json.Serialization;

using ESportsMatchTracker.API.Models.Dtos;

namespace ESportsMatchTracker.API.Models.ViewModels;

public class InsertMatchRequest
{
    [JsonPropertyName("game")]
    public string Game { get; set; }

    [JsonPropertyName("teamsJson")]
    public string TeamsJson { get; set; }

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

    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("mapPoolJson")]
    public string MapPoolJson { get; set; }

    [JsonPropertyName("scoreJson")]
    public string? ScoreJson { get; set; }

    [JsonPropertyName("mapScoresJson")]
    public string? MapScoresJson { get; set; }

    [JsonPropertyName("currentMap")]
    public string? CurrentMap { get; set; }

    [JsonPropertyName("winner")]
    public string? Winner { get; set; }
    [JsonPropertyName("operator")]
    public string Operator { get; set; }
    public InsertMatchDto ToDto()
    {

        return new InsertMatchDto
        {
            Game = Game,
            TeamsJson = TeamsJson,
            StartTime = StartTime,
            Status = Status,
            Stage = Stage,
            Tournament = Tournament,
            StreamUrl = StreamUrl,
            Format = Format,
            MapPoolJson = MapPoolJson,
            ScoreJson = ScoreJson,
            MapScoresJson = MapScoresJson,
            CurrentMap = CurrentMap,
            Winner = Winner,
            Operator = Operator
        };
    }
}