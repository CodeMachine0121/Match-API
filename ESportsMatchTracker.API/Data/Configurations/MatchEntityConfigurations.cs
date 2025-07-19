using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ESportsMatchTracker.API.Data.Entities;

namespace ESportsMatchTracker.API.Data.Configurations;

public class MatchDetailsConfiguration : IEntityTypeConfiguration<MatchDetails>
{
    public void Configure(EntityTypeBuilder<MatchDetails> builder)
    {
        builder.ToTable("MatchDetails");
        builder.HasKey(md => md.Id);
        builder.Property(md => md.Format).IsRequired();
        builder.Property(md => md.MapPoolJson).IsRequired();
    }
}

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("Match");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Game).IsRequired();
        builder.Property(m => m.TeamsJson).IsRequired();
        builder.Property(m => m.Status).IsRequired();
        builder.Property(m => m.Stage).IsRequired();
        builder.Property(m => m.Tournament).IsRequired();
        builder.Property(m => m.StreamUrl).IsRequired();
        builder.HasOne(m => m.MatchDetails)
               .WithMany(md => md.Matches)
               .HasForeignKey(m => m.MatchDetailsId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

