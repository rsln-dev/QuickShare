using Microsoft.EntityFrameworkCore;
using QuickShare.Data;
using QuickShare.Data.Entities;
using QuickShare.Services.Interfaces;

namespace QuickShare.Services;

public class SpaceService: ISpaceService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly SlugService _slugService;

    public SpaceService(ApplicationDbContext dbContext, SlugService slugService)
    {
        _dbContext = dbContext;
        _slugService = slugService;
    }

    public async Task<SpaceEntity> CreateSpace(int length, int ttl)
    {
        var newSpace = new SpaceEntity()
        {
            Slug = _slugService.Generate(length),
            TTL = ttl,
        };
        _dbContext.Spaces.Add(newSpace);
        
        await _dbContext.SaveChangesAsync();

        return newSpace;
    }

    public async Task<bool> DeleteSpace(int id)
    {
        var entity = await _dbContext.Spaces.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        _dbContext.Entry(entity).State = EntityState.Deleted;
        
        await _dbContext.SaveChangesAsync();

        return true;
    }
    
    public async Task<SpaceEntity> GetSpace(string slug)
    {
        var space = await _dbContext.Spaces.FirstOrDefaultAsync(el => el.Slug == slug);
            // .Include(i => i.CatalogBrand)
            // .Include(i => i.CatalogType)
            // .OrderBy(c => c.Name)
            // .Skip(pageSize * pageIndex)
            // .Take(pageSize)
            // .ToListAsync();

            return space!;
    }
}