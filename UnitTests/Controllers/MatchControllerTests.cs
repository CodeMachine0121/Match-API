using ESportsMatchTracker.API.Controllers;
using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Dtos;
using ESportsMatchTracker.API.Models.ViewModels;
using ESportsMatchTracker.API.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace UnitTests.Controllers;

[TestFixture]
public class MatchControllerTests
{
    private MatchController _controller;
    private IMatchService _matchService;
    [SetUp]
    public void SetUp()
    {
        _matchService = Substitute.For<IMatchService>();
        _controller = new MatchController(_matchService);
    }

    [Test]
    public async Task should_get_ok_with_right_response()
    {
        GivenMatches(new MatchDomain
        {
            Id = 1,
            Game = "test-game",
            Teams = ["team1", "team2"],
            Status = "scheduled",
            Stage = "test-stage",
            Tournament = "test-tournament",
            StreamUrl = "test-stream-url",
            MatchDetails = new MatchDetailDomain
            {
                Format = "test-format",
                MapPool = []
            }
        });

        var result = (OkObjectResult)await _controller.GetMatches();

        await _matchService.Received(1).GetMathches();

        Assert.Multiple(() =>
        {
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value, Is.TypeOf<List<MathResponse>>());
            Assert.That((List<MathResponse>)result.Value!, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public async Task should_get_201_when_insert_data()
    {
        var result = (CreatedResult)await _controller.InsertAsync(CreateInsertMatchRequest());
        await _matchService.Received().InsertAsync(Arg.Is<InsertMatchDto>(x => x.Game == "test-game"));

        Assert.That(result.StatusCode, Is.EqualTo(201));
    }

    [Test]
    public async Task should_get_200_when_update_data()
    {
        var result = (OkResult)await _controller.UpdateAsync(CreateUpdateMatchRequest());
        await _matchService.Received().UpdateAsync(Arg.Is<UpdateMatchDto>(x => x.Game == "update-test-game"));
        Assert.That(result.StatusCode, Is.EqualTo(200));
    }
    
    private UpdateMatchRequest CreateUpdateMatchRequest()
    {
        return new UpdateMatchRequest
        {
            Game = "update-test-game",
            TeamsJson = "[\"team1\", \"team2\"]",
            StartTime = DateTime.UtcNow,
            Status = "scheduled",
            Stage = "test-stage",
            Tournament = "test-tournament",
            StreamUrl = "test-stream-url",
            Format = "test-format",
            MapPoolJson = "[]",
            ScoreJson = "{\"Team Alpha\": 2, \"Team Omega\": 0}",
            MapScoresJson = "[]",
            CurrentMap = "Map1",
            Winner = "Team Alpha",
            Operator = "test-operator"
        };
    }

    private static InsertMatchRequest CreateInsertMatchRequest()
    {

        return new InsertMatchRequest
        {
            Game = "test-game",
            TeamsJson = "[\"team1\", \"team2\"]",
            StartTime = DateTime.UtcNow,
            Status = "scheduled",
            Stage = "test-stage",
            Tournament = "test-tournament",
            StreamUrl = "test-stream-url",
            Format = "test-format",
            MapPoolJson = "[]",
            ScoreJson = "{\"Team Alpha\": 2, \"Team Omega\": 0}",
            MapScoresJson = "[]",
            CurrentMap = "Map1",
            Winner = "Team Alpha",
            Operator = "test-operator"
        };
    }
    private void GivenMatches(params MatchDomain[] matches)
    {
        _matchService.GetMathches().Returns(matches.ToList());
    }
}