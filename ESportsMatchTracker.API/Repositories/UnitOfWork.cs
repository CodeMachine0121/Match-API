using ESportsMatchTracker.API.Data;
using ESportsMatchTracker.API.Repositories.Interfaces;

namespace ESportsMatchTracker.API.Repositories;

public class UnitOfWork(
    ESportsDbContext dbContext,
    IMatchRepository matchRepository) : IUnitOfWork
{
    public IMatchRepository MatchRepository()
    {
        return matchRepository;
    }

    public Task<int> SaveChangeAsync()
    {
        return dbContext.SaveChangesAsync();
    }
}