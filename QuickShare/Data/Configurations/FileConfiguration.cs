using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickShare.Data.Entities;

namespace QuickShare.Data.Configurations;

public class FileConfiguration : IEntityTypeConfiguration<FileEntity>
{
    public void Configure(EntityTypeBuilder<FileEntity> builder)
    {
        builder.Property(el => el.Url).IsRequired();
        builder.HasOne(el => el.Entry).WithOne(el => el.File).HasForeignKey<FileEntity>(el => el.EntryId).IsRequired();
    }
}