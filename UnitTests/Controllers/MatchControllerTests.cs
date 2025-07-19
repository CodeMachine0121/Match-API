using ESportsMatchTracker.API.Controllers;
using ESportsMatchTracker.API.Models.Ddmains;
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
        var result = (CreatedResult)await _controller.InsertAsync(new InsertMatchRequest());
        Assert.That(result.StatusCode, Is.EqualTo(201));
    }
    private void GivenMatches(params MatchDomain[] matches)
    {

        _matchService.GetMathches().Returns(matches.ToList());
    }
}