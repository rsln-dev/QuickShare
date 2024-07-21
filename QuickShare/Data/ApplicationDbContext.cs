using Microsoft.EntityFrameworkCore;
using QuickShare.Data.Configurations;
using QuickShare.Data.Entities;

namespace QuickShare.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<SpaceEntity> Spaces { get; set; } = null!;
    public DbSet<EntryEntity> Entries { get; set; } = null!;
    
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new EntryConfiguration());
        modelBuilder.ApplyConfiguration(new SpaceConfiguration());
        modelBuilder.ApplyConfiguration(new FileConfiguration());
        
        modelBuilder.UseHiLo();
    }
}