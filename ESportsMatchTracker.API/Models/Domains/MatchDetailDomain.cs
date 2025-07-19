using ESportsMatchTracker.API.Models.ViewModels;

namespace ESportsMatchTracker.API.Models.Ddmains;

public class MatchDetailDomain
{
    public required string Format { get; set; }
    public List<string>? MapPool { get; set; }
    public MatchDetailsResponse ToResponse()
    {
        return new MatchDetailsResponse
        {
            Format = Format,
            MapPool = MapPool
        };
    }
}