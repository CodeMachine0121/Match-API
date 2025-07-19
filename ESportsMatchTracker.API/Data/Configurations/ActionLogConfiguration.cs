using ESportsMatchTracker.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESportsMatchTracker.API.Data.Configurations
{
    public class ActionLogConfiguration : IEntityTypeConfiguration<ActionLog>
    {
        public void Configure(EntityTypeBuilder<ActionLog> builder)
        {
            builder.ToTable("ActionLogs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ActionType).IsRequired().HasMaxLength(64);
            builder.Property(x => x.TableName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Description).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Timestamp).IsRequired();
        }
    }
}

