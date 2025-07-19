using System.Text.Json.Serialization;

namespace ESportsMatchTracker.API.Models.ViewModels;

public class MatchDetailsResponse
{
    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("mapPool")]
    public List<string> MapPool { get; set; }
}