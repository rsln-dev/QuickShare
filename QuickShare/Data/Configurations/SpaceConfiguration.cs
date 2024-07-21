using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickShare.Data.Entities;

namespace QuickShare.Data.Configurations;

public class SpaceConfiguration : IEntityTypeConfiguration<SpaceEntity>
{
    public void Configure(EntityTypeBuilder<SpaceEntity> builder)
    {
        builder.Property(el => el.Slug).IsRequired();
        builder.Property(el => el.TTL).IsRequired();
        builder.HasMany(el => el.Entries).WithOne(el => el.Space).HasForeignKey(el => el.SpaceId).IsRequired();
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}