using ESportsMatchTracker.API.Data;

namespace ESportsMatchTracker.API.Repositories.Interfaces;


public interface IUnitOfWork
{
    IMatchRepository MatchRepository();
    Task SaveChangesAsync();
}