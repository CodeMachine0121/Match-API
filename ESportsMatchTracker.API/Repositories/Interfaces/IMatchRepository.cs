using ESportsMatchTracker.API.Models.Ddmains;

namespace ESportsMatchTracker.API.Repositories.Interfaces;

public interface IMatchRepository
{
    Task<List<MathDomain>> GetAllAsync();
}