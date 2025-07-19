using ESportsMatchTracker.API.Data.Configurations;

using Microsoft.EntityFrameworkCore;

namespace ESportsMatchTracker.API.Data;

public class ESportsDbContext : DbContext
{
    public ESportsDbContext(DbContextOptions<ESportsDbContext> options) : base(options) { }

    public DbSet<Match> Matches { get; set; }
    // 可根据需要添加更多 DbSet

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MatchConfiguration());
    }
}