using ESportsMatchTracker.API.Data;
using ESportsMatchTracker.API.Data.Entities;
using ESportsMatchTracker.API.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ESportsMatchTracker.API.Repositories;

public class UnitOfWork(
    ESportsDbContext dbContext,
    IMatchRepository matchRepository,
    ILogger<UnitOfWork> logger)
    : IUnitOfWork
{
    public IMatchRepository MatchRepository()
    {
        return matchRepository;
    }

    public async Task SaveChangesAsync()
    {
        logger.LogInformation("Start saving changes to database...");
        
        // 详细日志：遍历所有被跟踪的实体变更
        var entries = dbContext.ChangeTracker.Entries()
            .Where(e => 
                e.State is EntityState.Added
                or EntityState.Modified
                or EntityState.Deleted)
            .ToList();

        foreach (var entry in entries)
        {
            string entityName = entry.Entity.GetType().Name;
            var keyProps = entry.Properties.Where(p => p.Metadata.IsPrimaryKey());
            string keyInfo = string.Join(", ", keyProps.Select(p => $"{p.Metadata.Name}={p.CurrentValue}"));

            switch (entry.State)
            {
                case EntityState.Added:
                    // 记录所有属性的当前值
                    var addedValues = string.Join(", ", entry.Properties.Select(p => $"{p.Metadata.Name}='{p.CurrentValue}'"));
                    await dbContext.ActionLogs.AddAsync(new ActionLog
                    {
                        ActionType = entry.State.ToString(),
                        TableName = entityName,
                        Description = $"[ADD] {entityName}:: {keyInfo} | Values: {addedValues}",
                        Timestamp = DateTime.UtcNow
                    });
                    break;
                case EntityState.Deleted:
                    // 记录所有属性的原始值
                    var deletedValues = string.Join(", ", entry.Properties.Select(p => $"{p.Metadata.Name}='{p.OriginalValue}'"));
                    await dbContext.ActionLogs.AddAsync(new ActionLog
                    {
                        ActionType = entry.State.ToString(),
                        TableName = entityName,
                        Description = $"[DELETED] {entityName} ({keyInfo}) | Values: {deletedValues}",
                        Timestamp = DateTime.UtcNow
                    });
                    break;
                case EntityState.Modified:
                    // 记录所有属性的原始值和当前值
                    var allProps = entry.Properties;
                    foreach (var prop in allProps)
                    {
                        await dbContext.ActionLogs.AddAsync(new ActionLog
                        {
                            ActionType = entry.State.ToString(),
                            TableName = entityName,
                            Description = $"[MODIFIED] {entityName} ({keyInfo}): {prop.Metadata.Name} from '{prop.OriginalValue}' to '{prop.CurrentValue}'",
                            Timestamp = DateTime.UtcNow
                        });
                    }
                    break;
            }
        }

        await dbContext.SaveChangesAsync();
    }
}