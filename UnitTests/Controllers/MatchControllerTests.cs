using ESportsMatchTracker.API.Controllers;
using ESportsMatchTracker.API.Models.ViewModels;
using ESportsMatchTracker.API.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace UnitTests.Controllers;

[TestFixture]
public class MatchControllerTests
{
    private IMatchService _matchService;
    [Test]
    public async Task should_get_ok_with_right_response()
    {
        _matchService = Substitute.For<IMatchService>();
        var controller = new MatchController(_matchService);
        var result = (OkObjectResult) (await controller.GetMatches());
        
        await _matchService.Received(1).GetMathches();
      
        Assert.Multiple(() =>
        {
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value, Is.TypeOf<List<MathResponse>>());
        });
    }
    
}