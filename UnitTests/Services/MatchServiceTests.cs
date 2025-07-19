using ESportsMatchTracker.API.Models.Ddmains;
using ESportsMatchTracker.API.Models.Dtos;
using ESportsMatchTracker.API.Repositories.Interfaces;
using ESportsMatchTracker.API.Services;

using NSubstitute;

namespace UnitTests.Services;

[TestFixture]
public class MatchServiceTests
{
    private IUnitOfWork _unitOfWork;
    private IMatchRepository _matchRepository;
    private MatchService _matchService;

    [SetUp]
    public void SetUp()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _matchRepository = Substitute.For<IMatchRepository>();
        _unitOfWork.MatchRepository().Returns(_matchRepository);
        _matchService = new MatchService(_unitOfWork);
    }

    [Test]
    public async Task should_insert_data_by_repository()
    {
        await _matchService.InsertAsync(CreateInsertMatchDto());
        await _unitOfWork.MatchRepository().Received(1).InsertAsync(Arg.Is<InsertMatchDto>(i => i.Game == "test-game"));
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Test]
    public async Task should_update_data_by_repository()
    {
        await _matchService.UpdateAsync(CreateUpdateMatchDto());
        await _unitOfWork.MatchRepository().Received(1).UpdateAsync(Arg.Is<UpdateMatchDto>(i => i.Game == "update-test-game"));
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Test]
    public async Task should_delete_data_by_repository()
    {
        int idToDelete = 1;
        await _matchService.DeleteAsync(idToDelete);
        await _unitOfWork.MatchRepository().Received(1).DeleteAsync(Arg.Is<int>(i => i == idToDelete));
        await _unitOfWork.Received(1).SaveChangesAsync();
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
                }
            });

        var result = await _matchService.GetMathches();

        await _unitOfWork.MatchRepository().Received(1).GetAllAsync();
        await _unitOfWork.Received(1).SaveChangesAsync();
        Assert.That(result, Has.Count.EqualTo(1));

    }
    private UpdateMatchDto CreateUpdateMatchDto()
    {
        return new UpdateMatchDto
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

    private static InsertMatchDto CreateInsertMatchDto()
    {
        return new InsertMatchDto
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
        _unitOfWork.MatchRepository().GetAllAsync().Returns(matches.ToList());
    }
}