using ESportsMatchTracker.API.Data.Entities;

using Microsoft.EntityFrameworkCore;
using ESportsMatchTracker.API.Models.Ddmains;

namespace ESportsMatchTracker.API.Data;

public class ESportsDbContext : DbContext
{
    public ESportsDbContext(DbContextOptions<ESportsDbContext> options) : base(options) { }

    public DbSet<Match> Matches { get; set; }
    public DbSet<MatchDetails> MatchDetails { get; set; }
    // 可根据需要添加更多 DbSet

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new Configurations.MatchDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.MatchConfiguration());
    }
}