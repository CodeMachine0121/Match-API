namespace ESportsMatchTracker.API.Models.Dtos;

public class InsertMatchDto
{
    
    public required string Game { get; set; }
    public required string TeamsJson { get; set; }
    public DateTime StartTime { get; set; }
    public required string Status { get; set; }
    public required string Stage { get; set; }
    public required string Tournament { get; set; }
    public required string StreamUrl { get; set; }
    public required string Format { get; set; }
    public required string MapPoolJson { get; set; }
    public string? ScoreJson { get; set; }
    public string? MapScoresJson { get; set; }
    public string? CurrentMap { get; set; }
    public string? Winner { get; set; }
    public required string Operator { get; set; }
    public Match ToEntity()
    {

        return new Match
        {
            Game = Game,
            StartTime = StartTime,
            Status = Status,
            Stage = Stage,
            Tournament = Tournament,
            StreamUrl = StreamUrl,
            CurrentMap = CurrentMap,
            Winner = Winner,
            TeamsJson = TeamsJson,
            Format = Format,
            MapPoolJson = MapPoolJson,
            ScoreJson = ScoreJson,
            MapScoresJson = MapScoresJson,
            CreatedBy = Operator,
            CreatedOn = DateTime.UtcNow,
        };
    }
}