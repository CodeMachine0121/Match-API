using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Repositories.Interfaces;
using ESportsMatchTracker.API.Services;

using NSubstitute;

namespace UnitTests.Services;

[TestFixture]
public class MatchServiceTests
{
    private IMatchRepository _matchRepository;
    private MatchService _matchService;

    [SetUp]
    public void SetUp()
    {
        _matchRepository = Substitute.For<IMatchRepository>();
        _matchService = new MatchService(_matchRepository);
    }

    [Test]
    public async Task should_get_data_from_repository()
    {
        GivenMatches(
            new MatchDomain
            {
                Id = 1,
                Game = "test-game",
                Teams =
                [
                    "team1",
                    "team2"
                ],
                Status = "scheduled",
                Stage = "test-stage",
                Tournament = "test-tournament",
                StreamUrl = "test-stream-url",
                MatchDetails = new MatchDetailDomain
                {
                    Format = "test-format",
                    MapPool = []
                },
            });
        
        var result = await _matchService.GetMathches();
        
        await _matchRepository.Received(1).GetAllAsync();
        Assert.That(result, Has.Count.EqualTo(1));
        
    }

    private void GivenMatches(params MatchDomain[] matches)
    {
        _matchService.GetMathches().Returns(matches.ToList());
    }
}