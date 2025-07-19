using ESportsMatchTracker.API.Controllers;

using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Controllers;

[TestFixture]
public class MatchControllerTests
{
    [Test]
    public void should_get_ok_with_right_response()
    {
        var controller = new MatchController();
        var result = (OkResult) controller.GetMatches();
        Assert.That(result.StatusCode, Is.EqualTo(200));
    }
    
}