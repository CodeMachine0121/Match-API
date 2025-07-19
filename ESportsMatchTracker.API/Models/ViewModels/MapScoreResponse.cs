using System.Text.Json.Serialization;

namespace ESportsMatchTracker.API.Models.ViewModels;

public class MapScoreResponse
{
    [JsonPropertyName("map")]
    public string Map { get; set; }

    [JsonPropertyName("score")]
    public Dictionary<string, int> Score { get; set; }
}