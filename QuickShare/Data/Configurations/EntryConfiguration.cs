using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickShare.Data.Entities;

namespace QuickShare.Data.Configurations;

public class EntryConfiguration : IEntityTypeConfiguration<EntryEntity>
{
    public void Configure(EntityTypeBuilder<EntryEntity> builder)
    {
        builder.Property(el => el.SpaceId).IsRequired();
        builder.HasOne(el => el.Space).WithMany(el => el.Entries).HasForeignKey(el => el.SpaceId).IsRequired();
        builder.Property(e => e.Type).HasConversion<string>().IsRequired();
        
        builder.Property(e => e.Text).IsRequired(false);
        builder.Property(el => el.FileId).IsRequired();
        builder.HasOne(el => el.File).WithOne(el => el.Entry).HasForeignKey<EntryEntity>(el => el.FileId);
    }
}