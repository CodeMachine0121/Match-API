using ESportsMatchTracker.API.Controllers;
using ESportsMatchTracker.API.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Controllers;

[TestFixture]
public class MatchControllerTests
{
    [Test]
    public void should_get_ok_with_right_response()
    {
        var controller = new MatchController();
        var result = (OkObjectResult) controller.GetMatches();
        
        Assert.Multiple(() =>
        {
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value, Is.TypeOf<List<MathResponse>>());
        });
    }
    
}