using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESportsMatchTracker.API.Data.Configurations;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("Match");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        builder.Property(m => m.Game)
            .HasColumnName("game")
            .IsRequired();
        builder.Property(m => m.TeamsJson)
            .HasColumnName("teams_json")
            .IsRequired();
        builder.Property(m => m.StartTime)
            .HasColumnName("start_time");
        builder.Property(m => m.Status)
            .HasColumnName("status")
            .IsRequired();
        builder.Property(m => m.Stage)
            .HasColumnName("stage")
            .IsRequired();
        builder.Property(m => m.Tournament)
            .HasColumnName("tournament_name")
            .IsRequired();
        builder.Property(m => m.StreamUrl)
            .HasColumnName("stream_url")
            .IsRequired();
        builder.Property(m => m.Format)
            .HasColumnName("format")
            .IsRequired();
        builder.Property(m => m.MapPoolJson)
            .HasColumnName("map_pool_json")
            .IsRequired();
        builder.Property(m => m.ScoreJson)
            .HasColumnName("overall_score_json");
        builder.Property(m => m.MapScoresJson)
            .HasColumnName("map_scores_json");
        builder.Property(m => m.CurrentMap)
            .HasColumnName("current_map");
        builder.Property(m => m.Winner)
            .HasColumnName("winner_team_name");
        
        builder.Property(m => m.CreatedBy)
            .HasColumnName("created_by");
        builder.Property(m => m.CreatedOn)
            .HasColumnName("created_on")
            .HasDefaultValueSql("GETDATE()");
        builder.Property(m => m.ModifiedBy)
            .HasColumnName("modified_by");
        builder.Property(m => m.ModifiedOn)
            .HasColumnName("modified_on")
            .HasDefaultValueSql("GETDATE()");
                
            
    }
}