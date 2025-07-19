namespace ESportsMatchTracker.API.Models.Ddmains;

public class MapScoreDomain
{
    public string Map { get; set; }
    public Dictionary<string, int> Score { get; set; }
}